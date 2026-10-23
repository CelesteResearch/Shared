using System;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Menus.Overworld;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private bool ExecuteUserChoice(UserChoice choice)
        {
            if (process.Logger.GetLogLevel("crit-error-handler") <= EverestLogLevel.Info)
                process.Logger.Log(EverestLogLevel.Info, "crit-error-handler",
                    "Executing user choice " + Enum.GetName(typeof(UserChoice), choice));
            bool shouldLog;
            try
            {
                OriginalSaveDataState instance = process.Saves.CurrentSave;
                switch (choice)
                {
                    case UserChoice.FlushSaveData:
                        if (instance != null)
                        {
                            ((IOriginalSavePreparationEnvironment)EngineContext).SavePreparation.BeforeSave(instance);
                            ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage
                                .Save<OriginalSaveDataState>(
                                    ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization
                                    .GetFilename(
                                        instance.FileSlot),
                                    ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage
                                    .Serialize(instance));
                            ((EverestUserIOProcess)((IOriginalUserIOEnvironment)EngineContext).UserIO)
                                .ForceSerializeModSave();
                        }

                        hasFlushedSaveData = true;
                        shouldLog = true;
                        return shouldLog;
                    case UserChoice.RetryLevel:
                        if (Session == null)
                        {
                            process.Logger.Log(EverestLogLevel.Warn, "crit-error-handler",
                                "Can't retry as no session is present!");
                            shouldLog = false;
                            return shouldLog;
                        }

                        EngineContext.Frame.Scenes.NextScene =
                            ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(Session);
                        break;
                    case UserChoice.SaveAndQuit:
                        if (Session == null || instance == null)
                        {
                            process.Logger.Log(EverestLogLevel.Warn, "crit-error-handler",
                                "Can't save-and-quit as either session or save data is not present!");
                            shouldLog = false;
                            return shouldLog;
                        }

                        Session.InArea = true;
                        ((IOriginalSavePreparationEnvironment)EngineContext).SavePreparation.BeforeSave(instance);
                        ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Save<OriginalSaveDataState>(
                            ((IOriginalSaveInitializationEnvironment)EngineContext).SaveInitialization.GetFilename(
                                instance.FileSlot),
                            ((IOriginalUserIOStorageEnvironment)EngineContext).UserIOStorage.Serialize(instance));
                        ((EverestUserIOProcess)((IOriginalUserIOEnvironment)EngineContext).UserIO)
                            .ForceSerializeModSave();
                        EngineContext.Frame.Scenes.NextScene =
                            ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                                OverworldStartMode.MainMenu);
                        break;
                    case UserChoice.ReturnToMainMenu:
                        EngineContext.Frame.Scenes.NextScene =
                            ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                                OverworldStartMode.MainMenu);
                        break;
                }
            }
            catch (Exception ex)
            {
                process.Logger.Log(EverestLogLevel.Error, "crit-error-handler", "Error while executing user choice:");
                process.Logger.LogDetailed(ex, "crit-error-handler");
                process.AmendLogFile(LogFile,
                    "Error while executing user choice " + Enum.GetName(typeof(UserChoice), choice), ex);
                shouldLog = false;
                return shouldLog;
            }

            process.ResetErrorHandler();
            return true;
        }
    }
}
