using System;

namespace Celeste.Core.Mathematics.Easing
{
    public interface ISourceEasingArithmetic
    {
        Func<float, float> BounceOut { get; }
        Func<float, float> Linear { get; }
        Func<float, float> QuadOut { get; }
        Func<float, float> QuadInOut { get; }
        Func<float, float> SineInOut { get; }
        Func<float, float> SineOut { get; }
        Func<float, float> SineIn { get; }
        Func<float, float> BackIn { get; }
        Func<float, float> BackOut { get; }
        Func<float, float> ElasticIn { get; }
        Func<float, float> BigBackIn { get; }
        Func<float, float> BigBackOut { get; }
        Func<float, float> QuadIn { get; }
        Func<float, float> CubeIn { get; }
        Func<float, float> CubeOut { get; }
        Func<float, float> QuintOut { get; }
        Func<float, float> CubeInOut { get; }
    }
}
