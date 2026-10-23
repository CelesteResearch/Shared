using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Methods
{
    public sealed partial class SourceAssemblyMethodCatalog
    {
        public IEnumerable<SourceMethodDefinition> EnumerateDeclaredDefinitions(string assemblyIdentity,
            string declaringType)
        {
            if (!assemblies.TryGetValue(assemblyIdentity, out var methods))
                throw new InvalidOperationException("The original source assembly method metadata is not published.");
            foreach (var pair in methods)
                if (pair.Value.Definition.DeclaringType == declaringType)
                    yield return pair.Value.Definition;
        }

        public IEnumerable<SourceOrderedMethod> GetMethods(SourceMemberCatalog members, Type actualSourceType,
            BindingFlags flags)
        {
            foreach (var entry in EnumerateOriginalMethods(members, actualSourceType, flags))
                yield return RequireActual(entry);
        }

        public IEnumerable<SourceOrderedMethod> GetMethods(SourceMemberCatalog members, Type actualSourceType,
            BindingFlags flags, string name, Type[] actualParameterTypes = null)
        {
            foreach (var entry in EnumerateOriginalMethods(members, actualSourceType, flags))
            {
                var definition = entry.Definition;
                if (definition.Name != name) continue;
                if (actualParameterTypes != null)
                {
                    if (definition.ParameterTypeIdentities.Count != actualParameterTypes.Length) continue;
                    bool matches = true;
                    for (int index = 0; index < actualParameterTypes.Length; index++)
                    {
                        var parameter = actualParameterTypes[index];
                        if (parameter == null) continue;
                        string identity = members.ContainsSourceType(parameter)
                            ? members.GetOriginalTypeFullName(parameter)
                            : parameter.Assembly == typeof(object).Assembly
                                ? parameter.FullName
                                : throw new InvalidOperationException(
                                    "The query parameter type has no qualified original identity.");
                        if (identity != definition.ParameterTypeIdentities[index])
                        {
                            matches = false;
                            break;
                        }
                    }

                    if (!matches) continue;
                }

                yield return RequireActual(entry);
            }
        }

        private static SourceOrderedMethod RequireActual(Entry entry)
            => entry.Actual ?? throw new InvalidOperationException(
                "The original method has no qualified actual implementation: "
                + entry.Definition.DeclaringType + "." + entry.Definition.Name);

        private IEnumerable<Entry> EnumerateOriginalMethods(SourceMemberCatalog members, Type actualSourceType,
            BindingFlags flags)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            var type = members.GetOriginalTypeDefinition(actualSourceType);
            var hidden = new HashSet<string>(StringComparer.Ordinal);
            var hiddenNames = new HashSet<string>(StringComparer.Ordinal);
            bool inherited = false;
            while (type != null)
            {
                if (!assemblies.TryGetValue(type.AssemblyIdentity, out var methods))
                    throw new InvalidOperationException(
                        "The original source assembly method metadata is not published.");
                var currentSignatures = new HashSet<string>(StringComparer.Ordinal);
                var currentNames = new HashSet<string>(StringComparer.Ordinal);
                foreach (var pair in methods)
                {
                    var entry = pair.Value;
                    var method = entry.Definition;
                    if (method.DeclaringType != type.Identity || method.Name == ".ctor" ||
                        method.Name == ".cctor") continue;
                    var attributes = (MethodAttributes)method.Attributes;
                    bool isStatic = (attributes & MethodAttributes.Static) != 0;
                    var access = attributes & MethodAttributes.MemberAccessMask;
                    bool isPublic = access == MethodAttributes.Public;
                    if (isStatic ? (flags & BindingFlags.Static) == 0 : (flags & BindingFlags.Instance) == 0) continue;
                    if (isPublic ? (flags & BindingFlags.Public) == 0 : (flags & BindingFlags.NonPublic) == 0) continue;
                    if (inherited && (access == MethodAttributes.Private ||
                                      (isStatic && ((flags & BindingFlags.FlattenHierarchy) == 0 ||
                                                    access == MethodAttributes.Assembly)))) continue;
                    if (method.ParameterTypeIdentities == null)
                        throw new InvalidOperationException(
                            "The original method parameter signature is not published.");
                    string signature = method.Name + "\n" + method.GenericParameterCount + "\n" +
                                       string.Join("\n", method.ParameterTypeIdentities);
                    if (hiddenNames.Contains(method.Name) || hidden.Contains(signature)) continue;
                    currentSignatures.Add(signature);
                    if ((attributes & MethodAttributes.HideBySig) == 0) currentNames.Add(method.Name);
                    yield return entry;
                }

                foreach (string signature in currentSignatures) hidden.Add(signature);
                foreach (string name in currentNames) hiddenNames.Add(name);
                if ((flags & BindingFlags.DeclaredOnly) != 0 || type.BaseTypeIdentity == null ||
                    ((flags & BindingFlags.Instance) == 0 && (flags & BindingFlags.FlattenHierarchy) == 0)) break;
                type = members.GetOriginalTypeDefinition(type.BaseAssemblyIdentity, type.BaseTypeIdentity);
                inherited = true;
            }
        }

        public SourceOrderedMethod GetMethodInfo(SourceMemberCatalog members, Type actualSourceType,
            string originalName, Type[] actualParameterTypes = null,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                 BindingFlags.Static)
        {
            Entry result = null;
            foreach (var entry in EnumerateOriginalMethods(members, actualSourceType, flags))
            {
                var definition = entry.Definition;
                if (definition.Name != originalName) continue;
                if (actualParameterTypes != null)
                {
                    if (definition.ParameterTypeIdentities.Count != actualParameterTypes.Length) continue;
                    bool matches = true;
                    for (int index = 0; index < actualParameterTypes.Length; index++)
                    {
                        var parameter = actualParameterTypes[index];
                        if (parameter == null) continue;
                        string identity = members.ContainsSourceType(parameter)
                            ? members.GetOriginalTypeFullName(parameter)
                            : parameter.Assembly == typeof(object).Assembly
                                ? parameter.FullName
                                : throw new InvalidOperationException(
                                    "The query parameter type has no qualified original identity.");
                        if (identity != definition.ParameterTypeIdentities[index])
                        {
                            matches = false;
                            break;
                        }
                    }

                    if (!matches) continue;
                }

                if (result != null) return null;
                result = entry;
            }

            return result == null ? null : RequireActual(result);
        }
    }
}
