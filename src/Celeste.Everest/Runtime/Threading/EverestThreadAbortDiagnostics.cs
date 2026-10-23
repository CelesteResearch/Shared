using System;
using System.Threading;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Execution.Threading;

namespace Celeste.Everest.Runtime.Threading
{
    public sealed class EverestThreadAbortDiagnostics : IOriginalThreadAbortDiagnostics
    {
        private readonly EverestLoggerProcess logger;

        public EverestThreadAbortDiagnostics(EverestLoggerProcess logger)
            => this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public void WarnBackgroundThreadAborted()
        {
            if (logger.GetLogLevel("RunThread") <= EverestLogLevel.Warn)
                logger.Log(EverestLogLevel.Warn, "RunThread",
                    "Background thread " + (Thread.CurrentThread?.Name ?? "???") + " aborted");
        }

        public void LogDetailed(Exception exception, string tag)
            => logger.LogDetailed(exception, tag);
    }
}
