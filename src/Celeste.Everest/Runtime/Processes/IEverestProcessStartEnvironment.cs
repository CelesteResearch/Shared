using System.Diagnostics;

namespace Celeste.Everest.Runtime.Processes
{
    public interface IEverestProcessStartEnvironment
    {
        IEverestProcessStartIo ProcessStart { get; }
    }
}
