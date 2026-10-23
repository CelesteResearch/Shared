using System;

namespace Celeste.Game.Execution.Threading
{
    public interface IOriginalThreadFailureOutput
    {
        void WriteErrorLog(Exception exception);
        void OpenErrorLog();
        void ExitGame();
    }
}
