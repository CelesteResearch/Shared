using System;

namespace Celeste.Everest.Runtime.Failures
{
    public interface IEverestCriticalFailureProcess
    {
        void CriticalFailure(Exception failure);
    }
}
