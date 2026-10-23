using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Presentation.Mountain.Characters;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Settings;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Menus.Overworld
{
// Working actual scene. Constructor and completed source partials have no host World.
    public partial class OverworldSequence : SourceSceneState
    {
        public List<OuiState> UIs = [];
        public OuiState Current;
        public OuiState Last;
        public OuiState Next;
        public bool EnteringPico8;
        public bool ShowInputUI = true;
        public bool ShowConfirmUI = true;
        internal float inputEase;
        public MountainRendererState Mountain;
        public HiresSnowState Snow;
        protected Snow3DState Snow3D;
        public Maddy3DState Maddy;
        public SceneEntityState RoutineEntity { get; }

        public bool Transitioning { get; set; }

        private int lastArea = -1;
        public IOverworldOverlay Overlay { get; set; }

        public OverworldSequence(ISourceEngineContext engine, OverworldLoaderSequence loader)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            Renderers.Add(Mountain = new(engine));
            Renderers.Add(new HudRendererState());
            SourceScene.QueueSourceEntity(RoutineEntity = new(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration));
            SourceScene.QueueSourceEntity(new OverworldInputState(this));
            Snow = loader.Snow;
            if (Snow == null)
                Snow = new(engine);
            Renderers.Add(Snow);
            Renderers.UpdateLists();
            SourceScene.QueueSourceEntity(Snow3D = new(Mountain.Model));
            SourceScene.QueueSourceEntity(new MoonParticle3DState(Mountain.Model, new(0f, 31f, 0f)));
            SourceScene.QueueSourceEntity(Maddy = new(Mountain));
            ReloadMenus(loader.StartMode);
            Mountain.OnEaseEnd = OnMountainEaseEnd;
            lastArea = Mountain.Area;
            if (Mountain.Area < 0)
                Maddy.Hide();
            else
                Maddy.Position = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Mountain.Area]
                    .MountainCursor;
            ((ISettingsContext)engine).Settings.ApplyVolumes(
                ((IOriginalGameplayProcess)engine).AudioSession);
        }

        private void OnMountainEaseEnd()
        {
            if (Mountain.Area >= 0 && (!Maddy.Show || lastArea != Mountain.Area))
            {
                Maddy.Running(Mountain.Area < 7);
                Maddy.Wiggler.Start();
            }

            lastArea = Mountain.Area;
        }
    }
}
