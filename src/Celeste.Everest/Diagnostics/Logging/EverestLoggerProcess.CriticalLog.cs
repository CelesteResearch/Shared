namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void CriticalLogAmended(string logFile)
        {
            if (shouldLog("crit-error-handler", EverestLogLevel.Info))
                LogUnchecked(EverestLogLevel.Info, "crit-error-handler",
                    "Amended backed up log file '" + logFile +
                    "' after encountering an additional error after the initial crash");
        }
    }
}
