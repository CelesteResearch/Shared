namespace Celeste.Core.Scheduling
{
    public static class SourceRuntimeExtensions
    {
        public static T Get<T>(object environment) where T : class
            => environment is T extension
                ? extension
                : (environment as ISourceRuntimeExtensionEnvironment)?.GetRuntimeExtension<T>();
    }
}
