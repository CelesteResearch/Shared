using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Stories.OldSite.DreamMirror
{
    public class OriginalMirrorCutsceneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly DreamMirrorState mirror;

        private float playerEndX;

        private int direction = 1;

        private SoundSourceComponentState sfx;

        public OriginalMirrorCutsceneState(ISourceEngineContext engine, RoomPlayerSession player,
            DreamMirrorState mirror) :
            base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.mirror = mirror;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            Add(sfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            sfx.Position = mirror.Center;
            sfx.Play("event:/music/lvl2/dreamblock_sting_pt1");
            direction = Math.Sign(player.X - mirror.X);
            player.Machine.State = 11;
            playerEndX = 8 * direction;
            yield return 1f;
            player.Data.Facing = -direction;
            yield return 0.4f;
            yield return player.Dummy.RunTo(mirror.X + playerEndX);
            yield return 0.5f;
            yield return level.ZoomTo(mirror.Position - level.Camera.Position - Vector2.UnitY * 24f, 2f, 1f);
            yield return 0.5f;
            yield return mirror.BreakRoutine(direction);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            var from = level.Camera.Position;
            var to = level.Camera.Position + new Vector2(0f, -80f);
            for (var ease = 0f; ease < 1f; ease += engine.DeltaTime * 1.2f)
            {
                level.Camera.Position =
                    from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(ease);
                yield return null;
            }

            Add(new SimulationCoroutine(engine, ZoomBack()));
            using (var enumerator =
                   Level.SourceScene.Entities.GetTrackedEntities("Celeste.DreamBlock").GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var dreamBlock = (OriginalDreamBlockState)enumerator.Current;
                    yield return dreamBlock.Activate();
                }
            }

            yield return 0.5f;
            EndCutscene(level);
        }

        private IEnumerator ZoomBack()
        {
            yield return 1.2f;
            yield return Level.ZoomBack(3f);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            mirror.Broken(WasSkipped);
            if (WasSkipped) ((OriginalLevelSceneRoot)Scene).ParticlesFG.Clear();

            var entity = Level.SourceScene.Entities.FindFirst<RoomPlayerSession>();
            if (entity != null)
            {
                entity.Machine.State = 0;
                entity.Dummy.AutoAnimate = true;
                entity.Data.Motion.Normal.Speed = Vector2.Zero;
                entity.X = mirror.X + playerEndX;
                if (direction != 0)
                    entity.Data.Facing = -direction;
                else
                    entity.Data.Facing = 1;
            }

            foreach (OriginalDreamBlockState entity2 in Level.SourceScene.Entities.GetTrackedEntities(
                         "Celeste.DreamBlock"))
                entity2.ActivateNoRoutine();

            level.ResetZoom();
            level.Session.Inventory.DreamDash = true;
            level.Session.Audio.Music.Event = "event:/music/lvl2/mirror";
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
        }
    }
}
