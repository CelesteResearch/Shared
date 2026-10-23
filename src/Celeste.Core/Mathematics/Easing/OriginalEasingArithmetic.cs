using System;

namespace Celeste.Core.Mathematics.Easing
{
    public sealed partial class OriginalEasingArithmetic : ISourceEasingArithmetic
    {
        private static readonly Func<float, float> LinearFunction = EvaluateLinear;
        private static readonly Func<float, float> SineInOutFunction = EvaluateSineInOut;
        private static readonly Func<float, float> SineOutFunction = EvaluateSineOut;
        private static readonly Func<float, float> SineInFunction = EvaluateSineIn;
        private static readonly Func<float, float> BackInFunction = EvaluateBackIn;
        private static readonly Func<float, float> BackOutFunction = SourceEasingComposition.Invert(BackInFunction);
        private static readonly Func<float, float> ElasticInFunction = EvaluateElasticIn;
        private static readonly Func<float, float> BigBackInFunction = EvaluateBigBackIn;

        private static readonly Func<float, float> BigBackOutFunction =
            SourceEasingComposition.Invert(BigBackInFunction);

        private static readonly Func<float, float> QuadInFunction = EvaluateQuadIn;
        private static readonly Func<float, float> QuadOutFunction = SourceEasingComposition.Invert(QuadInFunction);

        private static readonly Func<float, float> QuadInOutFunction =
            SourceEasingComposition.Follow(QuadInFunction, QuadOutFunction);

        private static readonly Func<float, float> CubeInFunction = EvaluateCubeIn;
        private static readonly Func<float, float> CubeInOutFunction = EvaluateCubeInOut;
        private static readonly Func<float, float> CubeOutFunction = EvaluateCubeOut;
        public Func<float, float> Linear => LinearFunction;
        public Func<float, float> QuadInOut => QuadInOutFunction;
        public Func<float, float> QuadOut => QuadOutFunction;

        public static float EvaluateLinear(float value)
        {
            return value;
        }

        public Func<float, float> SineInOut => SineInOutFunction;
        public Func<float, float> SineOut => SineOutFunction;
        public Func<float, float> SineIn => SineInFunction;
        public Func<float, float> BackIn => BackInFunction;
        public Func<float, float> BackOut => BackOutFunction;
        public Func<float, float> ElasticIn => ElasticInFunction;
        public Func<float, float> BigBackIn => BigBackInFunction;
        public Func<float, float> BigBackOut => BigBackOutFunction;
        public Func<float, float> QuadIn => QuadInFunction;
        public Func<float, float> CubeIn => CubeInFunction;
        private static readonly Func<float, float> QuintInFunction = EvaluateQuintIn;
        private static readonly Func<float, float> QuintOutFunction = SourceEasingComposition.Invert(QuintInFunction);
        public Func<float, float> QuintOut => QuintOutFunction;

        public static float EvaluateQuintIn(float value)
        {
            return value * value * value * value * value;
        }

        public Func<float, float> CubeOut => CubeOutFunction;
        public Func<float, float> CubeInOut => CubeInOutFunction;

        private static readonly Func<float, float> BounceOutFunction = EvaluateBounceOut;
        public Func<float, float> BounceOut => BounceOutFunction;

        public static float EvaluateBounceOut(float t)
        {
            if (t < .36363637f) return 7.5625f * t * t;
            if (t < .72727275f) return 7.5625f * (t - .54545456f) * (t - .54545456f) + .75f;
            return t < .90909094f
                ? 7.5625f * (t - .8181818f) * (t - .8181818f) + .9375f
                : 7.5625f * (t - 21f / 22f) * (t - 21f / 22f) + 63f / 64f;
        }

        public static float EvaluateElasticIn(float value)
        {
            var squared = value * value;
            var cubed = squared * value;
            return 33f * cubed * squared + -59f * squared * squared + 32f * cubed + -5f * squared;
        }

        public static float EvaluateSineIn(float value)
        {
            return 0f - (float)Math.Cos((float)Math.PI / 2f * value) + 1f;
        }

        public static float EvaluateSineOut(float value)
        {
            return (float)Math.Sin((float)Math.PI / 2f * value);
        }

        public static float EvaluateBackIn(float value)
        {
            return value * value * (2.70158f * value - 1.70158f);
        }

        public static float EvaluateBigBackIn(float value)
        {
            return value * value * (4f * value - 3f);
        }

        public static float EvaluateSineInOut(float value)
        {
            return (0f - (float)Math.Cos((float)Math.PI * value)) / 2f + .5f;
        }

        public static float EvaluateQuadIn(float value)
        {
            return value * value;
        }

        public static float EvaluateCubeIn(float value)
        {
            return value * value * value;
        }

        public static float EvaluateCubeOut(float value)
        {
            return 1f - CubeInFunction(1f - value);
        }

        public static float EvaluateCubeInOut(float value)
        {
            if (value <= .5f)
                return CubeInFunction(value * 2f) / 2f;
            return CubeOutFunction(value * 2f - 1f) / 2f + .5f;
        }
    }
}
