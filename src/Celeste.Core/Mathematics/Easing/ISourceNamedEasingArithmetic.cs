using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Easing
{
    public interface ISourceNamedEasingArithmetic
    {
        IReadOnlyDictionary<string, Func<float, float>> NamedEasers { get; }
    }
}
