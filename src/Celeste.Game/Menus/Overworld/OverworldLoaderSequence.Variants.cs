using System;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldLoaderSequence
    {
        private void CheckVariantsPostcardAtLaunch()
        {
            if (StartMode != OverworldStartMode.Titlescreen)
                return;
            var settings = ((ISettingsContext)EngineContext).Settings;
            if (settings.VariantsUnlocked
                || (((ISettingsRuntimeContext)EngineContext).SettingsProcess.LastVersion != null
                    && !(new Version(((ISettingsRuntimeContext)EngineContext).SettingsProcess.LastVersion) <=
                         new Version(1, 2, 4, 2))))
                return;
            var storage = ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage;
            if (!storage.Open(OriginalUserIOStorage.Mode.Read))
                return;
            var source = (IOriginalSaveInitializationEnvironment)EngineContext;
            for (var i = 0; i < 3; i++)
            {
                if (!storage.Exists(source.SaveInitialization.GetFilename(i)))
                    continue;
                var saveData = storage.Load<OriginalSaveDataState>(source.SaveInitialization.GetFilename(i));
                if (saveData != null)
                {
                    source.SaveInitialization.AfterInitialize(saveData, source.SaveInitializationServices);
                    if (((IOriginalOverworldLoaderPostcardEnvironment)EngineContext).OverworldLoaderPostcards
                        .GetVariantHeartCount(saveData, EngineContext) >= 24)
                    {
                        showVariantPostcard = true;
                        break;
                    }
                }
            }

            storage.Close();
            ((IOriginalGameplayProcess)EngineContext).SaveContext.PublishCurrentSave(null);
        }
    }
}
