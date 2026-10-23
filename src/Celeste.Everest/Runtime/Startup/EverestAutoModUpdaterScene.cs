using System.Collections;
using System.Threading.Tasks;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Runtime.Startup
{
    public partial class EverestAutoModUpdaterScene : SourceSceneState
    {
        private readonly HiresSnowState snow;
        private readonly AtlasEntry cogwheel;
        private bool cogwheelSpinning = true;
        private float cogwheelStopTime;
        private string modUpdatingMessage;
        private string modUpdatingSubMessage;
        private bool confirmToRestart;
        private bool confirmToContinue;
        private bool shouldContinue;
        private bool showCancel;
        private bool skipUpdate;

        public EverestAutoModUpdaterScene(ISourceEngineContext engine, HiresSnowState snow)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.snow = snow;
            cogwheel =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                    "reloader/cogwheel"];
        }

        public override void Begin()
        {
            base.Begin();
            ((IEverestLoaderProcessEnvironment)EngineContext).Loader.AutoLoadNewMods = false;
            Renderers.Add(new HudRendererState());
            Renderers.Add(snow);
            Renderers.UpdateLists();
            var entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)EngineContext).EntitySourceDataRegistration);
            entity.Components.Add(new SimulationCoroutine(EngineContext, Routine()));
            SourceScene.QueueSourceEntity(entity);
        }

        public override void End()
        {
            base.End();
            ((IEverestLoaderProcessEnvironment)EngineContext).Loader.AutoLoadNewMods = true;
        }

        private IEnumerator Routine()
        {
            modUpdatingMessage =
                ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_CHECKING");
            showCancel = true;
            while (!((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.IsAsyncUpdateCheckingDone() &&
                   !skipUpdate)
                yield return null;
            showCancel = false;
            if (!skipUpdate)
            {
                var updates =
                    ((IEverestModUpdaterEnvironment)EngineContext).ModUpdater.GetAsyncLoadedModUpdates();
                if (updates == null || updates.Count == 0)
                {
                    modUpdatingMessage = null;
                    shouldContinue = true;
                }
                else
                {
                    new Task(delegate { AutoUpdate(updates); }).Start();
                }

                while (!shouldContinue) yield return null;
            }

            EngineContext.Frame.Scenes.NextScene =
                ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                    OverworldStartMode.Titlescreen, snow);
        }

        public override void Update()
        {
            base.Update();
            if (((ISourceGameInputEnvironment)EngineContext).Input[GameAction.MenuConfirm].Pressed)
            {
                if (confirmToRestart)
                {
                    ((IEverestRestartEnvironment)EngineContext).Restart.QuickFullRestart();
                    confirmToRestart = false;
                }

                if (confirmToContinue) shouldContinue = true;
            }

            if (!(((ISourceGameInputEnvironment)EngineContext).Input[GameAction.MenuCancel].Pressed && showCancel))
                return;
            skipUpdate = true;
            modUpdatingMessage =
                ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_SKIPPING");
        }
    }
}
