namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void ReloadTaskError(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Error))
                LogUnchecked(EverestLogLevel.Error, "reload", "Error while executing reload task '" + text + "':");
        }

        public void ReloadTaskFinished(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload", "Finished reload task '" + text + "'");
        }

        public void ReloadTaskMoving(string previous, string next)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload",
                    "Finished reload task '" + previous + "'; moving onto task '" + next + "'");
        }

        public void ReloadTaskStarting(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload", "Starting reload task '" + text + "'");
        }

        public void ReloadDelayedByCriticalError(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Warn))
                LogUnchecked(EverestLogLevel.Warn, "reload",
                    "Delaying reload action until critical error handler is closed: " + text);
        }

        public void ReloadInvalidSilentThread(string thread, string text)
        {
            if (shouldLog("reload", EverestLogLevel.Warn))
                LogUnchecked(EverestLogLevel.Warn, "reload",
                    "Tried to silently reload on non-whitelisted thread " + thread + ": " + text);
        }

        public void SilentReloadStarting(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload", "Starting execution of silent reload action: " + text);
        }

        public void SilentReloadFinished(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload", "Finished execution of silent reload action: " + text);
        }

        public void NonSilentReloadQueued(string text)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload", "Queued non-silent reload action: " + text);
        }

        public void NonSilentReloadFinished(object scene)
        {
            if (shouldLog("reload", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "reload",
                    "Finished non-silent reload; switched back to scene " + scene);
        }

        public void CriticalHandlerCreated(string type, string message)
        {
            if (shouldLog("crit-error-handler", EverestLogLevel.Info))
                LogUnchecked(EverestLogLevel.Info, "crit-error-handler",
                    "Created critical error handler for exception " + type + ": " + message);
        }
    }
}
