using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Core.Reflection.Methods
{
    public sealed partial class SourceAssemblyMethodCatalog
    {
        private sealed class Entry
        {
            internal readonly SourceMethodDefinition Definition;
            internal SourceOrderedMethod Actual;
            internal ConstructorInfo ActualConstructor;
            internal Entry(SourceMethodDefinition definition) => Definition = definition;
        }

        private readonly Dictionary<string, SortedDictionary<int, Entry>> assemblies = new(StringComparer.Ordinal);

        private readonly Dictionary<MethodInfo, SourceMethodDefinition> originalMethods = new();

        public SourceMethodDefinition RequireOriginalMethodDefinition(MethodInfo actualMethod)
            => originalMethods.TryGetValue(actualMethod, out var definition)
                ? definition
                : throw new InvalidOperationException("Actual source method metadata is not bound: " + actualMethod);

        public void RegisterDefinition(SourceMethodDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            if (!assemblies.TryGetValue(definition.AssemblyIdentity, out var methods))
                assemblies.Add(definition.AssemblyIdentity, methods = new SortedDictionary<int, Entry>());
            methods.Add(definition.MethodDefinitionToken, new Entry(definition));
        }

        public void BindActualMethod(string assemblyIdentity, int methodToken, MethodInfo method, object owner)
        {
            var entry = RequireEntry(assemblyIdentity, methodToken);
            if (entry.Actual != null || entry.ActualConstructor != null)
                throw new InvalidOperationException("The original method already has an actual source binding.");
            var definition = entry.Definition;
            var actual = new SourceOrderedMethod(assemblyIdentity, definition.DeclaringType,
                definition.TypeDefinitionToken, methodToken, method, owner,
                (definition.Attributes & (int)MethodAttributes.Static) != 0);
            originalMethods.Add(method, definition);
            entry.Actual = actual;
        }

        public void BindActualConstructor(string assemblyIdentity, int methodToken, ConstructorInfo actualConstructor)
        {
            if (actualConstructor == null) throw new ArgumentNullException(nameof(actualConstructor));
            var entry = RequireEntry(assemblyIdentity, methodToken);
            if (entry.Actual != null || entry.ActualConstructor != null)
                throw new InvalidOperationException("The original method already has an actual source binding.");
            if (entry.Definition.Name != ".ctor" && entry.Definition.Name != ".cctor")
                throw new ArgumentException("An original constructor definition is required.", nameof(methodToken));
            bool sourceIsStatic = (entry.Definition.Attributes & (int)MethodAttributes.Static) != 0;
            if (sourceIsStatic != actualConstructor.IsStatic)
                throw new ArgumentException("Original and actual constructor static kinds do not match.",
                    nameof(actualConstructor));
            entry.ActualConstructor = actualConstructor;
        }

        public MethodBase RequireActualMethodBase(string assemblyIdentity, int methodToken)
        {
            var entry = RequireEntry(assemblyIdentity, methodToken);
            if (entry.ActualConstructor != null) return entry.ActualConstructor;
            return entry.Actual?.ActualMethod ?? throw new InvalidOperationException(
                "Original method has no qualified actual target: " + assemblyIdentity + "/" + methodToken);
        }

        public MethodInfo RequireActualMethod(string assemblyIdentity, int methodToken)
            => (RequireEntry(assemblyIdentity, methodToken).Actual ?? throw new InvalidOperationException(
                    "Original method has no qualified actual binding: " + assemblyIdentity + "/" + methodToken))
                .ActualMethod;

        public SourceMethodDefinition RequireDefinition(string assemblyIdentity, int methodToken)
            => RequireEntry(assemblyIdentity, methodToken).Definition;

        // PE MethodDef rows of a TypeDef are contiguous and already ordered by their source metadata row.
        // Callers supply the original aggregate assembly order; this class never uses new CLR assembly order.
        public IEnumerable<SourceMethodDefinition> EnumerateDeclaredAttributedDefinitions(
            IEnumerable<string> orderedAssemblyIdentities, string originalAttributeIdentity)
        {
            foreach (var assemblyIdentity in orderedAssemblyIdentities)
            {
                if (!assemblies.TryGetValue(assemblyIdentity, out var methods))
                    throw new InvalidOperationException(
                        "Original method metadata is not published: " + assemblyIdentity);
                foreach (var entry in methods.Values)
                    if (entry.Definition.HasDeclaredAttribute(originalAttributeIdentity))
                        yield return entry.Definition;
            }
        }

        public SourceOrderedMethod RequireActualOrderedMethod(string assemblyIdentity, int methodToken)
        {
            var entry = RequireEntry(assemblyIdentity, methodToken);
            return entry.Actual ?? throw new InvalidOperationException(
                "Actual source method is not bound: " + entry.Definition.DeclaringType + "." +
                entry.Definition.Name + " (" + entry.Definition.MethodDefinitionToken + ")");
        }

        public IEnumerable<SourceOrderedMethod> EnumerateDeclaredAttributedMethods(
            IEnumerable<string> orderedAssemblyIdentities, string originalAttributeIdentity)
        {
            foreach (var definition in EnumerateDeclaredAttributedDefinitions(orderedAssemblyIdentities,
                         originalAttributeIdentity))
                yield return RequireActualOrderedMethod(definition.AssemblyIdentity, definition.MethodDefinitionToken);
        }

        private Entry RequireEntry(string assemblyIdentity, int methodToken)
        {
            if (!assemblies.TryGetValue(assemblyIdentity, out var methods) ||
                !methods.TryGetValue(methodToken, out var entry))
                throw new InvalidOperationException("Original method metadata is not published: " + assemblyIdentity +
                                                    "/" +
                                                    methodToken);
            return entry;
        }
    }
}
