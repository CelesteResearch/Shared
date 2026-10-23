using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Celeste.Everest.Runtime.Events;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private EverestGameEventsProcess GameEvents => ((IEverestGameEventsEnvironment)SourceEngine).GameEvents;
        private SourceEverestFileProxyProcess FileProxy => ((ISourceEverestFileProxyEnvironment)SourceEngine).FileProxy;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)SourceEngine).Logger;

        public override void Load()
        {
            GameEvents.OnExiting += FileProxy.DeleteDummy;
            GameEvents.OnCreateButtons += CreateMainMenuButtons;
            GameEvents.OnCreatePauseMenuButtons += CreatePauseMenuButtons;
            InstallSourceNLuaHooks();
            InstallSourceTileGridRenderClipHook();
            InstallSourceCrystalSpinnerConnectionHook();
            InstallSourceSpikeAttachmentBounds();
            InstallSourceCommittedEntityRemoval();
            if (((IEverestStartupRuntimeEnvironment)SourceEngine).EverestRuntime.CompatibilityMode ==
                EverestCompatMode.LegacyXNA)
                InstallSourceLegacyXNATickHook();
            foreach (KeyValuePair<string, EverestLogLevel> level in Settings.LogLevels)
                Logger.SetLogLevelFromSettings(level.Key, level.Value);
            if (!Directory.Exists("LogHistory")) return;
            int keep = Math.Max(Settings.LogHistoryCountToKeep, 0);
            List<string> files = Directory.GetFiles("LogHistory", "log_*.txt").ToList();
            files.Sort(new SourceLogRotationHelper.OldestFirst());
            int count = files.Count - keep;
            foreach (string file in files.Take(count))
            {
                Logger.VerboseCoreLogHistory(keep, file);
                File.Delete(file);
            }
        }

        public override void Unload()
        {
            GameEvents.OnExiting -= FileProxy.DeleteDummy;
            GameEvents.OnCreateButtons -= CreateMainMenuButtons;
            GameEvents.OnCreatePauseMenuButtons -= CreatePauseMenuButtons;
            DisposeSourceCoreHooks();
        }
    }
}
