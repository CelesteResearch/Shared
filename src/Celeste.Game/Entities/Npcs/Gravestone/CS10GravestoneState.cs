using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Gravestone
{
    public class CS10GravestoneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly OriginalGravestoneState gravestone;

        private BadelineDummyPresentation badeline;

        private BirdNpcState bird;

        private readonly Vector2 boostTarget;

        private bool addedBooster;

        public CS10GravestoneState(ISourceEngineContext engine, RoomPlayerSession player,
            OriginalGravestoneState gravestone, Vector2 boostTarget)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.gravestone = gravestone;
            this.boostTarget = boostTarget;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene()));
        }

        private IEnumerator Cutscene()
        {
            player.Machine.State = 11;
            player.ForceCameraUpdate = true;
            player.Dummy.Gravity = false;
            player.Data.Motion.Normal.Speed.Y = 0f;
            yield return 0.1f;
            yield return player.DummyWalkToExact((int)gravestone.X - 30);
            yield return 0.1f;
            player.Data.Facing = 1;
            yield return 0.2f;
            yield return Level.ZoomTo(new(160f, 90f), 2f, 3f);
            player.ForceCameraUpdate = false;
            yield return 0.5f;
            yield return TextboxState.Say("CH9_GRAVESTONE", engine, StepForward, BadelineAppears, SitDown);
            yield return 1f;
            yield return BirdStuff();
            yield return BadelineRejoin();
            yield return 0.1f;
            yield return Level.ZoomBack(0.5f);
            yield return 0.3f;
            addedBooster = true;
            Level.Displacement.AddBurst(boostTarget, 0.5f, 8f, 32f, 0.5f);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/new_content/char/badeline/booster_first_appear", boostTarget);
            Level.Scheduler.QueueSourceEntity(new BadelineBoostState(engine, [boostTarget],
                false));
            yield return 0.2f;
            EndCutscene(Level);
        }

        private IEnumerator StepForward()
        {
            yield return player.DummyWalkTo(player.X + 8f);
        }

        private IEnumerator BadelineAppears()
        {
            Level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            var vector = SourceVector2Math.Add(player.Position, new(-12f, -10f));
            Level.Displacement.AddBurst(vector, 0.5f, 8f, 32f, 0.5f);
            Level.Scheduler.QueueSourceEntity(badeline = BadelineDummyPresentation.Create(Level, vector));
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/badeline/maddy_split", vector);
            badeline.Sprite.Scale.X = 1f;
            yield return badeline.FloatTo(SourceVector2Math.Add(vector, new(0f, -6f)), 1, false);
        }

        private IEnumerator SitDown()
        {
            yield return 0.2f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("sitDown");
            yield return 0.3f;
        }

        private IEnumerator BirdStuff()
        {
            bird = BirdNpcState.Create(Level, SourceVector2Math.Add(player.Position, new(88f, -200f)),
                BirdNpcMode.None);
            bird.DisableFlapSfx = true;
            Level.Scheduler.QueueSourceEntity(bird);
            var instance =
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/bird_in",
                    bird.Position);
            bird.Facing = -1;
            bird.Sprite.Play("fall");
            var from = bird.Position;
            var to = SourceVector2Math.Add(gravestone.Position, new(1f, -16f));
            var percent = 0f;
            while (percent < 1f)
            {
                bird.Position = SourceVector2Math.Add(from,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(to, from),
                        ((ISourceEasingEnvironment)engine).EasingArithmetic.QuadOut(percent)));
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Position(instance, bird.Position);
                if (percent > 0.5f) bird.Sprite.Play("fly");

                percent += engine.DeltaTime * 0.5f;
                yield return null;
            }

            bird.Position = to;
            bird.Sprite.Play("idle");
            yield return 0.5f;
            bird.Sprite.Play("croak");
            yield return 0.6f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/bird_squawk",
                bird.Position);
            yield return 0.9f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/madeline/stand", player.Position);
            player.Sprite.Play("idle");
            yield return 1f;
            yield return bird.StartleAndFlyAway();
        }

        private IEnumerator BadelineRejoin()
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/new_content/char/badeline/maddy_join_quick",
                badeline.Position);
            var from = badeline.Position;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 0.25f)
            {
                badeline.Position = Vector2Interpolation.Lerp(from, player.Position,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            Level.Displacement.AddBurst(player.Center, 0.5f, 8f, 32f, 0.5f);
            Level.Session.Inventory.Dashes = 2;
            player.Data.Dashes = 2;
            badeline.RemoveSelf();
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Data.Facing = 1;
            player.Dummy.AutoAnimate = true;
            player.Dummy.Gravity = true;
            player.Machine.State = 0;
            Level.Session.Inventory.Dashes = 2;
            player.Data.Dashes = 2;
            if (badeline != null) badeline.RemoveSelf();

            if (bird != null) bird.RemoveSelf();

            if (!addedBooster)
                level.Scheduler.QueueSourceEntity(new BadelineBoostState(engine, [boostTarget],
                    false));

            level.ResetZoom();
        }
    }
}
