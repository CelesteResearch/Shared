using System;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Execution.Threading;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalThreadAbortDiagnostics
    {
        private EverestThreadAbortDiagnostics sourceThreadAbortDiagnostics;

        private EverestThreadAbortDiagnostics ThreadAbortDiagnostics => sourceThreadAbortDiagnostics ??
                                                                        throw new InvalidOperationException(
                                                                            "The installed source thread abort diagnostics are not constructed.");

        void IOriginalThreadAbortDiagnostics.WarnBackgroundThreadAborted() =>
            ThreadAbortDiagnostics.WarnBackgroundThreadAborted();

        void IOriginalThreadAbortDiagnostics.LogDetailed(Exception exception, string tag) =>
            ThreadAbortDiagnostics.LogDetailed(exception, tag);
    }
}
