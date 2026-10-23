using System;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Core.Reflection.Interop
{
    public sealed class SourceModInteropMethodBinding
    {
        public SourceMethodDefinition Definition { get; }
        public SourceOrderedMethod Method { get; }

        public SourceModInteropMethodBinding(SourceMethodDefinition definition, SourceOrderedMethod method)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
            Method = method ?? throw new ArgumentNullException(nameof(method));
            if (definition.AssemblyIdentity != method.SourceAssemblyIdentity ||
                definition.MethodDefinitionToken != method.SourceMethodDefinitionToken)
                throw new ArgumentException(
                    "Original method facts and actual owner must identify the same source method.");
        }
    }
}
