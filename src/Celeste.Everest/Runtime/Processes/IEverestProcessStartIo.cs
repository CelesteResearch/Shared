using System.Diagnostics;

namespace Celeste.Everest.Runtime.Processes
{
    public interface IEverestProcessStartIo
    {
        void Start(ProcessStartInfo startInfo);
    }
}
