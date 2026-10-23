using System;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Runtime.Startup
{
    public partial class EverestGameLoaderScene
    {
        private void CheckModSaveDataBackups()
        {
            Version version;
            try
            {
                version = new Version(((IEverestCurrentCoreSettingsEnvironment)EngineContext).CurrentCoreSettings
                    .CurrentVersion);
            }
            catch
            {
                version = new Version(0, 0, 0);
            }

            if (!(version < new Version(1, 2109, 0))) return;
            var message =
                ((IEverestLoggerProcessEnvironment)EngineContext).Logger.BeginEnabledMessage("core",
                    EverestLogLevel.Verbose);
            if (message.ShouldLog)
                message.Write("User just upgraded from version " + version + ": creating mod save data backups.");
            for (int slot = 0; slot < 3; slot++)
            {
                if (((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Exists(
                        ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization.GetFilename(slot)))
                {
                    var save = ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage
                        .Load<OriginalSaveDataState>(
                            ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization
                            .GetFilename(slot),
                            false);
                    if (save != null)
                    {
                        ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization.AfterInitialize(save,
                            ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitializationServices);
                        ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Save<OriginalModSaveData>(
                            ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization.GetFilename(
                                save.FileSlot) + "-modsavedata",
                            ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Serialize(
                                new OriginalModSaveData(save)));
                    }
                }
            }

            ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Close();
            ((IOriginalGameplayProcess)EngineContext).SaveContext.PublishCurrentSave(null);
        }
    }
}
