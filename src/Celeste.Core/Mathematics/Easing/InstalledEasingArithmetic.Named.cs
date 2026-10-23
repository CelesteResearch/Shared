using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Easing
{
    public sealed partial class InstalledEasingArithmetic : ISourceNamedEasingArithmetic
    {
        private IReadOnlyDictionary<string, Func<float, float>> _namedEasers;

        public IReadOnlyDictionary<string, Func<float, float>> NamedEasers => _namedEasers ??=
            SourceNamedEasingTable.Create(this, _quintInFunction, EvaluateExpoIn, EvaluateElasticOut,
                EvaluateBounceIn, EvaluateBounceInOut);

        public static float EvaluateExpoIn(float value)
        {
            return (float)Math.Pow(2d, 10d * (value - 1d));
        }

        public static float EvaluateElasticOut(float value)
        {
            double squared = (float)((double)value * value);
            double cubed = (float)(squared * value);
            return (float)(33d * squared * cubed + -106d * squared * squared + 126d * cubed + -67d * squared +
                           15d * value);
        }

        internal static double EvaluateBounceValue(double value)
        {
            if (value < 0.3636363744735718) return 7.562499549239894 * value * value;
            if (value < 0.7272727489471436)
                return 7.562499549239894 * (value - 0.5454545617103577) * (value - 0.5454545617103577) + 0.75;
            return value < 0.9090909361839294
                ? 7.562499549239894 * (value - 0.8181818127632141) * (value - 0.8181818127632141) + 0.9375
                : 7.562499549239894 * (value - 0.9545454382896423) * (value - 0.9545454382896423) + 0.984375;
        }

        public static float EvaluateBounceIn(float value)
        {
            return (float)(1d - EvaluateBounceValue(1d - value));
        }

        public static float EvaluateBounceInOut(float value)
        {
            return value < .5f
                ? (float)((1d - EvaluateBounceValue(1d - value * 2d)) / 2d)
                : (float)(EvaluateBounceValue(value * 2d - 1d) / 2d + .5d);
        }
    }
}
