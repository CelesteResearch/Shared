using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering.Renderers;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Levels.Transitions;
using Celeste.Game.Presentation.Hud.Strawberries;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Hud.Overlays;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Simulation.Presentation.PostProcessing.Glitch;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : SourceSceneState, IOverlayHandler,
        ISourceComponentIndexScene,
        ILevelScreenWipeScene,
        ISourceEngineContextScene, ISceneCutsceneState,
        ISourceSceneTime,
        IPlayerDeathLevel
    {
        public bool InCutscene
        {
            get => Cutscene.InCutscene;
            set => Cutscene.InCutscene = value;
        }

        public void ClearInCutscene()
        {
            Cutscene.InCutscene = false;
        }

        public SceneUpdateScheduler Scheduler => SourceScene;
        public SceneClock Clock => SourceScene.Clock;
        public CameraState Camera;
        public OriginalLevelCutsceneState Cutscene { get; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public OriginalLevelCutscenePolicy CutscenePolicy { get; private set; }

        public OverlayPresentation Overlay { get; set; }
        public ScreenWipePresentation Wipe { get; set; }

        ISceneRenderer ILevelScreenWipeScene.
            Wipe
        {
            get => Wipe;
            set => Wipe = (ScreenWipePresentation)value;
        }

        public PlayerDeathPresentation RetryPlayerCorpse;

        PlayerDeathPresentation
            IPlayerDeathLevel.RetryPlayerCorpse
        {
            get => RetryPlayerCorpse;
            set => RetryPlayerCorpse = value;
        }

        public ChapterCompletionSession Session { get; set; }
        public LevelGlitchState Glitch { get; }


        public Vector2 Wind;

        private TotalStrawberriesDisplayState strawberriesDisplay;

        public void WipeOut(Action onComplete)
        {
            DoScreenWipe(false, onComplete);
        }

        public OriginalLevelSceneRoot(ISourceEngineContext engineContext)
            : base(engineContext,
                ((ISourceSceneCatalogEnvironment)engineContext).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engineContext).LevelScenePolicy)
        {
            TransitionSequence = new(this,
                ((IOriginalLevelTransitionEnvironment)engineContext).LevelTransitionPolicy);
            InitializeSourcePlayerCamera();
            Glitch =
                new(
                    engineContext.Effects);
            ColorGrade =
                new(
                    this);
            Cutscene = new(this);
            CutscenePolicy =
                new(Cutscene);
        }
    }
}
