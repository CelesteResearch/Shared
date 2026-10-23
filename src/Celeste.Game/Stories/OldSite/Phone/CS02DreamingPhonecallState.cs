using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Decoration.Wires;
using Celeste.Game.Entities.Payphones;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.OldSite.Phone
{
    public class CS02DreamingPhonecallState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private BadelineDummyPresentation evil;

        private readonly RoomPlayerSession player;

        private OriginalPayphoneState payphone;

        private SoundSourceComponentState ringtone;

        public CS02DreamingPhonecallState(ISourceEngineContext engine, RoomPlayerSession player)
            : base(engine, false)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            payphone =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalPayphoneState>("Celeste.Payphone");
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
            OwnedComponents.Add(ringtone = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            ringtone.Position = payphone.Position;
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Data.Dashes = 1;
            yield return 0.3f;
            ringtone.Play("event:/game/02_old_site/sequence_phone_ring_loop");
            while (player.Light.Alpha > 0f)
            {
                player.Light.Alpha -= engine.DeltaTime * 2f;
                yield return null;
            }

            yield return 3.2f;
            yield return player.DummyWalkTo(payphone.X - 24f);
            yield return 1.5f;
            player.Data.Facing = -1;
            yield return 1.5f;
            player.Data.Facing = 1;
            yield return 0.25f;
            yield return player.DummyWalkTo(payphone.X - 4f);
            yield return 1.5f;
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.43f, delegate { ringtone.Param("end", 1f); });
            player.Visible = false;
            Process.AudioSession.Play("event:/game/02_old_site/sequence_phone_pickup", player.Position,
                Process.SaveContext);
            yield return payphone.Sprite.PlayRoutine("pickUp");
            yield return 1f;
            if (level.Session.Mode == 0) Process.AudioSession.SetMusic("event:/music/lvl2/phone_loop");

            payphone.Sprite.Play("talkPhone");
            yield return TextboxState.Say("CH2_DREAM_PHONECALL", engine, ShowShadowMadeline);
            if (evil != null)
            {
                if (level.Session.Mode == 0) Process.AudioSession.SetMusic("event:/music/lvl2/phone_end");

                evil.Vanish();
                evil = null;
                yield return 1f;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, WireFalls()));
            payphone.Broken = true;
            level.Shake(0.2f);
            var light =
                new VertexLightState(engine, new(16f, -28f), PackedColor.White, 0f, 32, 48);
            payphone.OwnedComponents.Add(light);
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null,
                2f,
                true);
            tween.OnUpdate = delegate(SourceTweenState t) { light.Alpha = t.Eased; };
            OwnedComponents.Add(tween);
            Process.AudioSession.Play("event:/game/02_old_site/sequence_phone_transform", payphone.Position,
                Process.SaveContext);
            yield return payphone.Sprite.PlayRoutine("transform");
            yield return 0.4f;
            yield return payphone.Sprite.PlayRoutine("eat");
            payphone.Sprite.Play("monsterIdle");
            yield return 1.2f;
            level.EndCutscene();
            new FadeWipePresentation(level, false, delegate { EndCutscene(level); });
        }

        private IEnumerator ShowShadowMadeline()
        {
            var payphone =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalPayphoneState>("Celeste.Payphone");
            var level = Scene as OriginalLevelSceneRoot;
            yield return level.ZoomTo(new(240f, 116f), 2f, 0.5f);
            evil = BadelineDummyPresentation.Create(level, payphone.Position + new Vector2(32f, -24f));
            evil.Appear(level);
            level.Scheduler.QueueSourceEntity(evil);
            yield return 0.2f;
            payphone.Blink.X += 1f;
            yield return payphone.Sprite.PlayRoutine("jumpBack");
            yield return payphone.Sprite.PlayRoutine("scare");
            yield return 1.2f;
        }

        private IEnumerator WireFalls()
        {
            yield return 0.5f;
            var wire = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<OriginalWireState>();
            var speed = Vector2.Zero;
            var level = (OriginalLevelSceneRoot)Scene;
            while (wire != null && wire.Curve.Begin.X < level.Bounds.Right)
            {
                speed += new Vector2(0.7f, 1f) * 200f * engine.DeltaTime;
                wire.Curve.Begin += speed * engine.DeltaTime;
                yield return null;
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            OriginalStrawberryTransfer.StoreStrawberries(player.Leader);
            level.ResetZoom();
            level.Bloom.Base = 0f;
            level.RemoveEntity(player);
            level.UnloadLevel();
            level.Session.Dreaming = false;
            level.Session.Level = "end_0";
            level.Session.RespawnPoint = level.GetSpawnPoint(new(level.Bounds.Left, level.Bounds.Bottom));
            level.Session.Audio.Music.Event = "event:/music/lvl2/awake";
            level.Session.Audio.Ambience.Event = "event:/env/amb/02_awake";
            level.LoadLevel(PlayerIntroType.WakeUp);
            level.EndCutscene();
            OriginalStrawberryTransfer.RestoreStrawberries(level.Scheduler.Entities
                .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName)
                .Leader);
        }
    }
}
