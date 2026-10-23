using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Launch
{
    public sealed class LaunchSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState special;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Launch.ILaunchWorld world;

        public LaunchSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState special, ISourceGameInput input,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Launch.ILaunchWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.special = special;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(7, Update, begin: Begin);
        }

        public void Begin() => data.Motion.Launched = true;

        public int Update()
        {
            float dt = input.DeltaTime;
            if (special.LaunchApproachX.HasValue) world.MoveTowardsX(special.LaunchApproachX.Value, 60 * dt);
            if (dash.CanDash) return dash.Start();
            if (input.GrabCheck && !data.IsTired && !data.Motion.Ducking && world.TryPickup()) return 8;
            ref var speed = ref data.Motion.Normal.Speed;
            speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, 160, (speed.Y < 0 ? 450 : 225) * dt,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            speed.X = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.X, 0, 200 * dt,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            return (float)Math.Sqrt(speed.X * speed.X + speed.Y * speed.Y) < 220 ? 0 : 7;
        }
    }
}
