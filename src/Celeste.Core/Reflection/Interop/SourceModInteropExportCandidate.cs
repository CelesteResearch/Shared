using System.Reflection;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Core.Reflection.Interop
{
    internal sealed class SourceModInteropExportCandidate
    {
        internal SourceMethodDefinition SourceDefinition { get; }
        internal MethodInfo ActualMethod { get; }
        internal object ActualOwner { get; }

        internal SourceModInteropExportCandidate(MethodInfo actualMethod, object actualOwner,
            SourceMethodDefinition sourceDefinition = null)
        {
            ActualMethod = actualMethod;
            ActualOwner = actualOwner;
            SourceDefinition = sourceDefinition;
        }
    }
}
