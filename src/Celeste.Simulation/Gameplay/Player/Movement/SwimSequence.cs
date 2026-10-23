using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public sealed class SwimSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;
        public ISwimWorld World => world;

        private global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic Extrema =>
            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Movement.ISwimWorld world;

        public SwimSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input, global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Movement.ISwimWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(3, Update, begin: Begin);
        }

        public void Begin()
        {
            if (data.Motion.Normal.Speed.Y > 0f) data.Motion.Normal.Speed.Y *= .5f;
            data.Stamina = 110f;
        }

        public int Update()
        {
            if (!world.SwimCheck()) return 0;
            if (world.CanUnDuck) data.Motion.Ducking = false;
            if (dash.CanDash)
            {
                // SwimUpdate enters the dash directly: it does not call StartDash,
                // decrement Dashes, or change wasDashB.
                data.DemoDashed = input.CrouchDashPressed;
                input.Dash.ConsumeBuffer();
                input.CrouchDash.ConsumeBuffer();
                return 2;
            }

            bool underwater = world.SwimUnderwaterCheck();
            ref var speed = ref data.Motion.Normal.Speed;
            if (!underwater && speed.Y >= 0f && input.GrabCheck && !data.IsTired && world.CanUnDuck &&
                Math.Sign(speed.X) != -data.Facing && world.ClimbCheck(data.Facing))
            {
                if (settings.NoGrabbing) data.ClimbTriggerDirection = data.Facing;
                else if (!world.MoveVExact(-1))
                {
                    data.Motion.Ducking = false;
                    return 1;
                }
            }

            Vector2 direction = ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine)
                .VectorArithmetic.SafeNormalize(input.Feather.Value);
            float maxX = underwater ? 60f : 80f;
            float deltaTime = input.DeltaTime;
            float accelerationX = Math.Abs(speed.X) > 80f && Math.Sign(speed.X) == Math.Sign(direction.X) ? 400f : 600f;
            speed.X = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.X, maxX * direction.X,
                accelerationX * deltaTime, Extrema);
            if (direction.Y == 0f && world.SwimRiseCheck())
                speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, -60f, 600f * deltaTime,
                    Extrema);
            else if (direction.Y >= 0f || world.SwimUnderwaterCheck())
            {
                float accelerationY = Math.Abs(speed.Y) > 80f && Math.Sign(speed.Y) == Math.Sign(direction.Y)
                    ? 400f
                    : 600f;
                speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, 80f * direction.Y,
                    accelerationY * deltaTime, Extrema);
            }

            if (!underwater && data.MoveX != 0 && world.SolidAt(Vector2.UnitX * data.MoveX) &&
                !world.SolidAt(new Vector2(data.MoveX, -3))) world.ClimbHop();
            if (input.Jump.Pressed && world.SwimJumpCheck())
            {
                world.Jump();
                return 0;
            }

            return 3;
        }
    }
}
