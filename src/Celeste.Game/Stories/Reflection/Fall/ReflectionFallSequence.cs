using System.Collections;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Game.Stories.Reflection.Fall
{
    public sealed class ReflectionFallSequence
    {
        private readonly PlayerState data;
        private readonly GameInput input;
        private readonly SimulationStateMachine machine;
        private readonly IReflectionFallWorld world;

        public ReflectionFallSequence(PlayerState data,
            GameInput input, SimulationStateMachine machine,
            IReflectionFallWorld world)
        {
            this.data = data;
            this.input = input;
            this.machine = machine;
            this.world = world;
            machine.SetCallbacks(18, Update, Coroutine, Begin, End);
        }

        public void Begin()
        {
            world.IgnoreJumpThrus = true;
        }

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
                ? ScalarMath.Approach(speed.Y, -20, 400 * input.Context.DeltaTime)
                : ScalarMath.Approach(speed.Y, 320, 225 * input.Context.DeltaTime);
            world.RemoveAllFeathers();
            var position = world.Position;
            var spinner =
                world.FirstSpinnerAt(
                    new((int)(position.X - 6), (int)(position.Y - 6), 12, 12));
            if (spinner != null)
            {
                spinner.Destroy();
                world.Shake();
                world.Rumble(ReflectionFallRumble.SpinnerImpact);
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
            world.Rumble(ReflectionFallRumble.WaterEntry);
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
                var bounds = world.RoomBounds;
                world.SetRespawnPoint(world.GetSpawnPoint(new(bounds.X, bounds.Bottom)));
                world.LoadLevelWithoutIntro();
                world.ShowFallEffects(false);
                world.SetMusic("event:/music/lvl6/main");
                world.ApplySessionAudio();
            });
        }
    }
}
