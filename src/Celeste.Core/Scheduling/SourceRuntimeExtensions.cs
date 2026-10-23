using System.Diagnostics.CodeAnalysis;

namespace Celeste.Core.Scheduling
{
    public static class SourceRuntimeExtensions
    {
        [return: MaybeNull]
        public static T Get<T>(object environment) where T : class
        {
            return environment is T extension
                ? extension
                : (environment as ISourceRuntimeExtensionEnvironment)?.GetRuntimeExtension<T>();
        }
    }
}
