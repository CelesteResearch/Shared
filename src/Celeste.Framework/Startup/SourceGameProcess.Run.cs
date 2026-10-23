using Celeste.Input.Runtime;
using System;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess
    {
        private SourceGameTickKernel tick;
        public SourceGameTickKernel TickKernel => tick;
        public global::Celeste.Core.Framework.Components.SourceGameTime CurrentGameTime => gameTime;
        private ISourceGameTimerStartDevice timer;
        private ISourceGameRunPlatform runPlatform;
        private SourceFnaInputProcess fnaInput;
        private ISourceGameBeforeLoopPolicy beforeLoopPolicy;
        private bool isActive;
        public SourceGraphicsAdapter CurrentAdapter { get; private set; }

        public bool IsActive
        {
            get => isActive;
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    if (isActive) OnActivated(this, EventArgs.Empty);
                    else OnDeactivated(this, EventArgs.Empty);
                }
            }
        }

        public void RunOneFrame()
        {
            if (!hasInitialized)
            {
                DoInitialize();
                timer.StartGameTimer();
                hasInitialized = true;
            }

            Tick();
        }

        public void Run()
        {
            AssertNotDisposed();
            if (tick.UsesHostFrameScheduling)
                throw new InvalidOperationException(
                    "Use StartSourceHostRun and host callbacks for a host-scheduled game.");
            if (!hasInitialized)
            {
                DoInitialize();
                hasInitialized = true;
            }

            BeginRun();
            BeforeLoop();
            timer.StartGameTimer();
            RunLoop();
            EndRun();
            AfterLoop();
        }

        public void Tick() => tick.Tick();

        private void BeforeLoop()
        {
            CurrentAdapter = runPlatform.RegisterGame(this);
            IsActive = true;
            fnaInput.TouchPanel.TouchDeviceExists = runPlatform.GetTouchDeviceConnected();
            beforeLoopPolicy.AfterOriginalBeforeLoop(Window);
        }

        private void AfterLoop() => runPlatform.UnregisterGame(this);

        private void RunLoop()
        {
            if (runPlatform.NeedsPlatformMainLoop()) runPlatform.RunPlatformMainLoop(this);
            while (GameLoop.RunApplication) Tick();
            OnExiting(this, EventArgs.Empty);
        }

        public void ResetElapsedTime() => tick.ResetElapsedTime();
        public void SuppressDraw() => GameLoop.SuppressDraw();
    }
}
