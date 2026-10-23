using System;

namespace Celeste.Everest.Tasks.Queuing
{
    public interface IQueuedTaskDiagnostics
    {
        bool IsErrorEnabled(string category);
        void Error(string category, string message);
        void Detailed(Exception exception);
    }
}
