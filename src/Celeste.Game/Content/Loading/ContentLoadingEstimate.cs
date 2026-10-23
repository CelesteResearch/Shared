using System;
using System.Collections.Generic;

namespace Celeste.Game.Content.Loading
{
    internal sealed class ContentLoadingEstimate
    {
        private readonly Queue<(double Time, long Bytes)> samples = new();
        private double lastSample = double.NegativeInfinity, lastChange;
        private long previousTotal, previousReceived;
        private bool wasPending;

        internal double BytesPerSecond { get; private set; }
        internal double RemainingSeconds { get; private set; } = -1;

        internal void Update(double now, long total, long received, bool pending)
        {
            if (!pending || !wasPending || total != previousTotal || received < previousReceived)
            {
                samples.Clear();
                lastSample = double.NegativeInfinity;
                lastChange = now;
            }

            if (received > previousReceived) lastChange = now;
            previousTotal = total;
            previousReceived = received;
            wasPending = pending;
            BytesPerSecond = 0;
            RemainingSeconds = -1;
            if (!pending) return;
            if (now - lastSample >= .25)
            {
                samples.Enqueue((now, received));
                lastSample = now;
            }

            while (samples.Count > 1 && now - samples.Peek().Time > 8) samples.Dequeue();
            var first = samples.Peek();
            var elapsed = now - first.Time;
            if (elapsed < 1 || now - lastChange >= 4) return;
            BytesPerSecond = Math.Max(0, received - first.Bytes) / elapsed;
            if (elapsed >= 2 && BytesPerSecond > 0 && total > received)
                RemainingSeconds = (total - received) / BytesPerSecond;
        }
    }
}
