using System.Diagnostics.CodeAnalysis;

namespace Celeste.Core.Scheduling
{
    public interface ISourceRuntimeExtensionEnvironment
    {
        [return: MaybeNull]
        T GetRuntimeExtension<T>() where T : class;
    }
}
