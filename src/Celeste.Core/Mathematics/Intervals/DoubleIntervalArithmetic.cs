using System;

namespace Celeste.Core.Mathematics.Intervals
{
    public sealed class DoubleIntervalArithmetic : ISourceIntervalArithmetic
    {
        public static readonly DoubleIntervalArithmetic Shared = new();

        public bool OnInterval(float time, float deltaTime, float interval) =>
            (int)(((double)time - deltaTime) / interval) < (int)((double)time / interval);

        public bool OnInterval(float time, float deltaTime, float interval, float offset) =>
            Math.Floor(((double)time - offset - deltaTime) / interval) < Math.Floor(((double)time - offset) / interval);
    }
}
