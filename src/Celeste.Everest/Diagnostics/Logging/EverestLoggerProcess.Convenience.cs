namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void Verbose(string tag, string text)
        {
            Log(EverestLogLevel.Verbose, tag, text);
        }

        public void Debug(string tag, string text)
        {
            Log(EverestLogLevel.Debug, tag, text);
        }

        public void Info(string tag, string text)
        {
            Log(EverestLogLevel.Info, tag, text);
        }

        public void Warn(string tag, string text)
        {
            Log(EverestLogLevel.Warn, tag, text);
        }

        public void Error(string tag, string text)
        {
            Log(EverestLogLevel.Error, tag, text);
        }

        public void Log(string tag, string text)
        {
            Verbose(tag, text);
        }

        public void LogDetailed(string tag, string text)
        {
            LogDetailed(EverestLogLevel.Verbose, tag, text);
        }
    }
}
