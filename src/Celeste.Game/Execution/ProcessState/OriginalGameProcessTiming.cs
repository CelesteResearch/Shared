using System.Diagnostics;

namespace Celeste.Game.Execution.ProcessState
{
    public sealed class OriginalGameProcessTiming
    {
        public Stopwatch LoadTimer;

        // Original Celeste.LoadContent, after base.LoadContent and BEGIN LOAD logging.
        // Repeated LoadContent replaces the reference without stopping the old timer.
        public void StartLoadContentTimer()
        {
            LoadTimer = Stopwatch.StartNew();
        }
    }
}
