using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;

namespace Celeste.Game.Entities.Platforms.SwapBlocks.Motion
{
    public static partial class SwapBlockMotion
    {
        public static float AdvanceSpeedAndProgress<TState>(TState state, bool accelerateForward)
            where TState : struct, ISwapBlockProgressState
        {
            if (state.Target == 1 || accelerateForward)
            {
                state.Speed = ScalarMath.Approach(state.Speed, state.MaxForwardSpeed,
                    state.MaxForwardSpeed / 0.2f * state.Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            }
            else
            {
                state.Speed = ScalarMath.Approach(state.Speed, state.MaxBackwardSpeed,
                    System.BitConverter.Int32BitsToSingle(
                        System.BitConverter.SingleToInt32Bits(state.MaxBackwardSpeed / 1.5f)) * state.Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            }

            float num = state.Lerp;
            state.Lerp = ScalarMath.Approach(state.Lerp, state.Target, state.Speed * state.Engine.DeltaTime,
                ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            return num;
        }
    }
}
