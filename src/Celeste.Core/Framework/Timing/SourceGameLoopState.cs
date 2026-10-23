using System;

namespace Celeste.Core.Framework.Timing
{
    public sealed class SourceGameLoopState
    {
        public bool RunApplication;
        public bool SuppressDrawing;
        public event EventHandler<EventArgs> Exiting;

        // The original Game constructor publishes this after FrameworkDispatcher.Update.
        public void CompleteConstruction()
        {
            RunApplication = true;
        }

        public void Exit()
        {
            RunApplication = false;
            SuppressDrawing = true;
        }

        public void SuppressDraw()
        {
            SuppressDrawing = true;
        }

        public void OnExiting(object actualGame, EventArgs args)
        {
            if (Exiting != null) Exiting(actualGame, args);
        }
    }
}
