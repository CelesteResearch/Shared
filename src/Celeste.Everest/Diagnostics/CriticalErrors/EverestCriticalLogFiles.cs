using System;
using System.IO;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public static class EverestCriticalLogFiles
    {
        public static void AmendLogFile(EverestLoggerProcess logger, string logFile, string description,
            Exception error)
        {
            try
            {
                using var writer = new StreamWriter(logFile, true);
                writer.WriteLine();
                writer.WriteLine(
                    ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> AMENDED INFORMATION <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                writer.WriteLine();
                writer.WriteLine("Encountered an additional error after the initial crash: " + description);
                writer.WriteLine("!!!!!!!!!!!!!!!!!!!! THIS IS NOT THE MAIN CRASH! !!!!!!!!!!!!!!!!!!!!");
                writer.WriteLine($"Exception: {error}");
                logger.CriticalLogAmended(logFile);
            }
            catch (Exception exception)
            {
                logger.Log(EverestLogLevel.Error, "crit-error-handler", "Error amending log file:");
                logger.LogDetailed(exception, "crit-error-handler");
            }
        }
    }
}
