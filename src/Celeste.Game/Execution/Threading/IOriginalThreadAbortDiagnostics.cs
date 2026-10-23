using System;

namespace Celeste.Game.Execution.Threading
{
    public interface IOriginalThreadAbortDiagnostics
    {
        void WarnBackgroundThreadAborted();
        void LogDetailed(Exception exception, string tag);
    }
}
