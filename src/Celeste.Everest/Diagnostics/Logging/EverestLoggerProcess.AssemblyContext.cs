namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        internal void LogAssemblyContextUnchecked(EverestLogLevel level, string tag, string text) =>
            LogUnchecked(level, tag, text);
    }
}
