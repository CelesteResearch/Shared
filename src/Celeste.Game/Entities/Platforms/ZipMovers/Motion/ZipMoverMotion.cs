using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Game.Entities.Platforms.ZipMovers.Motion
{
    public static class ZipMoverMotion
    {
        public static Vector2 Forward(ISourceEngineContext engine, Vector2 start, Vector2 target, ref float progress,
            ref float percent)
        {
            progress = ScalarMath.Approach(progress, 1f, 2f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            return InterpolateForward(engine, start, target, progress, ref percent);
        }

        public static Vector2 ForwardAtSpeed(ISourceEngineContext engine, Vector2 start, Vector2 target,
            float speedMultiplier, ref float progress, ref float percent)
        {
            progress = ScalarMath.Approach(progress, 1f, 2f * engine.DeltaTime * speedMultiplier,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            return InterpolateForward(engine, start, target, progress, ref percent);
        }

        private static Vector2 InterpolateForward(ISourceEngineContext engine, Vector2 start, Vector2 target,
            float progress, ref float percent)
        {
            percent = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(progress);
            return Vector2Interpolation.Lerp(start, target, percent,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
        }

        public static Vector2 Backward(ISourceEngineContext engine, Vector2 target, Vector2 start, ref float progress,
            ref float percent)
        {
            progress = ScalarMath.Approach(progress, 1f, .5f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            percent = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(progress);
            return Vector2Interpolation.Lerp(target, start,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(progress),
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
        }

        public static Vector2 BackwardAtSpeed(ISourceEngineContext engine, Vector2 target, Vector2 start,
            float speedMultiplier, ref float progress,
            ref float percent)
        {
            progress = ScalarMath.Approach(progress, 1f, .5f * engine.DeltaTime * speedMultiplier,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            percent = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(progress);
            return Vector2Interpolation.Lerp(target, start,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(progress),
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
        }
    }
}
