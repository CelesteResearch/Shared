using System;
using System.Runtime.InteropServices;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void WriteSourceInstalledBootDiagnostics()
        {
            var logger = ((IEverestLoggerProcessEnvironment)this).Logger;
            var message = logger.BeginEnabledMessage("core", EverestLogLevel.Info);
            if (message.ShouldLog) message.Write("Booting Everest");
            message = logger.BeginEnabledMessage("core", EverestLogLevel.Info);
            if (message.ShouldLog) message.Write("AppDomain: " + (AppDomain.CurrentDomain.FriendlyName ?? "???"));
            message = logger.BeginEnabledMessage("core", EverestLogLevel.Info);
            if (message.ShouldLog) message.Write("VersionCelesteString: " + EverestRuntime.VersionCelesteString);
            message = logger.BeginEnabledMessage("core", EverestLogLevel.Info);
            if (message.ShouldLog)
                message.Write("SystemMemoryMB: " + EverestRuntime.SystemMemoryMB.ToString("F3") + " MB");
            message = logger.BeginEnabledMessage("core", EverestLogLevel.Info);
            if (message.ShouldLog) message.Write("RuntimeVersion: " + Environment.Version);
        }

        private void EnableSourceBootColorizedLogging()
        {
            var logger = ((IEverestLoggerProcessEnvironment)this).Logger;
            if (((global::Celeste.Everest.EverestCoreSettings)ActualCoreModule._Settings).ColorizedLogging &&
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                !logger.TryEnableWindowsVTSupport())
            {
                var message = logger.BeginEnabledMessage("core", EverestLogLevel.Error);
                if (message.ShouldLog) message.Write("Failed to enable Windows VT support!");
            }
        }
    }
}
