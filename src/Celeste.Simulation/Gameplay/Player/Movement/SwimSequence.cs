using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.State;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public sealed class SwimSequence
    {
        private readonly PlayerState data;
        private readonly IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly ISourceEngineContext engine;

        public ISourceEngineContext EngineContext => engine;
        public ISwimWorld World { get; }

        private ISourceExtremaArithmetic Extrema =>
            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private readonly DashSequence dash;

        public SwimSequence(PlayerState data,
            IPlayerAssistSettings settings,
            ISourceGameInput input, SimulationStateMachine machine,
            DashSequence dash,
            ISwimWorld world,
            ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.dash = dash;
            World = world;
            machine.SetCallbacks(3, Update, begin: Begin);
        }

        public void Begin()
        {
            if (data.Motion.Normal.Speed.Y > 0f) data.Motion.Normal.Speed.Y *= .5f;
            data.Stamina = 110f;
        }

        public int Update()
        {
            if (!World.SwimCheck()) return 0;
            if (World.CanUnDuck) data.Motion.Ducking = false;
            if (dash.CanDash)
            {
                // SwimUpdate enters the dash directly: it does not call StartDash,
                // decrement Dashes, or change wasDashB.
                data.DemoDashed = input.CrouchDashPressed;
                input.Dash.ConsumeBuffer();
                input.CrouchDash.ConsumeBuffer();
                return 2;
            }

            var underwater = World.SwimUnderwaterCheck();
            ref var speed = ref data.Motion.Normal.Speed;
            if (!underwater && speed.Y >= 0f && input.GrabCheck && !data.IsTired && World.CanUnDuck &&
                Math.Sign(speed.X) != -data.Facing && World.ClimbCheck(data.Facing))
            {
                if (settings.NoGrabbing)
                {
                    data.ClimbTriggerDirection = data.Facing;
                }
                else if (!World.MoveVExact(-1))
                {
                    data.Motion.Ducking = false;
                    return 1;
                }
            }

            var direction = ((ISourceVectorEnvironment)engine)
                .VectorArithmetic.SafeNormalize(input.Feather.Value);
            var maxX = underwater ? 60f : 80f;
            var deltaTime = input.DeltaTime;
            var accelerationX = Math.Abs(speed.X) > 80f && Math.Sign(speed.X) == Math.Sign(direction.X) ? 400f : 600f;
            speed.X = ScalarMath.Approach(speed.X, maxX * direction.X,
                accelerationX * deltaTime, Extrema);
            if (direction.Y == 0f && World.SwimRiseCheck())
            {
                speed.Y = ScalarMath.Approach(speed.Y, -60f, 600f * deltaTime,
                    Extrema);
            }
            else if (direction.Y >= 0f || World.SwimUnderwaterCheck())
            {
                var accelerationY = Math.Abs(speed.Y) > 80f && Math.Sign(speed.Y) == Math.Sign(direction.Y)
                    ? 400f
                    : 600f;
                speed.Y = ScalarMath.Approach(speed.Y, 80f * direction.Y,
                    accelerationY * deltaTime, Extrema);
            }

            if (!underwater && data.MoveX != 0 && World.SolidAt(Vector2.UnitX * data.MoveX) &&
                !World.SolidAt(new(data.MoveX, -3))) World.ClimbHop();
            if (input.Jump.Pressed && World.SwimJumpCheck())
            {
                World.Jump();
                return 0;
            }

            return 3;
        }
    }
}
