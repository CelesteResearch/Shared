using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Reflection.Fall
{
    public sealed class ReflectionFallSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly GameInput input;
        private readonly global::Celeste.Core.Scheduling.SimulationStateMachine machine;
        private readonly global::Celeste.Game.Stories.Reflection.Fall.IReflectionFallWorld world;

        public ReflectionFallSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            GameInput input, global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Game.Stories.Reflection.Fall.IReflectionFallWorld world)
        {
            this.data = data;
            this.input = input;
            this.machine = machine;
            this.world = world;
            machine.SetCallbacks(18, Update, Coroutine, Begin, End);
        }

        public void Begin() => world.IgnoreJumpThrus = true;

        public void End()
        {
            world.ShowFallEffects(false);
            world.IgnoreJumpThrus = false;
        }

        public int Update()
        {
            data.Facing = 1;
            if (world.OnInterval(.05f))
            {
                data.WasDashB = true;
                world.CreateTrail();
            }

            ref var speed = ref data.Motion.Normal.Speed;
            speed.Y = world.InWater
                ? global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, -20, 400 * input.Context.DeltaTime)
                : global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, 320, 225 * input.Context.DeltaTime);
            world.RemoveAllFeathers();
            Vector2 position = world.Position;
            var spinner =
                world.FirstSpinnerAt(
                    new global::Celeste.Core.Geometry.IntRect((int)(position.X - 6), (int)(position.Y - 6), 12, 12));
            if (spinner != null)
            {
                spinner.Destroy();
                world.Shake();
                world.Rumble(global::Celeste.Game.Stories.Reflection.Fall.ReflectionFallRumble.SpinnerImpact);
                world.Freeze(.01f);
            }

            return 18;
        }

        public IEnumerator Coroutine()
        {
            world.PlayAnimation("bigFall");
            world.StartCutscene(Skip);
            for (float time = 0; time < 2; time += input.Context.DeltaTime)
            {
                data.Motion.Normal.Speed.Y = 0;
                yield return null;
            }

            world.ShowFallEffects(true);
            data.Motion.Normal.Speed.Y = 320;
            while (!world.InWater) yield return null;
            world.Rumble(global::Celeste.Game.Stories.Reflection.Fall.ReflectionFallRumble.WaterEntry);
            world.ShowFallEffects(false);
            world.PlayAnimation("bigFallRecover");
            world.SetMusic("event:/music/lvl6/main");
            world.ApplySessionAudio();
            world.EndCutscene();
            yield return 1.2f;
            machine.State = 0;
        }

        public void Skip()
        {
            world.AtEndOfFrame(() =>
            {
                world.RemovePlayer();
                world.UnloadLevel();
                world.SetSessionRoom("00");
                global::Celeste.Core.Geometry.Bounds bounds = world.RoomBounds;
                world.SetRespawnPoint(world.GetSpawnPoint(new Vector2(bounds.X, bounds.Bottom)));
                world.LoadLevelWithoutIntro();
                world.ShowFallEffects(false);
                world.SetMusic("event:/music/lvl6/main");
                world.ApplySessionAudio();
            });
        }
    }
}
