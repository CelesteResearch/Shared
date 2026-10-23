using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using EventInstance = Celeste.Audio.Fmod.Events.FmodEventReference;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using LockBlock = Celeste.Game.Entities.Doors.LockBlocks.OriginalLockBlockState;
using Booster = Celeste.Game.Entities.Interaction.Boosters.OriginalBoosterState;

namespace Celeste.Game.Stories.Farewell.Hub
{
    public class OriginalHubIntroCutscene : OriginalCutsceneEntityState
    {
        internal static Type BirdRuntimeType => typeof(Bird);

        private class Bird : SceneEntityState
        {
            private readonly Sprite sprite;

            public EventInstance sfx;

            private readonly ISourceEngineContext engine;

            public Bird(ISourceEngineContext engine, Vector2 position) : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
            {
                this.engine = engine;
                Position = position;
                Depth = -8500;
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("bird"));
                sprite.Play("hover");
                sprite.OnFrameChange = delegate { BirdNpcState.FlapSfxCheck(engine, sprite); };
            }

            public IEnumerator IdleRoutine()
            {
                yield return 0.5f;
            }

            public IEnumerator FlyAwayRoutine()
            {
                var level = Scene as Level;
                sfx = ((IOriginalGameplayProcess)engine).AudioSession.Play(
                    "event:/new_content/game/10_farewell/bird_fly_uptonext", Position,
                    ((IOriginalGameplayProcess)engine).SaveContext);
                sprite.Play("flyup");
                var spd = -32f;
                while (Y > level.Bounds.Top - 32)
                {
                    spd -= 400f * engine.DeltaTime;
                    Y += spd * engine.DeltaTime;
                    yield return null;
                }
            }
        }

        public const string Flag = "hub_intro";

        public const float BirdOffset = 190f;

        private readonly Player player;

        private readonly List<LockBlock> locks;

        private readonly Booster booster;

        private Bird bird;

        private readonly Vector2 spawn;

        private readonly List<EventInstance> sfxs = [];

        private readonly ISourceEngineContext engine;

        public OriginalHubIntroCutscene(ISourceEngineContext engine,
            SourceSceneState scene,
            Player player) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            spawn = (scene as Level).GetSpawnPoint(player.Position);
            locks = scene.SourceScene.Entities.FindAll<LockBlock>();
            locks.Sort((a, b) => (int)(a.Y - b.Y));
            foreach (var @lock in locks) @lock.Visible = false;

            booster = scene.SourceScene.Entities.FindFirst<Booster>();
            if (booster != null) booster.Visible = false;
        }

        public override void OnBegin(Level level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(Level level)
        {
            if (player.Holding.Holding != null) player.Throw();

            player.Machine.State = 11;
            player.ForceCameraUpdate = true;
            while (!player.OnGround()) yield return null;

            player.ForceCameraUpdate = false;
            yield return 0.1f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            yield return 0.25f;
            level.AddEntity(bird = new(engine, new(spawn.X, level.Bounds.Top + 190f)));
            ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/game/10_farewell/bird_camera_pan_up");
            yield return CameraTo(engine,
                new(spawn.X - 160f, level.Bounds.Top + 190f - 90f), 2f,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut);
            yield return bird.IdleRoutine();
            OwnedComponents.Add(new SimulationCoroutine(engine,
                CameraTo(engine, new(level.Camera.X, level.Bounds.Top), 0.8f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut, 0.1f)));
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 2);
            yield return bird.FlyAwayRoutine();
            bird.RemoveSelf();
            bird = null;
            yield return 0.5f;
            var duration = 6f;
            var sfx = "event:/new_content/game/10_farewell/locked_door_appear_1".Substring(0,
                "event:/new_content/game/10_farewell/locked_door_appear_1".Length - 1);
            var doorIndex = 1;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                CameraTo(engine, new(level.Camera.X, level.Bounds.Bottom - 180),
                    duration, ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut)));
            OwnedComponents.Add(new SimulationCoroutine(engine, Level.ZoomTo(new(160f, 90f), 1.5f, duration)));
            for (var t = 0f; t < duration; t += engine.DeltaTime)
            {
                foreach (var @lock in locks)
                    if (!@lock.Visible && level.Camera.Y + 90f > @lock.Y - 20f)
                    {
                        sfxs.Add(((IOriginalGameplayProcess)engine).AudioSession.Play(sfx + doorIndex, @lock.Center,
                            ((IOriginalGameplayProcess)engine).SaveContext));
                        @lock.Appear();
                        ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
                        doorIndex++;
                    }

                yield return null;
            }

            yield return 0.5f;
            if (booster != null)
            {
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);
                booster.Appear();
            }

            yield return 0.3f;
            yield return Level.ZoomBack(0.3f);
            EndCutscene(level);
        }

        public override void OnEnd(Level level)
        {
            if (WasSkipped)
            {
                foreach (var sfx in sfxs) ((IOriginalGameplayProcess)engine).AudioSession.Stop(sfx);

                if (bird != null) ((IOriginalGameplayProcess)engine).AudioSession.Stop(bird.sfx);
            }

            foreach (var @lock in locks) @lock.Visible = true;

            if (booster != null) booster.Visible = true;

            if (bird != null) bird.RemoveSelf();

            if (WasSkipped) player.Position = spawn;

            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Dummy.AutoAnimate = true;
            player.ForceCameraUpdate = false;
            player.Machine.State = 0;
            level.Camera.Y = level.Bounds.Bottom - 180;
            level.Session.SetFlag("hub_intro");
            level.ResetZoom();
        }
    }
}
