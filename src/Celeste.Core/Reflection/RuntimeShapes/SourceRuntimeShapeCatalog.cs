using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.RuntimeShapes
{
    public sealed class SourceRuntimeShapeCatalog
    {
        private sealed class ShapeSet
        {
            internal bool ExplicitBirth;
            internal readonly List<SourceTypeDefinition> Elements = new List<SourceTypeDefinition>();
        }

        private readonly SourceMemberCatalog members;
        private readonly GenericParameterAttributes enumerableVariance;

        private readonly Dictionary<string, SourceTypeDefinition> targetDefinitions =
            new Dictionary<string, SourceTypeDefinition>(StringComparer.Ordinal);

        private long targetBindingRevision = -1;
        private int targetDefinitionCount = -1;
        private readonly ConditionalWeakTable<object, ShapeSet> shapes = new ConditionalWeakTable<object, ShapeSet>();

        public SourceRuntimeShapeCatalog(SourceMemberCatalog members)
        {
            this.members = members ?? throw new ArgumentNullException(nameof(members));
            var enumerable = members.GetOriginalTypeDefinition(typeof(IEnumerable<>));
            if (enumerable.GenericParameters == null || enumerable.GenericParameters.Count != 1
                                                     || enumerable.GenericParameters[0].Position != 0)
                throw new InvalidOperationException(
                    "The actual original enumerable generic parameter metadata must be published before runtime shapes.");
            enumerableVariance = (GenericParameterAttributes)enumerable.GenericParameters[0].Attributes
                                 & GenericParameterAttributes.VarianceMask;
        }

        public void RegisterOriginalEnumerable(object actualCollection, string originalElementAssemblyIdentity,
            string originalElementQName)
            => Register(actualCollection,
                members.GetOriginalTypeDefinition(originalElementAssemblyIdentity, originalElementQName), true);

        public void RegisterOriginalEnumerable(object actualCollection, Type actualElementType)
        {
            if (!members.ContainsSourceType(actualElementType))
                throw new InvalidOperationException(
                    "An enumerable source element type must have its qualified original binding: " + actualElementType);
            Register(actualCollection, members.GetOriginalTypeDefinition(actualElementType), true);
        }

        private void Register(object actualCollection, SourceTypeDefinition element, bool explicitBirth)
        {
            if (actualCollection == null) throw new ArgumentNullException(nameof(actualCollection));
            if (!(actualCollection is IEnumerable))
                throw new ArgumentException("Only an actual enumerable object can retain an enumerable source shape.",
                    nameof(actualCollection));
            var set = shapes.GetValue(actualCollection, _ => new ShapeSet());
            lock (set.Elements)
            {
                if (explicitBirth && set.Elements.Count != 0
                                  && (set.Elements.Count != 1 || !SameType(set.Elements[0], element)))
                    throw new InvalidOperationException(
                        "An actual collection birth cannot change its original closed enumerable shape.");
                if (set.ExplicitBirth && set.Elements.Count != 0 && !SameType(set.Elements[0], element))
                    throw new InvalidOperationException(
                        "A native interface cannot replace a registered original collection birth.");
                set.ExplicitBirth |= explicitBirth;
                foreach (var existing in set.Elements)
                    if (SameType(existing, element))
                    {
                        if (existing.MetadataToken != element.MetadataToken)
                            throw new InvalidOperationException(
                                "A repeated source shape cannot replace the original element definition.");
                        return;
                    }

                set.Elements.Add(element);
            }
        }

        public bool IsOriginalEnumerableOf(object actualValue, string originalElementQName)
        {
            if (actualValue == null) return false;
            if (originalElementQName == null) throw new ArgumentNullException(nameof(originalElementQName));
            if (!(actualValue is IEnumerable)) return false;
            if (!shapes.TryGetValue(actualValue, out var set))
            {
                // The closed CLR generic interface is a property of this object, including when it is empty.
                // Only registered original element types qualify. In particular List<object> is never inferred from contents.
                foreach (var actualInterface in actualValue.GetType().GetInterfaces())
                    if (actualInterface.IsGenericType &&
                        actualInterface.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        var actualElement = actualInterface.GetGenericArguments()[0];
                        if (members.ContainsSourceType(actualElement))
                            Register(actualValue, members.GetOriginalTypeDefinition(actualElement), false);
                    }

                if (!shapes.TryGetValue(actualValue, out set)) return false;
            }

            var target = RequireTarget(originalElementQName);
            lock (set.Elements)
                foreach (var element in set.Elements)
                {
                    if (SameType(target, element)) return true;
                    if (enumerableVariance == GenericParameterAttributes.Covariant
                        && IsReferenceType(element) &&
                        IsAssignable(target, element, new HashSet<string>(StringComparer.Ordinal)))
                        return true;
                }

            return false;
        }

        private SourceTypeDefinition RequireTarget(string identity)
        {
            lock (targetDefinitions)
            {
                long bindings = members.ActualTypeBindingsRevision;
                int definitions = members.OriginalTypeDefinitionCount;
                if (bindings != targetBindingRevision || definitions != targetDefinitionCount)
                {
                    targetDefinitions.Clear();
                    targetBindingRevision = bindings;
                    targetDefinitionCount = definitions;
                }

                if (targetDefinitions.TryGetValue(identity, out var cached)) return cached;
                SourceTypeDefinition result = null;
                foreach (var actual in members.OriginalTypeNames)
                {
                    var definition = members.GetOriginalTypeDefinition(actual.Key);
                    if (definition.Identity != identity &&
                        definition.Identity + ", " + definition.AssemblyIdentity != identity) continue;
                    if (result != null && !SameType(result, definition))
                        throw new InvalidOperationException(
                            "The original enumerable element name is ambiguous; retain its assembly scope: " +
                            identity);
                    result = definition;
                }

                if (result == null)
                    throw new InvalidOperationException(
                        "The original enumerable target has no qualified actual type binding: " + identity);
                targetDefinitions.Add(identity, result);
                return result;
            }
        }

        private static bool SameType(SourceTypeDefinition left, SourceTypeDefinition right)
            => left.Identity == right.Identity && left.AssemblyIdentity == right.AssemblyIdentity;

        private SourceTypeDefinition RequireDefinition(string assembly, string identity)
            => members.GetOriginalTypeDefinition(assembly, identity);

        private bool IsReferenceType(SourceTypeDefinition type)
        {
            if (((TypeAttributes)type.Attributes & TypeAttributes.Interface) != 0) return true;
            var visited = new HashSet<string>(StringComparer.Ordinal);
            while (type != null)
            {
                if (!visited.Add(type.AssemblyIdentity + "\n" + type.Identity))
                    throw new InvalidOperationException("Original source base metadata contains a cycle.");
                var sourceValueType = members.GetOriginalTypeDefinition(typeof(ValueType));
                var sourceEnum = members.GetOriginalTypeDefinition(typeof(Enum));
                if ((type.BaseAssemblyIdentity == sourceValueType.AssemblyIdentity &&
                     type.BaseTypeIdentity == sourceValueType.Identity)
                    || (type.BaseAssemblyIdentity == sourceEnum.AssemblyIdentity &&
                        type.BaseTypeIdentity == sourceEnum.Identity)) return false;
                if (type.BaseTypeIdentity == null) return true;
                type = RequireDefinition(type.BaseAssemblyIdentity, type.BaseTypeIdentity);
            }

            return true;
        }

        private bool IsAssignable(SourceTypeDefinition target, SourceTypeDefinition candidate, HashSet<string> visited)
        {
            if (SameType(target, candidate)) return true;
            if (!visited.Add(candidate.AssemblyIdentity + "\n" + candidate.Identity)) return false;
            if (((TypeAttributes)target.Attributes & TypeAttributes.Interface) != 0)
                for (int i = 0; i < candidate.Interfaces.Count; i++)
                {
                    if (candidate.InterfaceAssemblyIdentities == null)
                        throw new InvalidOperationException(
                            "Original source interface assembly scopes have not been published.");
                    if (IsAssignable(target,
                            RequireDefinition(candidate.InterfaceAssemblyIdentities[i], candidate.Interfaces[i]),
                            visited)) return true;
                }

            return candidate.BaseTypeIdentity != null
                   && IsAssignable(target,
                       RequireDefinition(candidate.BaseAssemblyIdentity, candidate.BaseTypeIdentity),
                       visited);
        }
    }
}
