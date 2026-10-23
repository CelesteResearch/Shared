using System;

namespace Celeste.Game.Execution.Threading
{
    public interface IOriginalGameErrorIdentity
    {
        string Title { get; }
        Version Version { get; }
    }
}
