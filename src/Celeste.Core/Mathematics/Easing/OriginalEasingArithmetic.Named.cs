using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Easing
{
    public sealed partial class OriginalEasingArithmetic : ISourceNamedEasingArithmetic
    {
        private IReadOnlyDictionary<string, Func<float, float>> namedEasers;

        public IReadOnlyDictionary<string, Func<float, float>> NamedEasers => namedEasers ??=
            SourceNamedEasingTable.Create(this, EvaluateQuintIn, EvaluateExpoIn, EvaluateElasticOut,
                SourceEasingComposition.Invert(BounceOut), EvaluateBounceInOut);

        public static float EvaluateExpoIn(float value) => (float)Math.Pow(2d, 10f * (value - 1f));

        public static float EvaluateElasticOut(float value)
        {
            float squared = value * value;
            float cubed = squared * value;
            return 33f * cubed * squared + -106f * squared * squared + 126f * cubed + -67f * squared + 15f * value;
        }

        public static float EvaluateBounceInOut(float value)
            => value < .5f
                ? (1f - EvaluateBounceOut(1f - value * 2f)) / 2f
                : EvaluateBounceOut(value * 2f - 1f) / 2f + .5f;
    }
}
