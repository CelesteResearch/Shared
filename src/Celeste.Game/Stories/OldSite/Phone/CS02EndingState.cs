using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.Payphones;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Stories.OldSite.Phone
{
    public class CS02EndingState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private RoomPlayerSession player;

        private OriginalPayphoneState payphone;

        private SoundSourceComponentState phoneSfx;

        public CS02EndingState(ISourceEngineContext engine, RoomPlayerSession player)
            : base(engine, fadeInOnSkip: false, endingChapterAfter: true)
        {
            this.engine = engine;
            this.player = player;
            OwnedComponents.Add(phoneSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            payphone =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalPayphoneState>("Celeste.Payphone");
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Data.Dashes = 1;
            while (player.Light.Alpha > 0f)
            {
                player.Light.Alpha -= engine.DeltaTime * 1.25f;
                yield return null;
            }

            yield return 1f;
            yield return player.DummyWalkTo(payphone.X - 4f);
            yield return 0.2f;
            player.Data.Facing = 1;
            yield return 0.5f;
            player.Visible = false;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/02_old_site/sequence_phone_pickup",
                player.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            yield return payphone.Sprite.PlayRoutine("pickUp");
            yield return 0.25f;
            phoneSfx.Position = player.Position;
            phoneSfx.Play("event:/game/02_old_site/sequence_phone_ringtone_loop");
            yield return 6f;
            phoneSfx.Stop();
            payphone.Sprite.Play("talkPhone");
            yield return TextboxState.Say("CH2_END_PHONECALL", engine);
            yield return 0.3f;
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.CompleteArea();
        }
    }
}
