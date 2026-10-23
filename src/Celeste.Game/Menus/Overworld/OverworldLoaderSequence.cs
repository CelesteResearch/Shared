using System.Threading;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Entities.Postcards;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Menus.Overworld
{
// Working full-source scene. Missing source partials/capabilities are explicit in GATES.json.
    public partial class OverworldLoaderSequence : SourceSceneState
    {
        public OverworldStartMode StartMode;
        public HiresSnowState Snow;
        private bool loaded;
        protected bool fadeIn;
        protected OverworldSequence overworld;
        private PostcardState postcard;
        private bool showVariantPostcard, showUnlockCSidePostcard;
        protected Thread activeThread;

        public OverworldLoaderSequence(ISourceEngineContext engine, OverworldStartMode startMode,
            HiresSnowState snow = null)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            StartMode = startMode;
            Snow = snow == null ? new(engine) : snow;
            fadeIn = snow == null;
        }

        public override void Begin()
        {
            // Original OverworldLoader.Begin deliberately does not call Scene.Begin.
            Renderers.Add(new HudRendererState());
            Renderers.Add(Snow);
            if (fadeIn)
            {
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.Black;
                new FadeWipePresentation(this, true);
            }

            Renderers.UpdateLists();
            ChapterCompletionSession session = null;
            var saves = ((IOriginalGameplayProcess)EngineContext).SaveContext;
            if (saves.CurrentSave != null)
                session = ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection
                    .GetCurrentSessionSafe(saves.CurrentSave);
            var entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)EngineContext)
                    .EntitySourceDataRegistration);
            entity.OwnedComponents.Add(new SimulationCoroutine(EngineContext, Routine(session)));
            SourceScene.QueueSourceEntity(entity);
            activeThread = Thread.CurrentThread;
            ((IOriginalThreadEnvironment)EngineContext).Threads.SetHostThreadPriority(activeThread,
                ThreadPriority.Lowest);
            ((IOriginalThreadEnvironment)EngineContext).Threads.Start(
                LoadThread, "OVERWORLD_LOADER", true);
        }

        protected void LoadThread()
        {
            var mountain = ((IOriginalMountainEnvironment)EngineContext).MountainResources;
            var resources = (ISourceAtlasLoaderEnvironment)EngineContext;
            if (!mountain.Loaded)
                mountain.Load(resources);
            if (!mountain.DataLoaded)
                mountain.LoadData(
                    (ISourceGraphicsDeviceEnvironment)EngineContext);
            CheckVariantsPostcardAtLaunch();
            overworld = ((IOriginalOverworldEnvironment)EngineContext).Overworlds.CreateOverworld(this);
            ((ISourceScene)overworld).SourceScene.CommitQueuedEntityLists();
            loaded = true;
            ((IOriginalThreadEnvironment)EngineContext).Threads.SetHostThreadPriority(activeThread,
                ThreadPriority.Normal);
        }

        public override void BeforeRender()
        {
            base.BeforeRender();
            if (postcard != null)
                postcard.BeforeRender();
        }
    }
}
