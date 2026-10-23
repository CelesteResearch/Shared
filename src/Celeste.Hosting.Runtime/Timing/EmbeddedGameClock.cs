using System;
using Celeste.Core.Framework.Timing;

namespace Celeste.Hosting.Runtime.Timing
{
    public sealed class EmbeddedGameClock : ISourceGameTickDevice, ISourceGameTimerStartDevice
    {
        private readonly Action pollEvents;
        public TimeSpan Elapsed { get; private set; }

        public EmbeddedGameClock(Action pollEvents)
        {
            this.pollEvents = pollEvents;
        }

        public void StartGameTimer() => Elapsed = TimeSpan.Zero;
        public void AdvanceOneUpdate(TimeSpan targetElapsedTime) => Elapsed += targetElapsedTime;
        public void PollEvents() => pollEvents();

        public void Sleep(int milliseconds) => throw new InvalidOperationException(
            "Advance the embedded clock by the source target before continuing its run.");

        public void SpinWait(int iterations) => throw new InvalidOperationException(
            "Advance the embedded clock by the source target before continuing its run.");
    }
}
