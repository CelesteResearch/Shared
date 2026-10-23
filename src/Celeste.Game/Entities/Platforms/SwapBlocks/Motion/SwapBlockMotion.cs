using Celeste.Core.Display;
using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Audio;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;


namespace Celeste.Game.Entities.Platforms.SwapBlocks.Motion
{
    public static partial class SwapBlockMotion
    {
        private static string ResolveSoundPath(SourceSolidEntityState solid, string path)
            => solid is ISwapBlockSoundResolver resolver ? resolver.ResolveSwapBlockSoundPath(path) : path;

        public static void Start<TState>(TState state) where TState : struct, ISwapBlockMotionState
        {
            state.Swapping = state.Lerp < 1f;
            state.Target = 1;
            state.ReturnTimer = 0.8f;
            state.Burst =
                (state.Solid.Scene as OriginalLevelSceneRoot).Displacement.AddBurst(state.Solid.Center, 0.2f, 0f, 16f);
            if (state.Lerp >= 0.2f)
            {
                state.Speed = state.MaxForwardSpeed;
            }
            else
            {
                state.Speed = ((ISourceScalarEnvironment)state.Engine).ScalarArithmetic.Lerp(
                    state.MaxForwardSpeed * 0.333f,
                    state.MaxForwardSpeed,
                    state.Lerp / 0.2f);
            }

            ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Stop(state.ReturnSound);
            ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Stop(state.MoveSound);
            if (!state.Swapping)
            {
                ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                    ResolveSoundPath(state.Solid, "event:/game/05_mirror_temple/swapblock_move_end"),
                    state.Solid.Center);
            }
            else
            {
                state.MoveSound = ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                    ResolveSoundPath(state.Solid, "event:/game/05_mirror_temple/swapblock_move"), state.Solid.Center);
            }
        }

        public static bool Advance<TState>(TState state, out Vector2 position)
            where TState : struct, ISwapBlockMotionState
        {
            float num = AdvanceProgress(state);
            if (state.Lerp == num)
            {
                position = default;
                return false;
            }

            {
                Vector2 liftSpeed = GetInitialLiftSpeed(state);
                position = state.Solid.Position;
                liftSpeed = AdjustLiftSpeed(state, num, liftSpeed);
                if (state.Target == 1 &&
                    ((ISourceScene)state.Solid.Scene).SourceScene.Clock.OnInterval(0.02f, state.Engine))
                {
                    state.EmitMovementParticles(SourceVector2Math.Subtract(state.End, state.Start));
                }

                MoveToProgress(state, liftSpeed);
            }
            return true;
        }

        public static float AdvanceProgress<TState>(TState state) where TState : struct, ISwapBlockMotionState
        {
            if (state.Burst != null)
            {
                state.Burst.Position = state.Solid.Center;
            }

            state.RedAlpha = ScalarMath.Approach(state.RedAlpha, (state.Target != 1) ? 1 : 0,
                state.Engine.DeltaTime * 32f,
                ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            if (state.Target == 0 && state.Lerp == 0f)
            {
                state.MiddleRed.SetAnimationFrame(0);
                state.MiddleGreen.SetAnimationFrame(0);
            }

            return AdvanceSpeedAndProgress(state, false);
        }

        public static Vector2 GetInitialLiftSpeed<TState>(TState state) where TState : struct, ISwapBlockMotionState
            => SourceVector2Math.Multiply(SourceVector2Math.Subtract(state.End, state.Start), state.Speed);

        public static Vector2 AdjustLiftSpeed<TState>(TState state, float previousLerp, Vector2 initial)
            where TState : struct, ISwapBlockMotionState
        {
            if (state.Target == 1)
            {
                initial = SourceVector2Math.Multiply(SourceVector2Math.Subtract(state.End, state.Start),
                    state.MaxForwardSpeed);
            }

            if (state.Lerp < previousLerp)
            {
                initial = SourceVector2Math.Multiply(initial, -1f);
            }

            return initial;
        }

        public static void MoveToProgress<TState>(TState state, Vector2 liftSpeed)
            where TState : struct, ISwapBlockMotionState
        {
            state.Solid.MoveTo(
                Vector2Interpolation.Lerp(state.Start, state.End, state.Lerp,
                    ((ISourceScalarEnvironment)state.Engine).ScalarArithmetic),
                liftSpeed);
        }

        public static void PositionChanged<TState>(TState state) where TState : struct, ISwapBlockMotionState
        {
            ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Position(state.MoveSound, state.Solid.Center);
            ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Position(state.ReturnSound, state.Solid.Center);
            if (state.Solid.Position == state.Start && state.Target == 0)
            {
                ((IOriginalGameplayProcess)state.Engine).AudioSession.SetParameter(state.ReturnSound, "end", 1f);
                ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                    ResolveSoundPath(state.Solid, "event:/game/05_mirror_temple/swapblock_return_end"),
                    state.Solid.Center);
            }
            else if (state.Solid.Position == state.End && state.Target == 1)
            {
                ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                    ResolveSoundPath(state.Solid, "event:/game/05_mirror_temple/swapblock_move_end"),
                    state.Solid.Center);
            }
        }

        public static void Complete<TState>(TState state) where TState : struct, ISwapBlockMotionState
        {
            if (state.Swapping && state.Lerp >= 1f)
            {
                state.Swapping = false;
            }

            state.Solid.StopPlayerRunIntoAnimation = state.Lerp <= 0f || state.Lerp >= 1f;
        }

        public static void EmitMovementParticles(SourceSolidEntityState solid, ISourceEngineContext engine,
            Vector2 normal, ref float remainder)
        {
            int num2 = GetMovementParticleGeometry(solid, engine, normal, ref remainder,
                out Vector2 position, out Vector2 positionRange, out float direction);
            ((OriginalLevelSceneRoot)solid.Scene).Particles.Emit(
                ((IOriginalGameplayProcess)engine).ParticleTypes.SwapBlock.P_Move, num2, position, positionRange,
                direction);
        }

        public static int GetMovementParticleGeometry(SourceSolidEntityState solid, ISourceEngineContext engine,
            Vector2 normal, ref float remainder, out Vector2 position, out Vector2 positionRange, out float direction)
        {
            float num;
            if (normal.X > 0f)
            {
                position = solid.CenterLeft;
                positionRange = SourceVector2Math.Multiply(Vector2.UnitY, solid.Height - 6f);
                direction = (float)Math.PI;
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(2f, solid.Height / 14f);
            }
            else if (normal.X < 0f)
            {
                position = solid.CenterRight;
                positionRange = SourceVector2Math.Multiply(Vector2.UnitY, solid.Height - 6f);
                direction = 0f;
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(2f, solid.Height / 14f);
            }
            else if (normal.Y > 0f)
            {
                position = solid.TopCenter;
                positionRange = SourceVector2Math.Multiply(Vector2.UnitX, solid.Width - 6f);
                direction = -(float)Math.PI / 2f;
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(2f, solid.Width / 14f);
            }
            else
            {
                position = solid.BottomCenter;
                positionRange = SourceVector2Math.Multiply(Vector2.UnitX, solid.Width - 6f);
                direction = (float)Math.PI / 2f;
                num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(2f, solid.Width / 14f);
            }

            remainder += num;
            int num2 = (int)remainder;
            remainder -= num2;
            positionRange = SourceVector2Math.Multiply(positionRange, 0.5f);
            return num2;
        }
    }
}
