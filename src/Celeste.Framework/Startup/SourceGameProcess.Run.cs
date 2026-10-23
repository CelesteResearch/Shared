using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Input.Runtime;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess
    {
        public SourceGameTickKernel TickKernel { get; }

        public SourceGameTime CurrentGameTime => gameTime;
        private readonly ISourceGameTimerStartDevice timer;
        private readonly ISourceGameRunPlatform runPlatform;
        private readonly SourceFnaInputProcess fnaInput;
        private readonly ISourceGameBeforeLoopPolicy beforeLoopPolicy;
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
            if (TickKernel.UsesHostFrameScheduling)
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

        public void Tick()
        {
            TickKernel.Tick();
        }

        private void BeforeLoop()
        {
            CurrentAdapter = runPlatform.RegisterGame(this);
            IsActive = true;
            fnaInput.TouchPanel.TouchDeviceExists = runPlatform.GetTouchDeviceConnected();
            beforeLoopPolicy.AfterOriginalBeforeLoop(Window);
        }

        private void AfterLoop()
        {
            runPlatform.UnregisterGame(this);
        }

        private void RunLoop()
        {
            if (runPlatform.NeedsPlatformMainLoop()) runPlatform.RunPlatformMainLoop(this);
            while (GameLoop.RunApplication) Tick();
            OnExiting(this, EventArgs.Empty);
        }

        public void ResetElapsedTime()
        {
            TickKernel.ResetElapsedTime();
        }

        public void SuppressDraw()
        {
            GameLoop.SuppressDraw();
        }
    }
}
