using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Forwarders;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Members
{
    public sealed partial class SourceMemberCatalog
    {
        private readonly ISourceMemberLookupDiagnostics diagnostics;
        public SourceTypeForwarderCatalog SourceTypeForwarders { get; }

        private readonly Dictionary<string, List<SourceMemberDefinition>> definitions = new(StringComparer.Ordinal);

        private readonly Dictionary<Type, Dictionary<string, SourcePhysicalMemberBinding>> bindings = new();

        private readonly Dictionary<Type, string> actualTypes = new();

        private readonly Dictionary<string, Type> sourceTypes = new(StringComparer.Ordinal);

        private readonly Dictionary<string, string> baseTypes = new(StringComparer.Ordinal);

        private readonly Dictionary<Type, string> originalTypeNames = new();

        private readonly Dictionary<string, SourceTypeDefinition> typeDefinitions = new(StringComparer.Ordinal);

        private readonly Dictionary<(string Assembly, string Identity), SourceTypeDefinition>
            typeDefinitionsByIdentity = new();

        public SourceMemberCatalog(ISourceMemberLookupDiagnostics diagnostics,
            SourceTypeForwarderCatalog sourceTypeForwarders)
        {
            this.diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
            SourceTypeForwarders =
                sourceTypeForwarders ?? throw new ArgumentNullException(nameof(sourceTypeForwarders));
        }

        private static string TypeKey(string assemblyIdentity, string typeIdentity)
        {
            return assemblyIdentity + "\n" + typeIdentity;
        }

        private string CanonicalTypeKey(string assemblyIdentity, string typeIdentity)
        {
            if (!SourceTypeForwarders.ContainsForwarder(assemblyIdentity, typeIdentity))
                return TypeKey(assemblyIdentity, typeIdentity);
            var reference = new SourceTypeReference(SourceTypeReferenceKind.Named, assemblyIdentity, typeIdentity);
            var path = SourceTypeForwarders.ResolveForwardingPath(reference);
            return TypeKey(path.TerminalReference.AssemblyIdentity, path.TerminalReference.TypeIdentity);
        }

        private string CanonicalDeclaredTypeKey(SourceTypeReference reference)
        {
            if (reference == null)
                throw new InvalidOperationException("The original declared type reference has not been published.");
            while (reference.Kind == SourceTypeReferenceKind.GenericInstance
                   || reference.Kind == SourceTypeReferenceKind.RequiredModifier
                   || reference.Kind == SourceTypeReferenceKind.OptionalModifier)
                reference = reference.ElementType;
            if (reference.Kind != SourceTypeReferenceKind.Named)
                throw new InvalidOperationException(
                    "An original type declaration requires a genuine named definition scope.");
            return CanonicalTypeKey(reference.AssemblyIdentity, reference.TypeIdentity);
        }

        public SourceTypeDefinition ResolveNamedTypeDefinition(SourceTypeReference reference)
        {
            if (reference == null) throw new ArgumentNullException(nameof(reference));
            if (reference.Kind != SourceTypeReferenceKind.Named)
                throw new ArgumentException("ResolveNamedTypeDefinition requires a genuine named source scope.");
            var key = CanonicalTypeKey(reference.AssemblyIdentity, reference.TypeIdentity);
            return typeDefinitions.TryGetValue(key, out var definition)
                ? definition
                : throw new InvalidOperationException("The terminal original TypeDef has not been published: " + key);
        }

        public SourceTypeDefinition GetOriginalBaseTypeDefinition(SourceTypeDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            var key = TypeKey(definition.AssemblyIdentity, definition.Identity);
            if (!typeDefinitions.TryGetValue(key, out var registered) || !ReferenceEquals(registered, definition))
                throw new InvalidOperationException(
                    "The requested source type definition does not belong to this catalog.");
            var baseKey = baseTypes[key];
            if (baseKey == null) return null;
            return typeDefinitions.TryGetValue(baseKey, out var baseDefinition)
                ? baseDefinition
                : throw new InvalidOperationException("The canonical original base TypeDef has not been published: " +
                                                      baseKey);
        }

        public void RegisterTypeDefinition(SourceTypeDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            var key = definition.CanonicalKey;
            if (CanonicalTypeKey(definition.AssemblyIdentity, definition.Identity) != key)
                throw new InvalidOperationException(
                    "A forwarded facade type cannot also be published as an original TypeDef in this source profile.");
            typeDefinitions.Add(key, definition);
            typeDefinitionsByIdentity.Add((definition.AssemblyIdentity, definition.Identity), definition);
            baseTypes.Add(key, definition.BaseTypeIdentity == null
                ? null
                : CanonicalDeclaredTypeKey(definition.BaseTypeReference
                                           ?? new SourceTypeReference(SourceTypeReferenceKind.Named,
                                               definition.BaseAssemblyIdentity, definition.BaseTypeIdentity)));
        }

        public SourceTypeDefinition GetOriginalTypeDefinition(Type actualType)
        {
            return RequireActualTypeDefinition(actualType);
        }

        public SourceTypeDefinition GetOriginalTypeDefinition(string assemblyIdentity, string sourceTypeIdentity)
        {
            return ResolveNamedTypeDefinition(new(SourceTypeReferenceKind.Named, assemblyIdentity,
                sourceTypeIdentity));
        }

        public IEnumerable<SourceTypeDefinition> OriginalTypeDefinitions => typeDefinitions.Values;

        public Type GetActualSourceType(string assemblyIdentity, string originalTypeIdentity)
        {
            var key = CanonicalTypeKey(assemblyIdentity, originalTypeIdentity);
            if (sourceTypes.TryGetValue(key, out var actualType))
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                var definition = typeDefinitions[key];
                if (actualTypeBindingSource != null && actualTypeBindingSource.TryGetSelectedActualSourceType(
                        definition.AssemblyIdentity, definition.Identity, out var selectedType) &&
                    selectedType != actualType)
                {
                    if (!actualType.IsAssignableFrom(selectedType)
                        || !ReferenceEquals(RequireActualTypeDefinition(selectedType), definition))
                        throw new InvalidOperationException(
                            "The profile selected actual type is not a genuine derived alias of the explicit original declaration: " +
                            originalTypeIdentity);
                    return selectedType;
                }

                return actualType;
            }

            if (typeDefinitions.TryGetValue(key, out var originalDefinition) && actualTypeBindingSource != null
                                                                             && actualTypeBindingSource
                                                                                 .TryGetActualSourceType(
                                                                                     originalDefinition
                                                                                         .AssemblyIdentity,
                                                                                     originalDefinition.Identity,
                                                                                     out actualType))
            {
                if (!ReferenceEquals(RequireActualTypeDefinition(actualType), originalDefinition))
                    throw new InvalidOperationException(
                        "The borrowed actual type has a different original source definition: " + originalTypeIdentity);
                return actualType;
            }

            if (typeDefinitions.ContainsKey(key))
                throw new InvalidOperationException("Original source type has no qualified actual binding: " +
                                                    originalTypeIdentity);
            if (key != TypeKey(assemblyIdentity, originalTypeIdentity))
                throw new InvalidOperationException(
                    "The known forwarded source type has no published terminal TypeDef: " +
                    originalTypeIdentity);
            return null;
        }

        public void RegisterSourceType(Type actualType, string assemblyIdentity, string originalTypeName,
            string baseAssemblyIdentity = null, string baseTypeIdentity = null)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            var key = CanonicalTypeKey(assemblyIdentity, originalTypeName);
            if (!typeDefinitions.TryGetValue(key, out var definition))
                throw new InvalidOperationException("Publish the original type metadata before its actual binding: " +
                                                    originalTypeName);
            if (baseTypeIdentity != null && (definition.BaseTypeIdentity == null
                                             || CanonicalTypeKey(baseAssemblyIdentity, baseTypeIdentity)
                                             != CanonicalTypeKey(definition.BaseAssemblyIdentity,
                                                 definition.BaseTypeIdentity)))
                throw new InvalidOperationException(
                    "The actual source binding cannot replace its original base metadata.");
            ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
            actualTypes.Add(actualType, key);
            sourceTypes.Add(key, actualType);
            originalTypeNames.Add(actualType, definition.Identity);
            explicitActualTypeBindingsRevision++;
        }

        public void RegisterDefinition(SourceMemberDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            var key = TypeKey(definition.AssemblyIdentity, definition.DeclaringTypeIdentity);
            if (!definitions.TryGetValue(key, out var list))
                definitions.Add(key, list = []);
            foreach (var existing in list)
                if (existing.Identity == definition.Identity)
                    throw new InvalidOperationException("Duplicate source member definition: " + definition.Identity);
            list.Add(definition);
        }

        public SourceMemberDefinition RequireDefinition(string assemblyIdentity, string declaringTypeIdentity,
            string name, SourceMemberKind kind)
        {
            var key = CanonicalTypeKey(assemblyIdentity, declaringTypeIdentity);
            SourceMemberDefinition result = null;
            if (definitions.TryGetValue(key, out var list))
                foreach (var definition in list)
                {
                    if (definition.Kind != kind || definition.Name != name) continue;
                    if (result != null)
                        throw new AmbiguousMatchException("Ambiguous original member definition: " +
                                                          declaringTypeIdentity +
                                                          "." + name);
                    result = definition;
                }

            return result ?? throw new MissingMemberException(declaringTypeIdentity, name);
        }

        public void RegisterBinding(SourcePhysicalMemberBinding binding)
        {
            if (binding == null) throw new ArgumentNullException(nameof(binding));
            var key = CanonicalTypeKey(binding.Definition.AssemblyIdentity,
                binding.Definition.DeclaringTypeIdentity);
            if (!ReferenceEquals(GetOriginalTypeDefinition(binding.DeclaringType),
                    GetOriginalTypeDefinition(binding.Definition.AssemblyIdentity,
                        binding.Definition.DeclaringTypeIdentity)))
                throw new InvalidOperationException("Physical binding has no matching actual source declaring type.");
            if (!definitions.TryGetValue(key, out var list) || !list.Contains(binding.Definition))
                throw new InvalidOperationException(
                    "Register the actual source definition before its physical binding.");
            if (!ContainsSourceType(binding.ActualInstanceScope))
                throw new InvalidOperationException("Register the actual instance scope before its physical binding.");
            if (binding.HasDeclaredActualValueType)
            {
                var reference = binding.Definition.ValueTypeReference;
                while (reference != null && (reference.Kind == SourceTypeReferenceKind.RequiredModifier
                                             || reference.Kind == SourceTypeReferenceKind.OptionalModifier))
                    reference = reference.ElementType;
                var valueDefinition = ResolveNamedTypeDefinition(reference);
                var declaredType = GetActualSourceType(valueDefinition.AssemblyIdentity, valueDefinition.Identity);
                if (declaredType != binding.ValueType)
                    throw new InvalidOperationException(
                        "The declared reference value must match the qualified original source value type.");
            }

            if (!bindings.TryGetValue(binding.ActualInstanceScope, out var scoped))
                bindings.Add(binding.ActualInstanceScope,
                    scoped = new(StringComparer.Ordinal));
            scoped.Add(binding.Definition.Identity, binding);
        }

        public bool ContainsSourceType(Type actualType)
        {
            if (actualType == null) return false;
            if (actualTypes.TryGetValue(actualType, out var key))
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                return true;
            }

            return TryGetBorrowedTypeDefinition(actualType, out _);
        }

        public IEnumerable<KeyValuePair<Type, string>> OriginalTypeNames => EnumerateOriginalTypeNames();
        public int ActualTypeBindingCount => CountActualTypeBindings();
        public int OriginalTypeDefinitionCount => typeDefinitions.Count;

        public string GetOriginalTypeFullName(Type actualType)
        {
            return RequireActualTypeDefinition(actualType).Identity;
        }

        public bool TryGetOriginalTypeName(Type actualType, out string originalTypeName)
        {
            originalTypeName = null;
            if (actualType == null) return false;
            if (actualTypes.TryGetValue(actualType, out var key))
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                originalTypeName = typeDefinitions[key].ShortName;
                return true;
            }

            if (!TryGetBorrowedTypeDefinition(actualType, out var definition)) return false;
            originalTypeName = definition.ShortName;
            return true;
        }

        public string GetOriginalTypeName(Type actualType)
        {
            return RequireActualTypeDefinition(actualType).ShortName;
        }

        public IEnumerable<SourceMemberDefinition> GetOriginalMemberDefinitions(Type actualType, bool declaredOnly)
        {
            var type = GetOriginalTypeDefinition(actualType);
            return EnumerateOriginalMemberDefinitions(type.AssemblyIdentity, type.Identity, declaredOnly, type);
        }

        public IEnumerable<SourceMemberDefinition> GetOriginalMemberDefinitions(string assemblyIdentity,
            string typeIdentity, bool declaredOnly = true)
        {
            return EnumerateOriginalMemberDefinitions(assemblyIdentity, typeIdentity, declaredOnly, null);
        }

        private IEnumerable<SourceMemberDefinition> EnumerateOriginalMemberDefinitions(string assemblyIdentity,
            string typeIdentity, bool declaredOnly, SourceTypeDefinition type)
        {
            var key = type != null && !SourceTypeForwarders.ContainsForwarder(assemblyIdentity, typeIdentity)
                ? type.CanonicalKey
                : CanonicalTypeKey(assemblyIdentity, typeIdentity);
            if (!typeDefinitions.ContainsKey(key))
                throw new InvalidOperationException("Original type metadata has not been published: " + typeIdentity);
            do
            {
                if (definitions.TryGetValue(key, out var list))
                    foreach (var definition in list)
                        yield return definition;
                if (declaredOnly || !baseTypes.TryGetValue(key, out key)) yield break;
            } while (key != null);
        }

        public IEnumerable<SourcePhysicalMemberBinding> GetOriginalSimpleMembers(Type actualType, bool declaredOnly)
        {
            foreach (var definition in GetOriginalMemberDefinitions(actualType, declaredOnly))
                yield return RequireBinding(actualType, definition);
        }

        public IEnumerable<SourcePhysicalMemberBinding> GetAllMembers(Type actualType, SourceMemberKind kind,
            BindingFlags flags)
        {
            foreach (var definition in GetOriginalMemberDefinitions(actualType,
                         (flags & BindingFlags.DeclaredOnly) != 0))
                if (definition.Kind == kind && MatchesReflectionFlags(actualType, definition, flags))
                    yield return RequireBinding(actualType, definition);
        }

        // The original recursive helper deliberately visits private base fields too.
        // Type.GetFields/GetProperties selection remains separate above.
        public IEnumerable<SourcePhysicalMemberBinding> GetAllFieldInfos(Type actualType, BindingFlags flags)
        {
            var currentType = RequireActualTypeKey(actualType);
            do
            {
                if (!typeDefinitions.TryGetValue(currentType, out var type))
                    throw new InvalidOperationException(
                        "Original base type metadata has not been published: " + currentType);
                if (type.BaseTypeIdentity == null ||
                    ((TypeAttributes)type.Attributes & TypeAttributes.Interface) != 0) yield break;
                if (definitions.TryGetValue(currentType, out var list))
                    foreach (var definition in list)
                        if (definition.Kind == SourceMemberKind.Field && MatchesFlags(definition, flags))
                            yield return RequireBinding(actualType, definition);
                if (!baseTypes.TryGetValue(currentType, out currentType)) yield break;
            } while (currentType != null);
        }

        public IEnumerable<SourcePhysicalMemberBinding> GetAllPropertyInfos(Type actualType, BindingFlags flags)
        {
            var currentType = RequireActualTypeKey(actualType);
            do
            {
                if (!typeDefinitions.TryGetValue(currentType, out var type))
                    throw new InvalidOperationException(
                        "Original base type metadata has not been published: " + currentType);
                if (type.BaseTypeIdentity == null ||
                    ((TypeAttributes)type.Attributes & TypeAttributes.Interface) != 0) yield break;
                if (definitions.TryGetValue(currentType, out var list))
                    foreach (var definition in list)
                        if (definition.Kind == SourceMemberKind.Property && MatchesFlags(definition, flags))
                            yield return RequireBinding(actualType, definition);
                if (!baseTypes.TryGetValue(currentType, out currentType)) yield break;
            } while (currentType != null);
        }

        private bool IsOriginalObjectSubclass(Type actualType)
        {
            var definition = GetOriginalTypeDefinition(actualType);
            return definition.Identity != "System.Object" && definition.BaseTypeIdentity != null
                                                          && ((TypeAttributes)definition.Attributes &
                                                              TypeAttributes.Interface) == 0;
        }

        public SourcePhysicalMemberBinding RequireBinding(Type actualInstanceScope, SourceMemberDefinition definition)
        {
            if (actualInstanceScope == null) throw new ArgumentNullException(nameof(actualInstanceScope));
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            var declaringKey = CanonicalTypeKey(definition.AssemblyIdentity, definition.DeclaringTypeIdentity);
            if (!definitions.TryGetValue(declaringKey, out var declared) || !declared.Contains(definition))
                throw new InvalidOperationException(
                    "The requested member is not an original definition published in this catalog.");
            var sourceScope = RequireActualTypeKey(actualInstanceScope);
            do
            {
                if (!typeDefinitions.TryGetValue(sourceScope, out var ancestorDefinition))
                    throw new InvalidOperationException("Original ancestor TypeDef has not been published: " +
                                                        sourceScope);
                // Physical declarations remain on the explicit original actor base even when
                // the profile selects a genuine derived actor for forward construction.
                var qualifiedScope = sourceTypes.TryGetValue(sourceScope, out var declaredActualScope)
                    ? declaredActualScope
                    : GetActualSourceType(ancestorDefinition.AssemblyIdentity, ancestorDefinition.Identity);
                if (qualifiedScope == null)
                    throw new InvalidOperationException("Original ancestor has no qualified actual scope: " +
                                                        sourceScope);
                if (!ReferenceEquals(RequireActualTypeDefinition(qualifiedScope), ancestorDefinition))
                    throw new InvalidOperationException(
                        "Original ancestor has a different qualified actual source identity: " + sourceScope);
                if (bindings.TryGetValue(qualifiedScope, out var scoped)
                    && scoped.TryGetValue(definition.Identity, out var binding))
                {
                    if (!qualifiedScope.IsAssignableFrom(actualInstanceScope))
                        throw new InvalidOperationException(
                            "Original ancestor binding does not belong to the actual inheritance chain: " +
                            sourceScope);
                    return binding;
                }

                if (!baseTypes.TryGetValue(sourceScope, out sourceScope)) break;
            } while (sourceScope != null);

            throw new InvalidOperationException("Source member has no qualified physical binding in actual scope "
                                                + actualInstanceScope.FullName + ": " + definition.QualifiedName);
        }

        private static bool MatchesFlags(SourceMemberDefinition definition, BindingFlags flags)
        {
            return (flags & (definition.IsStatic ? BindingFlags.Static : BindingFlags.Instance)) != 0
                   && (flags & (definition.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic)) != 0;
        }

        private bool MatchesReflectionFlags(Type actualType, SourceMemberDefinition definition, BindingFlags flags)
        {
            return MatchesReflectionFlags(RequireActualTypeKey(actualType), definition, flags);
        }

        private static bool MatchesReflectionFlags(string lookupTypeKey, SourceMemberDefinition definition,
            BindingFlags flags)
        {
            if (!MatchesFlags(definition, flags)) return false;
            var inherited = lookupTypeKey != TypeKey(definition.AssemblyIdentity, definition.DeclaringTypeIdentity);
            if (!inherited) return true;
            if (definition.Kind == SourceMemberKind.Field)
            {
                var access = (FieldAttributes)definition.Attributes & FieldAttributes.FieldAccessMask;
                if (access == FieldAttributes.Private || access == FieldAttributes.PrivateScope) return false;
                if (definition.IsStatic)
                    return (flags & BindingFlags.FlattenHierarchy) != 0
                           && (access == FieldAttributes.Public || access == FieldAttributes.Family
                                                                || access == FieldAttributes.FamORAssem ||
                                                                access == FieldAttributes.FamANDAssem);
                return true;
            }

            if (!IsInheritedAccessor(definition.GetterAttributes, definition.IsStatic)
                && !IsInheritedAccessor(definition.SetterAttributes, definition.IsStatic)) return false;
            return !definition.IsStatic || (flags & BindingFlags.FlattenHierarchy) != 0;
        }

        private static bool IsInheritedAccessor(int attributes, bool isStatic)
        {
            if (attributes < 0) return false;
            var access = (MethodAttributes)attributes & MethodAttributes.MemberAccessMask;
            if (access == MethodAttributes.Private || access == MethodAttributes.PrivateScope) return false;
            return !isStatic || access == MethodAttributes.Public || access == MethodAttributes.Family
                   || access == MethodAttributes.FamORAssem || access == MethodAttributes.FamANDAssem;
        }

        public SourcePhysicalMemberBinding GetFieldInfo(Type actualType, string name,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                 BindingFlags.Static,
            bool logFailure = false)
        {
            return GetRecursiveMember(actualType, name, SourceMemberKind.Field, flags, logFailure);
        }

        public SourcePhysicalMemberBinding GetPropertyInfo(Type actualType, string name,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                 BindingFlags.Static,
            bool logFailure = false)
        {
            return GetRecursiveMember(actualType, name, SourceMemberKind.Property, flags, logFailure);
        }

        private SourcePhysicalMemberBinding GetRecursiveMember(Type actualType, string name,
            SourceMemberKind kind, BindingFlags flags, bool logFailure)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var currentType = RequireActualTypeKey(actualType);
            do
            {
                var searchType = currentType;
                do
                {
                    if (!typeDefinitions.ContainsKey(searchType))
                        throw new InvalidOperationException("Original base type metadata has not been published: " +
                                                            searchType);
                    SourceMemberDefinition match = null;
                    if (definitions.TryGetValue(searchType, out var list))
                        foreach (var definition in list)
                        {
                            if (definition.Kind != kind || !string.Equals(definition.Name, name,
                                    (flags & BindingFlags.IgnoreCase) != 0
                                        ? StringComparison.OrdinalIgnoreCase
                                        : StringComparison.Ordinal)) continue;
                            if (!MatchesReflectionFlags(currentType, definition, flags)) continue;
                            if (match != null) throw new AmbiguousMatchException("Ambiguous source member: " + name);
                            match = definition;
                        }

                    if (match != null) return RequireBinding(actualType, match);
                    if ((flags & BindingFlags.DeclaredOnly) != 0 ||
                        !baseTypes.TryGetValue(searchType, out searchType)) break;
                } while (searchType != null);

                // This is the original helper's next Type.GetField/GetProperty call,
                // even when its flags contain DeclaredOnly. Keep the original root
                // instance scope so composition-based actors borrow their real fields.
                if (!baseTypes.TryGetValue(currentType, out currentType)) break;
            } while (currentType != null);

            if (logFailure) diagnostics.MissingMember(actualType, GetOriginalTypeFullName(actualType), name, kind);
            return null;
        }

        public SourcePhysicalMemberBinding Require(Type actualType, string name, SourceMemberKind kind,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                 BindingFlags.Static)
        {
            return GetMember(actualType, name, kind, flags) ??
                   throw new MissingMemberException(GetOriginalTypeFullName(actualType), name);
        }

        public SourcePhysicalMemberBinding GetMember(Type actualType, string name, SourceMemberKind kind,
            BindingFlags flags, bool logFailure = false)
        {
            var key = RequireActualTypeKey(actualType);
            do
            {
                SourceMemberDefinition match = null;
                if (definitions.TryGetValue(key, out var list))
                    foreach (var definition in list)
                    {
                        if (definition.Kind != kind || !string.Equals(definition.Name, name,
                                (flags & BindingFlags.IgnoreCase) != 0
                                    ? StringComparison.OrdinalIgnoreCase
                                    : StringComparison.Ordinal)) continue;
                        if (!MatchesReflectionFlags(actualType, definition, flags)) continue;
                        if (match != null) throw new AmbiguousMatchException("Ambiguous source member: " + name);
                        match = definition;
                    }

                if (match != null) return RequireBinding(actualType, match);

                if ((flags & BindingFlags.DeclaredOnly) != 0 || !baseTypes.TryGetValue(key, out key)) break;
            } while (key != null);

            if (logFailure) diagnostics.MissingMember(actualType, GetOriginalTypeFullName(actualType), name, kind);
            return null;
        }
    }
}
