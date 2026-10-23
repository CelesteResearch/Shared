using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Scheduling;

namespace Celeste.Core.Framework.Timing
{
    public sealed class SourceGameTickKernel
    {
        public SourceFrameDiagnostics Diagnostics { get; } = new SourceFrameDiagnostics();

        private static readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(5000000);
        private readonly SourceEngineTimingState timing;
        private readonly SourceGameTime gameTime;
        private readonly ISourceGameTickDevice device;
        private readonly ISourceHostScheduledGameTickDevice hostScheduling;
        public bool UsesHostFrameScheduling { get; }
        private readonly ISourceGameTickFrame frame;
        private TimeSpan accumulatedElapsedTime;
        private long previousTicks;
        private int updateFrameLag;
        private bool forceElapsedTimeToZero;
        private readonly SourceGameLoopState loop;
        private readonly TimeSpan[] previousSleepTimes;
        private int sleepTimeIndex;
        private TimeSpan worstCaseSleepPrecision = TimeSpan.FromTicks(10000);

        public SourceGameTickKernel(SourceEngineTimingState timing, SourceGameTime gameTime,
            ISourceGameTickDevice device, ISourceGameTickFrame frame, SourceGameLoopState loop,
            TimeSpan[] actualGameSleepTimes)
        {
            this.timing = timing;
            this.gameTime = gameTime;
            this.device = device;
            hostScheduling = device as ISourceHostScheduledGameTickDevice;
            UsesHostFrameScheduling = hostScheduling != null;
            this.frame = frame;
            this.loop = loop;
            previousSleepTimes = actualGameSleepTimes;
            Diagnostics.BindThreadCycleClock(device as ISourceThreadCycleClock);
        }

        public void ResetElapsedTime()
        {
            if (!timing.IsFixedTimeStep) forceElapsedTimeToZero = true;
        }

        public void SuppressDraw() => loop.SuppressDraw();

        public void Tick()
        {
            if (hostScheduling != null && hostScheduling.SourceUpdatesBlocked) return;
            if (UsesHostFrameScheduling)
            {
                AdvanceElapsedTime();
                if (timing.IsFixedTimeStep && accumulatedElapsedTime < timing.TargetElapsedTime) return;
            }

            if (Diagnostics.Enabled)
            {
                TickMeasured();
                return;
            }

            if (!UsesHostFrameScheduling) AdvanceElapsedTime();
            if (timing.IsFixedTimeStep && !UsesHostFrameScheduling)
            {
                while (accumulatedElapsedTime + worstCaseSleepPrecision < timing.TargetElapsedTime)
                {
                    device.Sleep(1);
                    TimeSpan timeSpentSleeping = AdvanceElapsedTime();
                    UpdateEstimatedSleepPrecision(timeSpentSleeping);
                }

                while (accumulatedElapsedTime < timing.TargetElapsedTime)
                {
                    device.SpinWait(1);
                    AdvanceElapsedTime();
                }
            }

            device.PollEvents();
            if (accumulatedElapsedTime > MaxElapsedTime) accumulatedElapsedTime = MaxElapsedTime;
            if (timing.IsFixedTimeStep)
            {
                gameTime.ElapsedGameTime = timing.TargetElapsedTime;
                int stepCount = 0;
                while (accumulatedElapsedTime >= timing.TargetElapsedTime)
                {
                    if (hostScheduling != null && hostScheduling.SourceUpdatesBlocked) break;
                    gameTime.TotalGameTime += timing.TargetElapsedTime;
                    accumulatedElapsedTime -= timing.TargetElapsedTime;
                    stepCount = unchecked(stepCount + 1);
                    frame.AssertNotDisposed();
                    frame.Update(gameTime);
                }

                updateFrameLag = unchecked(updateFrameLag + Math.Max(0, unchecked(stepCount - 1)));
                if (gameTime.IsRunningSlowly)
                {
                    if (updateFrameLag == 0) gameTime.IsRunningSlowly = false;
                }
                else if (updateFrameLag >= 5) gameTime.IsRunningSlowly = true;

                if (stepCount == 1 && updateFrameLag > 0) updateFrameLag = unchecked(updateFrameLag - 1);
                gameTime.ElapsedGameTime = TimeSpan.FromTicks(unchecked(timing.TargetElapsedTime.Ticks * stepCount));
            }
            else
            {
                if (forceElapsedTimeToZero)
                {
                    gameTime.ElapsedGameTime = TimeSpan.Zero;
                    forceElapsedTimeToZero = false;
                }
                else
                {
                    gameTime.ElapsedGameTime = accumulatedElapsedTime;
                    gameTime.TotalGameTime += gameTime.ElapsedGameTime;
                }

                accumulatedElapsedTime = TimeSpan.Zero;
                frame.AssertNotDisposed();
                frame.Update(gameTime);
            }

            if (loop.SuppressDrawing)
            {
                loop.SuppressDrawing = false;
                return;
            }

            if (frame.BeginDraw())
            {
                frame.Draw(gameTime);
                frame.EndDraw();
            }
        }

        private void TickMeasured()
        {
            Diagnostics.BeginFrame();
            try
            {
                TickMeasuredBody();
            }
            finally
            {
                Diagnostics.EndFrame();
            }
        }

        private void TickMeasuredBody()
        {
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            byte cycleValidity = 0;
            ulong cyclesAtStart = Diagnostics.ReadThreadCycles(1, ref cycleValidity);
            int gc0 = GC.CollectionCount(0), gc1 = GC.CollectionCount(1), gc2 = GC.CollectionCount(2);
            long updateTicks = 0, drawTicks = 0, endDrawTicks = 0, beginDrawTicks = 0;
            int updateCount = 0;
            object marker = Diagnostics.Marker;
            if (!UsesHostFrameScheduling) AdvanceElapsedTime();
            if (timing.IsFixedTimeStep && !UsesHostFrameScheduling)
            {
                while (accumulatedElapsedTime + worstCaseSleepPrecision < timing.TargetElapsedTime)
                {
                    device.Sleep(1);
                    TimeSpan timeSpentSleeping = AdvanceElapsedTime();
                    UpdateEstimatedSleepPrecision(timeSpentSleeping);
                }

                while (accumulatedElapsedTime < timing.TargetElapsedTime)
                {
                    device.SpinWait(1);
                    AdvanceElapsedTime();
                }
            }

            long waitEnd = System.Diagnostics.Stopwatch.GetTimestamp();
            ulong cyclesAtWaitEnd = Diagnostics.ReadThreadCycles(2, ref cycleValidity);
            device.PollEvents();
            if (accumulatedElapsedTime > MaxElapsedTime) accumulatedElapsedTime = MaxElapsedTime;
            if (timing.IsFixedTimeStep)
            {
                gameTime.ElapsedGameTime = timing.TargetElapsedTime;
                int stepCount = 0;
                while (accumulatedElapsedTime >= timing.TargetElapsedTime)
                {
                    if (hostScheduling != null && hostScheduling.SourceUpdatesBlocked) break;
                    gameTime.TotalGameTime += timing.TargetElapsedTime;
                    accumulatedElapsedTime -= timing.TargetElapsedTime;
                    stepCount = unchecked(stepCount + 1);
                    frame.AssertNotDisposed();
                    long updateStart = System.Diagnostics.Stopwatch.GetTimestamp();
                    frame.Update(gameTime);
                    updateTicks += System.Diagnostics.Stopwatch.GetTimestamp() - updateStart;
                    updateCount++;
                }

                updateFrameLag = unchecked(updateFrameLag + Math.Max(0, unchecked(stepCount - 1)));
                if (gameTime.IsRunningSlowly)
                {
                    if (updateFrameLag == 0) gameTime.IsRunningSlowly = false;
                }
                else if (updateFrameLag >= 5) gameTime.IsRunningSlowly = true;

                if (stepCount == 1 && updateFrameLag > 0) updateFrameLag = unchecked(updateFrameLag - 1);
                gameTime.ElapsedGameTime = TimeSpan.FromTicks(unchecked(timing.TargetElapsedTime.Ticks * stepCount));
            }
            else
            {
                if (forceElapsedTimeToZero)
                {
                    gameTime.ElapsedGameTime = TimeSpan.Zero;
                    forceElapsedTimeToZero = false;
                }
                else
                {
                    gameTime.ElapsedGameTime = accumulatedElapsedTime;
                    gameTime.TotalGameTime += gameTime.ElapsedGameTime;
                }

                accumulatedElapsedTime = TimeSpan.Zero;
                frame.AssertNotDisposed();
                long updateStart = System.Diagnostics.Stopwatch.GetTimestamp();
                frame.Update(gameTime);
                updateTicks += System.Diagnostics.Stopwatch.GetTimestamp() - updateStart;
                updateCount++;
            }

            if (loop.SuppressDrawing)
            {
                loop.SuppressDrawing = false;
                ulong cyclesAtSuppressedEnd = Diagnostics.ReadThreadCycles(4, ref cycleValidity);
                Diagnostics.Record(timestamp, updateCount, updateTicks, 0, 0, 0, waitEnd - timestamp, gc0, gc1, gc2,
                    marker, cyclesAtStart, cyclesAtWaitEnd, cyclesAtSuppressedEnd, cycleValidity);
                return;
            }

            long beginDrawStart = System.Diagnostics.Stopwatch.GetTimestamp();
            bool accepted = frame.BeginDraw();
            beginDrawTicks = System.Diagnostics.Stopwatch.GetTimestamp() - beginDrawStart;
            if (accepted)
            {
                long drawStart = System.Diagnostics.Stopwatch.GetTimestamp();
                frame.Draw(gameTime);
                drawTicks = System.Diagnostics.Stopwatch.GetTimestamp() - drawStart;
                long endDrawStart = System.Diagnostics.Stopwatch.GetTimestamp();
                frame.EndDraw();
                endDrawTicks = System.Diagnostics.Stopwatch.GetTimestamp() - endDrawStart;
            }

            ulong cyclesAtEnd = Diagnostics.ReadThreadCycles(4, ref cycleValidity);
            Diagnostics.Record(timestamp, updateCount, updateTicks, drawTicks, endDrawTicks, beginDrawTicks,
                waitEnd - timestamp, gc0, gc1, gc2, marker,
                cyclesAtStart, cyclesAtWaitEnd, cyclesAtEnd, cycleValidity);
        }

        private TimeSpan AdvanceElapsedTime()
        {
            long ticks = device.Elapsed.Ticks;
            TimeSpan elapsed = TimeSpan.FromTicks(unchecked(ticks - previousTicks));
            accumulatedElapsedTime += elapsed;
            previousTicks = ticks;
            return elapsed;
        }

        private void UpdateEstimatedSleepPrecision(TimeSpan timeSpentSleeping)
        {
            TimeSpan upperBound = TimeSpan.FromTicks(40000);
            if (timeSpentSleeping > upperBound) timeSpentSleeping = upperBound;
            if (timeSpentSleeping >= worstCaseSleepPrecision)
                worstCaseSleepPrecision = timeSpentSleeping;
            else if (previousSleepTimes[sleepTimeIndex] == worstCaseSleepPrecision)
            {
                TimeSpan max = TimeSpan.MinValue;
                for (int i = 0; i < previousSleepTimes.Length; i++)
                    if (previousSleepTimes[i] > max)
                        max = previousSleepTimes[i];
                worstCaseSleepPrecision = max;
            }

            previousSleepTimes[sleepTimeIndex] = timeSpentSleeping;
            sleepTimeIndex = unchecked(sleepTimeIndex + 1) & 127;
        }
    }
}
