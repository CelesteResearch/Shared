using System;

namespace Celeste.Core.Framework.Timing
{
    public interface ISourceGameTickDevice
    {
        TimeSpan Elapsed { get; }
        void Sleep(int milliseconds);
        void SpinWait(int iterations);
        void PollEvents();
    }
}
