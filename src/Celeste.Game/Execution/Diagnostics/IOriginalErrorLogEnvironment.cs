using System;

namespace Celeste.Game.Execution.Diagnostics
{
    public interface IOriginalErrorLogEnvironment
    {
        ISourceErrorLogEngine Engine { get; }
    }
}
