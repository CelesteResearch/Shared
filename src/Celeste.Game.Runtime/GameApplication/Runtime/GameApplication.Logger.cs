using System;
using System.IO;
using Celeste.Core.IO.Console;
using Celeste.Everest;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Diagnostics.Logging;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestLoggerProcessEnvironment, IEverestLoggerEnvironment
    {
        private EverestLoggerProcess sourceEverestLogger;
        private TextWriter sourceLogFile;
        private TextWriter sourceLogConsole;

        public EverestLoggerProcess Logger => sourceEverestLogger ??
                                              throw new InvalidOperationException(
                                                  "The actual installed logger is not constructed.");

        EverestCoreSettings IEverestLoggerEnvironment.Settings =>
            (EverestCoreSettings)sourceCoreModule?._Settings;

        public TextWriter SourceConsoleOutput => sourceLogConsole ?? PhysicalIO.ConsoleOutput;

        TextWriter IEverestLoggerEnvironment.ConsoleWriter => SourceConsoleOutput;
        ISourceConsoleModeIO IEverestLoggerEnvironment.ConsoleModes => PhysicalIO.ConsoleModes;

        public void ConstructSourceInstalledLogger()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException(
                    "The installed logger is only constructed in the installed source profile.");
            if (sourceEverestLogger != null)
                throw new InvalidOperationException("The actual installed logger is already constructed.");
            sourceLogFile = TextWriter.Synchronized(PhysicalIO.ErrorLog.OpenWriter(
                Path.Combine(PhysicalIO.SavePaths.ApplicationBaseDirectory, "log.txt"), false));
            sourceLogConsole = new SourceLogTeeWriter(PhysicalIO.ConsoleOutput, sourceLogFile);
            sourceEverestLogger = new(this);
            sourceEverestLogger.PublishColorizedWriters(PhysicalIO.ConsoleOutput, sourceLogFile);
        }

        internal void BindSourceLogLifetime()
        {
            if (sourceLogFile != null) ActualGame.Disposed += DisposeSourceLog;
        }

        public void WriteSourceExceptionToLog(Exception error)
        {
            if (sourceLogFile == null) return;
            sourceLogFile.WriteLine(error.ToString());
            sourceLogFile.Flush();
        }

        private void DisposeSourceLog(object sender, EventArgs args)
        {
            DisposeSourceLog();
        }

        private void DisposeSourceLog()
        {
            var log = sourceLogFile;
            sourceLogFile = null;
            sourceLogConsole = null;
            sourceEverestLogger?.PublishColorizedWriters(null, null);
            log?.Dispose();
        }
    }
}
