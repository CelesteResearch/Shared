using System;

namespace Celeste.Core.Mathematics.Easing
{
    public sealed partial class InstalledEasingArithmetic : ISourceEasingArithmetic
    {
        private Func<float, float> LinearFunction = OriginalEasingArithmetic.EvaluateLinear;
        private Func<float, float> QuadOutFunction;
        private Func<float, float> QuadInOutFunction;
        private Func<float, float> SineInOutFunction = EvaluateSineInOut;
        private Func<float, float> SineOutFunction = EvaluateSineOut;
        private Func<float, float> SineInFunction = EvaluateSineIn;
        private Func<float, float> BackInFunction = EvaluateBackIn;
        private Func<float, float> BackOutFunction;
        private Func<float, float> ElasticInFunction = EvaluateElasticIn;
        private Func<float, float> BigBackInFunction = EvaluateBigBackIn;
        private Func<float, float> BigBackOutFunction;
        private Func<float, float> QuadInFunction = EvaluateQuadIn;
        private Func<float, float> CubeInFunction = EvaluateCubeIn;
        private Func<float, float> CubeInOutFunction;
        private Func<float, float> QuintOutFunction;
        private Func<float, float> QuintInFunction = EvaluateQuintIn;

        public Func<float, float> QuintOut
        {
            get => QuintOutFunction;
            set => QuintOutFunction = value;
        }

        public static float EvaluateQuintIn(float value) => (float)((double)value * value * value * value * value);
        private Func<float, float> CubeOutFunction;

        public Func<float, float> Linear
        {
            get => LinearFunction;
            set => LinearFunction = value;
        }

        public Func<float, float> QuadInOut
        {
            get => QuadInOutFunction;
            set => QuadInOutFunction = value;
        }

        public Func<float, float> QuadOut
        {
            get => QuadOutFunction;
            set => QuadOutFunction = value;
        }

        public Func<float, float> SineInOut
        {
            get => SineInOutFunction;
            set => SineInOutFunction = value;
        }

        public Func<float, float> SineOut
        {
            get => SineOutFunction;
            set => SineOutFunction = value;
        }

        public Func<float, float> SineIn
        {
            get => SineInFunction;
            set => SineInFunction = value;
        }

        public Func<float, float> BackIn
        {
            get => BackInFunction;
            set => BackInFunction = value;
        }

        public Func<float, float> BackOut
        {
            get => BackOutFunction;
            set => BackOutFunction = value;
        }

        public Func<float, float> ElasticIn
        {
            get => ElasticInFunction;
            set => ElasticInFunction = value;
        }

        public Func<float, float> BigBackIn
        {
            get => BigBackInFunction;
            set => BigBackInFunction = value;
        }

        public Func<float, float> BigBackOut
        {
            get => BigBackOutFunction;
            set => BigBackOutFunction = value;
        }

        public Func<float, float> QuadIn
        {
            get => QuadInFunction;
            set => QuadInFunction = value;
        }

        public Func<float, float> CubeIn
        {
            get => CubeInFunction;
            set => CubeInFunction = value;
        }

        public Func<float, float> CubeOut
        {
            get => CubeOutFunction;
            set => CubeOutFunction = value;
        }

        public Func<float, float> CubeInOut
        {
            get => CubeInOutFunction;
            set => CubeInOutFunction = value;
        }

        public InstalledEasingArithmetic()
        {
            QuadOutFunction = SourceEasingComposition.Invert(QuadInFunction);
            QuadInOutFunction = SourceEasingComposition.Follow(QuadInFunction, QuadOutFunction);
            BackOutFunction = SourceEasingComposition.Invert(BackInFunction);
            BigBackOutFunction = SourceEasingComposition.Invert(BigBackInFunction);
            CubeOutFunction = SourceEasingComposition.Invert(CubeInFunction);
            QuintOutFunction = SourceEasingComposition.Invert(QuintInFunction);
            CubeInOutFunction = SourceEasingComposition.Follow(CubeInFunction, CubeOutFunction);
        }

        private Func<float, float> BounceOutFunction = EvaluateBounceOut;

        public Func<float, float> BounceOut
        {
            get => BounceOutFunction;
            set => BounceOutFunction = value;
        }

        public static float EvaluateBounceOut(float t) => (float)EvaluateBounceValue(t);

        public static float EvaluateElasticIn(float value)
        {
            double squared = (float)((double)value * (double)value);
            double cubed = (float)(squared * (double)value);
            return (float)(33d * squared * cubed + -59d * squared * squared + 32d * cubed + -5d * squared);
        }

        public static float EvaluateSineIn(float value)
            => (float)(0d - (double)(float)Math.Cos((double)((float)Math.PI / 2f) * value) + 1d);

        public static float EvaluateSineOut(float value)
            => (float)Math.Sin((double)((float)Math.PI / 2f) * value);

        public static float EvaluateBackIn(float value)
            => (float)((double)value * value * ((double)2.70158f * value - (double)1.70158f));

        public static float EvaluateBigBackIn(float value)
            => (float)((double)value * value * (4d * value - 3d));

        public static float EvaluateSineInOut(float value)
            => (float)(-(double)(float)Math.Cos(Math.PI * value) / 2 + .5);

        public static float EvaluateQuadIn(float value)
            => (float)((double)value * value);

        public static float EvaluateCubeIn(float value)
            => (float)((double)value * value * value);

        public static float EvaluateCubeOut(float value)
            => 1f - EvaluateCubeIn(1f - value);

        public static float EvaluateCubeInOut(float value)
        {
            if (value <= .5f)
                return EvaluateCubeIn(value * 2f) / 2f;
            return EvaluateCubeOut(value * 2f - 1f) / 2f + .5f;
        }
    }
}
