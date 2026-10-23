using System;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Runtime.Boot;
using Celeste.Everest.Runtime.Events;
using Celeste.Everest.UI.Shutdown;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Runtime
{
    public sealed class EverestRestartProcess
    {
        private readonly ISourceEngineContext engine;
        private EverestUserIOProcess UserIO => (EverestUserIOProcess)((IOriginalUserIOEnvironment)engine).UserIO;
        private EverestCoreSettings Settings => ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;
        private SourceEverestModule Core => ((IEverestCoreModuleEnvironment)engine).CoreModule;

        public EverestRestartProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public void QuickFullRestart()
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain() || !Settings.RestartAppDomain_WIP)
            {
                SlowFullRestart();
                return;
            }

            var blackScreen = new EverestBlackScreenScene(engine);
            blackScreen.HelperEntity.Components.Add(new SimulationCoroutine(engine,
                _QuickFullRestart(engine.Frame.Scenes.CurrentScene is OverworldSequence, blackScreen)));
            engine.Frame.Scenes.NextScene = blackScreen;
        }

        private IEnumerator _QuickFullRestart(bool fromOverworld, EverestBlackScreenScene scene)
        {
            var instance = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;
            if (instance != null && instance.FileSlot ==
                ((IEverestRestartSaveEnvironment)engine).SaveModuleState.LoadedModSaveDataIndex)
            {
                if (!fromOverworld) Settings.QuickRestart = instance.FileSlot;

                ((IOriginalSavePreparationEnvironment)engine).SavePreparation.BeforeSave(instance);
                ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage.Save<OriginalSaveDataState>(
                    ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.GetFilename(instance.FileSlot),
                    ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage.Serialize(instance));
                UserIO.ForceSerializeModSave();
                if (Settings.SaveDataFlush == true) Core.ForceSaveDataFlush++;

                Core.SaveSettings();
            }

            AppDomain.CurrentDomain.SetData("EverestRestart", true);
            scene.RunAfterRender = ((IEverestApplicationExitEnvironment)engine).ApplicationLoop.Exit;
            yield break;
        }

        public void SlowFullRestart()
        {
            var blackScreen = new EverestBlackScreenScene(engine);
            blackScreen.HelperEntity.Components.Add(new SimulationCoroutine(engine,
                _SlowFullRestart(engine.Frame.Scenes.CurrentScene is OverworldSequence, blackScreen)));
            engine.Frame.Scenes.NextScene = blackScreen;
        }

        private IEnumerator _SlowFullRestart(bool fromOverworld, EverestBlackScreenScene scene)
        {
            var instance = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;
            if (instance != null && instance.FileSlot ==
                ((IEverestRestartSaveEnvironment)engine).SaveModuleState.LoadedModSaveDataIndex)
            {
                if (!fromOverworld) Settings.QuickRestart = instance.FileSlot;

                ((IOriginalSavePreparationEnvironment)engine).SavePreparation.BeforeSave(instance);
                ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage.Save<OriginalSaveDataState>(
                    ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.GetFilename(instance.FileSlot),
                    ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage.Serialize(instance));
                UserIO.ForceSerializeModSave();
                if (Settings.SaveDataFlush == true) Core.ForceSaveDataFlush++;

                Core.SaveSettings();
            }

            ((IEverestGameEventsEnvironment)engine).GameEvents.OnShutdown += delegate
            {
                ((IEverestBootProcessEnvironment)engine).BootProcess.StartCelesteProcess();
            };
            scene.RunAfterRender = delegate { ((IEverestApplicationExitEnvironment)engine).ApplicationLoop.Exit(); };
            yield break;
        }
    }
}
