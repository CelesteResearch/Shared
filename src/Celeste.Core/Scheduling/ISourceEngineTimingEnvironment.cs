using System;

namespace Celeste.Core.Scheduling
{
    public interface ISourceEngineTimingEnvironment
    {
        TimeSpan TargetElapsedTime { get; }
    }
}
