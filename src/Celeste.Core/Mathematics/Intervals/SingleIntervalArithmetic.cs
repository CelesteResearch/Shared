using System;

namespace Celeste.Core.Mathematics.Intervals
{
    public sealed class SingleIntervalArithmetic : ISourceIntervalArithmetic
    {
        public static readonly SingleIntervalArithmetic Shared = new();

        public bool OnInterval(float time, float deltaTime, float interval)
        {
            return (int)((time - deltaTime) / interval) < (int)(time / interval);
        }

        public bool OnInterval(float time, float deltaTime, float interval, float offset)
        {
            return Math.Floor((time - offset - deltaTime) / interval) < Math.Floor((time - offset) / interval);
        }
    }
}
