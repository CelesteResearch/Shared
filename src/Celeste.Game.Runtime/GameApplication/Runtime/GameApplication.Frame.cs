using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Input.Devices.Keyboard;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCelesteFrameLifecycle,
        IOriginalEngineFrameInput, IOriginalEngineFrameDevice, IOriginalEngineUpdateHooks
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private bool sourceFrameOpen;

        private ulong? sourceFrameCounterBeforeOverride;
        public bool FrameOpen => sourceFrameOpen;
        public long SourceTicks => unchecked((long)Frame.FrameCounter);
        public ulong CompletedSourceFrames { get; private set; }
        public event Action<ISourceEngineContext> SourceFrameCompleted;
        public event Action EngineUpdateBeginning;
        public event Action EngineUpdateEnded;
        public Action InputUpdateOverride;
        public Func<bool> EngineUpdatePaused;
        public Func<ulong?> FrameCounterOverride;

        void IOriginalCelesteFrameLifecycle.BeginSourceFrame()
        {
            if (sourceFrameOpen) throw new InvalidOperationException("The actual source frame is already open.");
            sourceFrameOpen = true;
        }

        void IOriginalCelesteFrameLifecycle.CompleteSourceFrame()
        {
            if (!sourceFrameOpen) throw new InvalidOperationException("The actual source frame is not open.");
            sourceFrameOpen = false;
            CompletedSourceFrames = unchecked(CompletedSourceFrames + 1);
            SourceFrameCompleted?.Invoke(this);
        }

        void IOriginalCelesteFrameLifecycle.AbortSourceFrame()
        {
            sourceFrameOpen = false;
            if (!sourceFrameCounterBeforeOverride.HasValue)
                return;
            Frame.FrameCounter = sourceFrameCounterBeforeOverride.Value;
            sourceFrameCounterBeforeOverride = null;
        }

        void IOriginalEngineFrameInput.Update(float deltaTime)
        {
            if (InputUpdateOverride is { } update) update();
            else MInput.Update();
        }

        bool IOriginalEngineFrameInput.EscapePressed =>
            MInput.Keyboard.Pressed(SourceKeys.Escape);

        bool IOriginalEngineFrameInput.DashHeld => InputSource.Dash.Check;

        void IOriginalEngineFrameDevice.Exit()
        {
            ActualGame.Exit();
        }

        void IOriginalEngineFrameDevice.FrameworkDispatcherUpdate()
        {
            FrameworkDispatcher.Update();
        }

        bool IOriginalEngineUpdateHooks.PausedAfterInput => EngineUpdatePaused?.Invoke() == true;

        void IOriginalEngineUpdateHooks.PreEngineUpdate()
        {
            PhysicalIO.LoadingWorkScheduler?.Pump();
            EngineUpdateBeginning?.Invoke();
            var replacement = FrameCounterOverride?.Invoke();
            if (!replacement.HasValue)
                return;
            sourceFrameCounterBeforeOverride = Frame.FrameCounter;
            Frame.FrameCounter = replacement.Value;
        }

        void IOriginalEngineUpdateHooks.PostEngineUpdate()
        {
            if (sourceFrameCounterBeforeOverride.HasValue)
            {
                Frame.FrameCounter = sourceFrameCounterBeforeOverride.Value;
                sourceFrameCounterBeforeOverride = null;
            }

            EngineUpdateEnded?.Invoke();
        }

        void IOriginalEngineUpdateHooks.BeforeFreezeTimerDecrement(ISourceSceneExecution scene)
        {
            UpdateSourceFreezeFrame(scene);
        }
    }
}
