using System;
using System.Diagnostics;
using System.Threading;
using Celeste.Core.Framework.Timing;

namespace Celeste.Platform.Native.Timing
{
    public sealed class SourceStopwatchGameClockDevice : ISourceGameTickDevice, ISourceGameTimerStartDevice,
        ISourceThreadCycleClock
    {
        private readonly Stopwatch timer = new();
        private Action pollEvents;
        private readonly WindowsThreadCycleClock threadCycles = new();

        public bool TryRead(out ulong cycles)
        {
            return threadCycles.TryRead(out cycles);
        }

        public TimeSpan Elapsed => timer.Elapsed;

        public void StartGameTimer()
        {
            timer.Start();
        }

        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void SpinWait(int iterations)
        {
            Thread.SpinWait(iterations);
        }

        public void BindPollEvents(Action physicalInputPoll)
        {
            if (pollEvents != null) throw new InvalidOperationException("The physical input poll is already bound.");

            pollEvents = physicalInputPoll ?? throw new ArgumentNullException(nameof(physicalInputPoll));
        }

        public void PollEvents()
        {
            if (pollEvents == null)
                throw new InvalidOperationException("Bind the actual physical input poll before Game Run.");

            pollEvents();
        }
    }
}
