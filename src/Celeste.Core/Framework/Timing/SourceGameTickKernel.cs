using System;
using System.Diagnostics;
using Celeste.Core.Framework.Components;
using Celeste.Core.Scheduling;

namespace Celeste.Core.Framework.Timing
{
    public sealed class SourceGameTickKernel
    {
        public SourceFrameDiagnostics Diagnostics { get; } = new();

        private static readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(5000000);
        private readonly SourceEngineTimingState _timing;
        private readonly SourceGameTime _gameTime;
        private readonly ISourceGameTickDevice _device;
        private readonly ISourceHostScheduledGameTickDevice _hostScheduling;
        public bool UsesHostFrameScheduling { get; }
        private readonly ISourceGameTickFrame _frame;

        private TimeSpan accumulatedElapsedTime;
        private long _previousTicks;
        private int _updateFrameLag;
        private bool _forceElapsedTimeToZero;
        private readonly SourceGameLoopState _loop;
        private readonly TimeSpan[] _previousSleepTimes;
        private int _sleepTimeIndex;
        private TimeSpan _worstCaseSleepPrecision = TimeSpan.FromTicks(10000);

        public SourceGameTickKernel(SourceEngineTimingState timing, SourceGameTime gameTime,
            ISourceGameTickDevice device, ISourceGameTickFrame frame, SourceGameLoopState loop,
            TimeSpan[] actualGameSleepTimes)
        {
            _timing = timing;
            _gameTime = gameTime;
            _device = device;
            _hostScheduling = device as ISourceHostScheduledGameTickDevice;
            UsesHostFrameScheduling = _hostScheduling != null;
            _frame = frame;
            _loop = loop;
            _previousSleepTimes = actualGameSleepTimes;
            Diagnostics.BindThreadCycleClock(device as ISourceThreadCycleClock);
        }

        public void ResetElapsedTime()
        {
            if (!_timing.IsFixedTimeStep) _forceElapsedTimeToZero = true;
        }

        public void SuppressDraw()
        {
            _loop.SuppressDraw();
        }

        public void Tick()
        {
            if (_hostScheduling != null && _hostScheduling.SourceUpdatesBlocked) return;
            if (UsesHostFrameScheduling)
            {
                AdvanceElapsedTime();
                if (_timing.IsFixedTimeStep && accumulatedElapsedTime < _timing.TargetElapsedTime) return;
            }

            if (Diagnostics.Enabled)
            {
                TickMeasured();
                return;
            }

            if (!UsesHostFrameScheduling) AdvanceElapsedTime();
            if (_timing.IsFixedTimeStep && !UsesHostFrameScheduling)
            {
                while (accumulatedElapsedTime + _worstCaseSleepPrecision < _timing.TargetElapsedTime)
                {
                    _device.Sleep(1);
                    var timeSpentSleeping = AdvanceElapsedTime();
                    UpdateEstimatedSleepPrecision(timeSpentSleeping);
                }

                while (accumulatedElapsedTime < _timing.TargetElapsedTime)
                {
                    _device.SpinWait(1);
                    AdvanceElapsedTime();
                }
            }

            _device.PollEvents();
            if (accumulatedElapsedTime > MaxElapsedTime) accumulatedElapsedTime = MaxElapsedTime;
            if (_timing.IsFixedTimeStep)
            {
                _gameTime.ElapsedGameTime = _timing.TargetElapsedTime;
                var stepCount = 0;
                while (accumulatedElapsedTime >= _timing.TargetElapsedTime)
                {
                    if (_hostScheduling != null && _hostScheduling.SourceUpdatesBlocked) break;
                    _gameTime.TotalGameTime += _timing.TargetElapsedTime;
                    accumulatedElapsedTime -= _timing.TargetElapsedTime;
                    stepCount = unchecked(stepCount + 1);
                    _frame.AssertNotDisposed();
                    _frame.Update(_gameTime);
                }

                _updateFrameLag = unchecked(_updateFrameLag + Math.Max(0, unchecked(stepCount - 1)));
                if (_gameTime.IsRunningSlowly)
                {
                    if (_updateFrameLag == 0) _gameTime.IsRunningSlowly = false;
                }
                else if (_updateFrameLag >= 5)
                {
                    _gameTime.IsRunningSlowly = true;
                }

                if (stepCount == 1 && _updateFrameLag > 0) _updateFrameLag = unchecked(_updateFrameLag - 1);
                _gameTime.ElapsedGameTime = TimeSpan.FromTicks(unchecked(_timing.TargetElapsedTime.Ticks * stepCount));
            }
            else
            {
                if (_forceElapsedTimeToZero)
                {
                    _gameTime.ElapsedGameTime = TimeSpan.Zero;
                    _forceElapsedTimeToZero = false;
                }
                else
                {
                    _gameTime.ElapsedGameTime = accumulatedElapsedTime;
                    _gameTime.TotalGameTime += _gameTime.ElapsedGameTime;
                }

                accumulatedElapsedTime = TimeSpan.Zero;
                _frame.AssertNotDisposed();
                _frame.Update(_gameTime);
            }

            if (_loop.SuppressDrawing)
            {
                _loop.SuppressDrawing = false;
                return;
            }

            if (_frame.BeginDraw())
            {
                _frame.Draw(_gameTime);
                _frame.EndDraw();
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
            var timestamp = Stopwatch.GetTimestamp();
            byte cycleValidity = 0;
            var cyclesAtStart = Diagnostics.ReadThreadCycles(1, ref cycleValidity);
            int gc0 = GC.CollectionCount(0), gc1 = GC.CollectionCount(1), gc2 = GC.CollectionCount(2);
            long updateTicks = 0, drawTicks = 0, endDrawTicks = 0, beginDrawTicks = 0;
            var updateCount = 0;
            var marker = Diagnostics.Marker;
            if (!UsesHostFrameScheduling) AdvanceElapsedTime();
            if (_timing.IsFixedTimeStep && !UsesHostFrameScheduling)
            {
                while (accumulatedElapsedTime + _worstCaseSleepPrecision < _timing.TargetElapsedTime)
                {
                    _device.Sleep(1);
                    var timeSpentSleeping = AdvanceElapsedTime();
                    UpdateEstimatedSleepPrecision(timeSpentSleeping);
                }

                while (accumulatedElapsedTime < _timing.TargetElapsedTime)
                {
                    _device.SpinWait(1);
                    AdvanceElapsedTime();
                }
            }

            var waitEnd = Stopwatch.GetTimestamp();
            var cyclesAtWaitEnd = Diagnostics.ReadThreadCycles(2, ref cycleValidity);
            _device.PollEvents();
            if (accumulatedElapsedTime > MaxElapsedTime) accumulatedElapsedTime = MaxElapsedTime;
            if (_timing.IsFixedTimeStep)
            {
                _gameTime.ElapsedGameTime = _timing.TargetElapsedTime;
                var stepCount = 0;
                while (accumulatedElapsedTime >= _timing.TargetElapsedTime)
                {
                    if (_hostScheduling != null && _hostScheduling.SourceUpdatesBlocked) break;
                    _gameTime.TotalGameTime += _timing.TargetElapsedTime;
                    accumulatedElapsedTime -= _timing.TargetElapsedTime;
                    stepCount = unchecked(stepCount + 1);
                    _frame.AssertNotDisposed();
                    var updateStart = Stopwatch.GetTimestamp();
                    _frame.Update(_gameTime);
                    updateTicks += Stopwatch.GetTimestamp() - updateStart;
                    updateCount++;
                }

                _updateFrameLag = unchecked(_updateFrameLag + Math.Max(0, unchecked(stepCount - 1)));
                if (_gameTime.IsRunningSlowly)
                {
                    if (_updateFrameLag == 0) _gameTime.IsRunningSlowly = false;
                }
                else if (_updateFrameLag >= 5)
                {
                    _gameTime.IsRunningSlowly = true;
                }

                if (stepCount == 1 && _updateFrameLag > 0) _updateFrameLag = unchecked(_updateFrameLag - 1);
                _gameTime.ElapsedGameTime = TimeSpan.FromTicks(unchecked(_timing.TargetElapsedTime.Ticks * stepCount));
            }
            else
            {
                if (_forceElapsedTimeToZero)
                {
                    _gameTime.ElapsedGameTime = TimeSpan.Zero;
                    _forceElapsedTimeToZero = false;
                }
                else
                {
                    _gameTime.ElapsedGameTime = accumulatedElapsedTime;
                    _gameTime.TotalGameTime += _gameTime.ElapsedGameTime;
                }

                accumulatedElapsedTime = TimeSpan.Zero;
                _frame.AssertNotDisposed();
                var updateStart = Stopwatch.GetTimestamp();
                _frame.Update(_gameTime);
                updateTicks += Stopwatch.GetTimestamp() - updateStart;
                updateCount++;
            }

            if (_loop.SuppressDrawing)
            {
                _loop.SuppressDrawing = false;
                var cyclesAtSuppressedEnd = Diagnostics.ReadThreadCycles(4, ref cycleValidity);
                Diagnostics.Record(timestamp, updateCount, updateTicks, 0, 0, 0, waitEnd - timestamp, gc0, gc1, gc2,
                    marker, cyclesAtStart, cyclesAtWaitEnd, cyclesAtSuppressedEnd, cycleValidity);
                return;
            }

            var beginDrawStart = Stopwatch.GetTimestamp();
            var accepted = _frame.BeginDraw();
            beginDrawTicks = Stopwatch.GetTimestamp() - beginDrawStart;
            if (accepted)
            {
                var drawStart = Stopwatch.GetTimestamp();
                _frame.Draw(_gameTime);
                drawTicks = Stopwatch.GetTimestamp() - drawStart;
                var endDrawStart = Stopwatch.GetTimestamp();
                _frame.EndDraw();
                endDrawTicks = Stopwatch.GetTimestamp() - endDrawStart;
            }

            var cyclesAtEnd = Diagnostics.ReadThreadCycles(4, ref cycleValidity);
            Diagnostics.Record(timestamp, updateCount, updateTicks, drawTicks, endDrawTicks, beginDrawTicks,
                waitEnd - timestamp, gc0, gc1, gc2, marker,
                cyclesAtStart, cyclesAtWaitEnd, cyclesAtEnd, cycleValidity);
        }

        private TimeSpan AdvanceElapsedTime()
        {
            var ticks = _device.Elapsed.Ticks;
            var elapsed = TimeSpan.FromTicks(unchecked(ticks - _previousTicks));
            accumulatedElapsedTime += elapsed;
            _previousTicks = ticks;
            return elapsed;
        }

        private void UpdateEstimatedSleepPrecision(TimeSpan timeSpentSleeping)
        {
            var upperBound = TimeSpan.FromTicks(40000);
            if (timeSpentSleeping > upperBound) timeSpentSleeping = upperBound;
            if (timeSpentSleeping >= _worstCaseSleepPrecision)
            {
                _worstCaseSleepPrecision = timeSpentSleeping;
            }
            else if (_previousSleepTimes[_sleepTimeIndex] == _worstCaseSleepPrecision)
            {
                var max = TimeSpan.MinValue;
                for (var i = 0; i < _previousSleepTimes.Length; i++)
                    if (_previousSleepTimes[i] > max)
                        max = _previousSleepTimes[i];
                _worstCaseSleepPrecision = max;
            }

            _previousSleepTimes[_sleepTimeIndex] = timeSpentSleeping;
            _sleepTimeIndex = unchecked(_sleepTimeIndex + 1) & 127;
        }
    }
}
