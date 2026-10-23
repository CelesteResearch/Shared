using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    // Borrowed physical MonoMod event info; Identity is the original object, not a copied registry key.
    public interface ISourceBootDetourInfo
    {
        object Identity { get; }
        SourceBootDetourKind Kind { get; }
        MethodBase Method { get; }
        MethodBase Entry { get; }
        string MethodId { get; }
        long NativeFunction { get; }
        void Undo();
    }
}
