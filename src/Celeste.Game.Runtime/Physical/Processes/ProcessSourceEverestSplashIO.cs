using System.Diagnostics;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Game.Runtime.Physical.Processes
{
    public sealed class ProcessSourceEverestSplashIO : IEverestSplashPhysicalIO
    {
        public int ProcessId
        {
            get
            {
                using (var process = Process.GetCurrentProcess())
                {
                    return process.Id;
                }
            }
        }
    }
}
