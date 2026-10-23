using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    // Numerical phase of Player.NormalUpdate. The state machine owns input buffering,
    // contact decisions, duck/grab transitions and timer decrements before calling this phase.
    public static class NormalMotion
    {
        public static void Update(ref NormalMotionState state,
            NormalMotionContext context, float deltaTime,
            ISourceExtremaArithmetic arithmetic,
            ISourceScalarArithmetic scalarArithmetic)
        {
            UpdateHorizontal(ref state, context, deltaTime, arithmetic, scalarArithmetic);
            UpdateFallLimit(ref state, context, deltaTime, arithmetic, scalarArithmetic);
            UpdateGravityAndJump(ref state, context, deltaTime, arithmetic, scalarArithmetic);
        }

        public static void UpdateHorizontal(
            ref NormalMotionState state,
            NormalMotionContext context, float deltaTime,
            ISourceExtremaArithmetic arithmetic,
            ISourceScalarArithmetic scalarArithmetic)
        {
            if (context.Ducking && context.OnGround)
            {
                state.Speed.X =
                    ScalarMath.Approach(state.Speed.X, 0f, 500f * deltaTime,
                        arithmetic);
            }
            else
            {
                var multiplier = context.OnGround ? 1f : 0.65f;
                if (context.OnGround && context.Cold) multiplier *= 0.3f;
                if (context.LowFriction && context.LowFrictionStopTimer <= 0f)
                    multiplier *= context.OnGround ? 0.35f : 0.5f;
                float maximum;
                if (context.HoldingSlowRun)
                {
                    maximum = 70f;
                }
                else if (context.HoldingSlowFall && !context.OnGround)
                {
                    maximum = 108.00001f;
                    multiplier *= 0.5f;
                }
                else
                {
                    maximum = 90f;
                }

                if (context.InSpace) maximum *= 0.6f;
                if (Math.Abs(state.Speed.X) > maximum && Math.Sign(state.Speed.X) == context.MoveX)
                    state.Speed.X = ScalarMath.Approach(state.Speed.X,
                        maximum * context.MoveX, scalarArithmetic.Multiply(400f, multiplier, deltaTime), arithmetic);
                else
                    state.Speed.X = ScalarMath.Approach(state.Speed.X,
                        maximum * context.MoveX, scalarArithmetic.Multiply(1000f, multiplier, deltaTime), arithmetic);
            }
        }

        public static void UpdateFallLimit(
            ref NormalMotionState state,
            NormalMotionContext context, float deltaTime,
            ISourceExtremaArithmetic arithmetic,
            ISourceScalarArithmetic scalarArithmetic)
        {
            float normalFall = 160f, fastFall = 240f;

            if (context.InSpace)
            {
                normalFall *= 0.6f;
                fastFall *= 0.6f;
            }

            if (context.HoldingSlowFall && context.ForceMoveXTimer <= 0f)
            {
                var target = context.GliderMoveY == 1 ? 120f
                    : context.WindMovedUp && context.GliderMoveY == -1 ? -32f
                    : context.GliderMoveY == -1 ? 24f
                    : !context.WindMovedUp ? 40f : 0f;
                state.MaxFall =
                    ScalarMath.Approach(state.MaxFall, target, 300f * deltaTime,
                        arithmetic);
            }
            else if (context.MoveY == 1 && state.Speed.Y >= normalFall)
            {
                state.MaxFall =
                    ScalarMath.Approach(state.MaxFall, fastFall, 300f * deltaTime,
                        arithmetic);
                var midpoint = normalFall + (fastFall - normalFall) * 0.5f;
                if (state.Speed.Y >= midpoint)
                {
                    var amount = arithmetic.Min(1f, (state.Speed.Y - midpoint) / (fastFall - midpoint));
                    state.SpriteScaleX = scalarArithmetic.Lerp(1f, .5f, amount);
                    state.SpriteScaleY = scalarArithmetic.Lerp(1f, 1.5f, amount);
                }
            }
            else
            {
                state.MaxFall =
                    ScalarMath.Approach(state.MaxFall, normalFall, 300f * deltaTime,
                        arithmetic);
            }

            if (!context.OnGround && context.HoldingSlowFall) state.HoldCannotDuck = context.MoveY == 1;
        }

        public static void UpdateGravityAndJump(
            ref NormalMotionState state,
            NormalMotionContext context,
            float deltaTime, ISourceExtremaArithmetic arithmetic,
            ISourceScalarArithmetic scalarArithmetic)
        {
            if (!context.OnGround)
            {
                var target = state.MaxFall;
                // FNA MathHelper.Lerp receives a binary32 amount, calculates in
                // double, then rounds its result to float. Mono otherwise retains
                // an extended division result across the float-to-double promotion.
                // Divide in double and explicitly narrow to emit the required conv.r4;
                // this keeps the SAME managed DLL faithful in Unity and a .NET host.
                if (context.WallSliding)
                {
                    var amount = (float)(context.WallSlideTimer / (double)1.2f);
                    target = scalarArithmetic.Lerp(160f, 20f, amount);
                }

                var multiplier = Math.Abs(state.Speed.Y) < 40f && (context.JumpHeld || context.AutoJump) ? 0.5f : 1f;
                if (context.HoldingSlowFall && context.ForceMoveXTimer <= 0f) multiplier *= 0.5f;
                if (context.InSpace) multiplier *= 0.6f;
                state.Speed.Y = ScalarMath.Approach(state.Speed.Y, target,
                    scalarArithmetic.Multiply(900f, multiplier, deltaTime), arithmetic);
            }

            if (state.VariableJumpTimer > 0f)
            {
                if (context.AutoJump || context.JumpHeld)
                    state.Speed.Y = arithmetic.Min(state.Speed.Y, state.VariableJumpSpeed);
                else state.VariableJumpTimer = 0f;
            }
        }
    }
}
