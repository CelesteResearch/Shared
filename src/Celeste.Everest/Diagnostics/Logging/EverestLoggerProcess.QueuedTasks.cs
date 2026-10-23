using System;
using Celeste.Everest.Tasks.Queuing;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess : IQueuedTaskDiagnostics
    {
        bool IQueuedTaskDiagnostics.IsErrorEnabled(string category)
        {
            return shouldLog(category, EverestLogLevel.Error);
        }

        void IQueuedTaskDiagnostics.Error(string category, string message)
        {
            LogUnchecked(EverestLogLevel.Error, category, message);
        }

        void IQueuedTaskDiagnostics.Detailed(Exception exception)
        {
            LogDetailed(exception);
        }
    }
}
