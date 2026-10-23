using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Launch
{
    public sealed class LaunchSequence
    {
        private readonly PlayerState data;
        private readonly SpecialPlayerState special;
        private readonly ISourceGameInput input;
        private readonly ISourceEngineContext engine;
        private readonly DashSequence dash;
        private readonly ILaunchWorld world;

        public LaunchSequence(PlayerState data,
            SpecialPlayerState special, ISourceGameInput input,
            SimulationStateMachine machine,
            DashSequence dash,
            ILaunchWorld world,
            ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.special = special;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(7, Update, begin: Begin);
        }

        public void Begin()
        {
            data.Motion.Launched = true;
        }

        public int Update()
        {
            var dt = input.DeltaTime;
            if (special.LaunchApproachX.HasValue) world.MoveTowardsX(special.LaunchApproachX.Value, 60 * dt);
            if (dash.CanDash) return dash.Start();
            if (input.GrabCheck && !data.IsTired && !data.Motion.Ducking && world.TryPickup()) return 8;
            ref var speed = ref data.Motion.Normal.Speed;
            speed.Y = ScalarMath.Approach(speed.Y, 160, (speed.Y < 0 ? 450 : 225) * dt,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            speed.X = ScalarMath.Approach(speed.X, 0, 200 * dt,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            return (float)Math.Sqrt(speed.X * speed.X + speed.Y * speed.Y) < 220 ? 0 : 7;
        }
    }
}
