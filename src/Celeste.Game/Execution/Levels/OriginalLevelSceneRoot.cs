using System;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Hud.Overlays;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : global::Celeste.Scene.Scenes.SourceSceneState, IOverlayHandler,
        global::Celeste.Core.Components.ISourceComponentIndexScene,
        global::Celeste.Scene.Rendering.ILevelScreenWipeScene,
        global::Celeste.Core.Scheduling.ISourceEngineContextScene, global::Celeste.Scene.Lifecycle.ISceneCutsceneState,
        global::Celeste.Core.Scheduling.ISourceSceneTime,
        global::Celeste.Simulation.Presentation.Player.Death.IPlayerDeathLevel
    {
        public bool InCutscene
        {
            get => Cutscene.InCutscene;
            set => Cutscene.InCutscene = value;
        }

        public void ClearInCutscene() => Cutscene.InCutscene = false;
        public SceneUpdateScheduler Scheduler => SourceScene;
        public SceneClock Clock => SourceScene.Clock;
        public global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState Camera;
        public global::Celeste.Game.Execution.Levels.Cutscenes.OriginalLevelCutsceneState Cutscene { get; }

        public global::Celeste.Game.Execution.Levels.Cutscenes.OriginalLevelCutscenePolicy CutscenePolicy
        {
            get;
            private set;
        }

        public OverlayPresentation Overlay { get; set; }
        public global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation Wipe { get; set; }

        global::Celeste.Core.Rendering.Renderers.ISceneRenderer global::Celeste.Scene.Rendering.ILevelScreenWipeScene.
            Wipe
        {
            get => Wipe;
            set => Wipe = (global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation)value;
        }

        public global::Celeste.Simulation.Presentation.Player.Death.PlayerDeathPresentation RetryPlayerCorpse;

        global::Celeste.Simulation.Presentation.Player.Death.PlayerDeathPresentation
            global::Celeste.Simulation.Presentation.Player.Death.IPlayerDeathLevel.RetryPlayerCorpse
        {
            get => RetryPlayerCorpse;
            set => RetryPlayerCorpse = value;
        }

        public global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession Session { get; set; }
        public global::Celeste.Simulation.Presentation.PostProcessing.Glitch.LevelGlitchState Glitch { get; }


        public System.Numerics.Vector2 Wind;

        private global::Celeste.Game.Presentation.Hud.Strawberries.TotalStrawberriesDisplayState
            strawberriesDisplay;

        public void WipeOut(Action onComplete)
            => DoScreenWipe(false, onComplete);

        public OriginalLevelSceneRoot(global::Celeste.Core.Scheduling.ISourceEngineContext engineContext)
            : base(engineContext,
                ((global::Celeste.Scene.Tracking.ISourceSceneCatalogEnvironment)engineContext).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engineContext).LevelScenePolicy)
        {
            TransitionSequence = new Transitions.OriginalLevelTransitionSequence(this,
                ((Transitions.IOriginalLevelTransitionEnvironment)engineContext).LevelTransitionPolicy);
            InitializeSourcePlayerCamera();
            Glitch =
                new global::Celeste.Simulation.Presentation.PostProcessing.Glitch.LevelGlitchState(
                    engineContext.Effects);
            ColorGrade =
                new global::Celeste.Game.Presentation.PostProcessing.ColorGrading.OriginalLevelColorGradeState(
                    this);
            Cutscene = new global::Celeste.Game.Execution.Levels.Cutscenes.OriginalLevelCutsceneState(this);
            CutscenePolicy =
                new global::Celeste.Game.Execution.Levels.Cutscenes.OriginalLevelCutscenePolicy(Cutscene);
        }
    }
}
