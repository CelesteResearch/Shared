using System;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess
    {
        private bool sourceHostRunOpen;
        public bool SourceHostRunOpen => sourceHostRunOpen;

        public void StartSourceHostRun()
        {
            AssertNotDisposed();
            if (sourceHostRunOpen) throw new InvalidOperationException("The actual Game Run is already open.");
            if (!hasInitialized)
            {
                DoInitialize();
                hasInitialized = true;
            }

            BeginRun();
            BeforeLoop();
            timer.StartGameTimer();
            sourceHostRunOpen = true;
        }

        public void ContinueSourceHostRun()
        {
            if (!sourceHostRunOpen)
                throw new InvalidOperationException("Start the actual Game Run before its platform callback.");
            if (GameLoop.RunApplication) Tick();
            else FinishSourceHostRun();
        }

        public void FinishSourceHostRun()
        {
            if (!sourceHostRunOpen) return;
            OnExiting(this, EventArgs.Empty);
            EndRun();
            AfterLoop();
            sourceHostRunOpen = false;
        }
    }
}
