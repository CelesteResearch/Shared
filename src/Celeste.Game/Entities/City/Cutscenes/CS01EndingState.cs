using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.City.Cutscenes
{
    public class CS01EndingState : OriginalCutsceneEntityState
    {
        private readonly RoomPlayerSession player;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ISourceSpatialAudio Audio => ((ISourceSpatialAudioEnvironment)engine).SpatialAudio;

        private OriginalBonfireState bonfire;

        public CS01EndingState(ISourceEngineContext engine, RoomPlayerSession player)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            bonfire = level.SourceScene.Entities.GetTrackedEntity<OriginalBonfireState>("Celeste.Bonfire");
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Data.Dashes = 1;
            level.Session.Audio.Music.Layer(3, false);
            OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
            yield return 0.5f;
            yield return player.DummyWalkTo(bonfire.X + 40f);
            yield return 1.5f;
            player.Data.Facing = -1;
            yield return 0.5f;
            yield return TextboxState.Say("CH1_END", engine, EndCityTrigger);
            yield return 0.3f;
            EndCutscene(level);
        }

        private IEnumerator EndCityTrigger()
        {
            yield return 0.2f;
            yield return player.DummyWalkTo(bonfire.X - 12f);
            yield return 0.2f;
            player.Data.Facing = 1;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("duck");
            yield return 0.5f;
            if (bonfire != null) bonfire.SetMode(OriginalBonfireState.Mode.Lit);

            yield return 1f;
            player.Sprite.Play("idle");
            yield return 0.4f;
            player.Dummy.AutoAnimate = true;
            yield return player.DummyWalkTo(bonfire.X - 24f);
            yield return 0.4f;
            player.Dummy.AutoAnimate = false;
            player.Data.Facing = 1;
            player.Sprite.Play("sleep");
            Audio.Play("event:/char/madeline/campfire_sit", player.Position);
            yield return 4f;
            var bird = BirdNpcState.Create(Level, player.Position + new Vector2(88f, -200f), BirdNpcMode.None);
            Level.SourceScene.QueueSourceEntity(bird);
            var instance = Audio.Play("event:/game/general/bird_in", bird.Position);
            bird.Facing = -1;
            bird.Sprite.Play("fall");
            var from = bird.Position;
            var to = player.Position + new Vector2(1f, -12f);
            var percent = 0f;
            while (percent < 1f)
            {
                bird.Position =
                    from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.QuadOut(percent);
                Audio.Position(instance, bird.Position);
                if (percent > 0.5f) bird.Sprite.Play("fly");

                percent += engine.DeltaTime * 0.5f;
                yield return null;
            }

            bird.Position = to;
            bird.Sprite.Play("idle");
            yield return 0.5f;
            bird.Sprite.Play("croak");
            yield return 0.6f;
            Audio.Play("event:/game/general/bird_squawk", bird.Position);
            yield return 0.9f;
            bird.Sprite.Play("sleep");
            yield return null;
            yield return 2f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.CompleteArea();
        }
    }
}
