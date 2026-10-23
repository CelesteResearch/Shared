using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Loading;
using Celeste.Game.Credits.Backdrops;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Environment;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Runtime;
using Celeste.Simulation;

namespace Celeste.Game.Credits
{
// Working source actor. Remaining source partials must close before selection.
    public sealed partial class CreditsChapterSequence : OriginalCutsceneEntityState
    {
        public const float CameraXOffset = 70f;
        public const float CameraYOffset = -24f;
        public string Event;
        private readonly ISourceEngineContext engine;
        private readonly AtlasEntry gradient;
        private CreditsPresentation credits;
        private RoomPlayerSession player;
        private bool autoWalk = true, autoUpdateCamera = true;
        private BadelineDummyPresentation badeline;
        private bool badelineAutoFloat = true, badelineAutoWalk;
        private float badelineWalkApproach;
        private Vector2 badelineWalkApproachFrom;
        private float walkOffset;
        private readonly bool wasDashAssistOn;
        private CreditsFillBackdrop fillbg;
        private float fade = 1f;
        private HiresSnowState snow;
        private bool gotoEpilogue;

        private OriginalCreditsProcessState CreditsProcess
            => ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess;

        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public CreditsChapterSequence(ISourceEngineContext engine)
            : this(engine, ((IOriginalCreditsGraphicsEnvironment)engine).GraphicsResources
                .GuiAtlas["creditsgradient"].GetSubtexture(0, 1, 1920, 1))
        {
        }

        private CreditsChapterSequence(ISourceEngineContext engine, AtlasEntry gradient)
            : base(engine)
        {
            // Preserve the derived gradient initializer read before the source base constructor.
            this.engine = engine;
            this.gradient = gradient;
            ((ISourceMInputEnvironment)engine).MInput.Disabled = true;
            CreditsProcess.Instance = this;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            wasDashAssistOn = Process.SaveContext.CurrentSave.Assists.DashAssist;
            Process.SaveContext.CurrentSave.Assists.DashAssist = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((OriginalLevelSceneRoot)Scene).InCredits = true;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            Process.AudioSession.BusMuted("bus:/gameplay_sfx", true);
            gotoEpilogue = level.Session.OldStats.Modes[0].Completed;
            gotoEpilogue = true;
            if (engine is IOriginalChapterPreparationEnvironment preparation)
                preparation.ChapterPreparation?.PrepareArea(8);
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
            OwnedComponents.Add(new ScenePostUpdateHook(PostUpdate));
        }
    }
}
