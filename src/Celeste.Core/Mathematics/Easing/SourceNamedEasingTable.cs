using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Easing
{
    public static class SourceNamedEasingTable
    {
        public static IReadOnlyDictionary<string, Func<float, float>> Create(ISourceEasingArithmetic source,
            Func<float, float> quintIn, Func<float, float> expoIn, Func<float, float> elasticOut,
            Func<float, float> bounceIn, Func<float, float> bounceInOut)
        {
            var expoOut = SourceEasingComposition.Invert(expoIn);
            return new Dictionary<string, Func<float, float>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Linear"] = source.Linear,
                ["SineIn"] = source.SineIn,
                ["SineOut"] = source.SineOut,
                ["SineInOut"] = source.SineInOut,
                ["QuadIn"] = source.QuadIn,
                ["QuadOut"] = source.QuadOut,
                ["QuadInOut"] = source.QuadInOut,
                ["CubeIn"] = source.CubeIn,
                ["CubeOut"] = source.CubeOut,
                ["CubeInOut"] = source.CubeInOut,
                ["QuintIn"] = quintIn,
                ["QuintOut"] = source.QuintOut,
                ["QuintInOut"] = SourceEasingComposition.Follow(quintIn, source.QuintOut),
                ["ExpoIn"] = expoIn,
                ["ExpoOut"] = expoOut,
                ["ExpoInOut"] = SourceEasingComposition.Follow(expoIn, expoOut),
                ["BackIn"] = source.BackIn,
                ["BackOut"] = source.BackOut,
                ["BackInOut"] = SourceEasingComposition.Follow(source.BackIn, source.BackOut),
                ["BigBackIn"] = source.BigBackIn,
                ["BigBackOut"] = source.BigBackOut,
                ["BigBackInOut"] = SourceEasingComposition.Follow(source.BigBackIn, source.BigBackOut),
                ["ElasticIn"] = source.ElasticIn,
                ["ElasticOut"] = elasticOut,
                ["ElasticInOut"] = SourceEasingComposition.Follow(source.ElasticIn, elasticOut),
                ["BounceIn"] = bounceIn,
                ["BounceOut"] = source.BounceOut,
                ["BounceInOut"] = bounceInOut,
            };
        }
    }
}
