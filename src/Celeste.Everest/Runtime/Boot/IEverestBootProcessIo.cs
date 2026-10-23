using System.Collections;
using System.Diagnostics;

namespace Celeste.Everest.Runtime.Boot
{
    public interface IEverestBootProcessIo
    {
        string ApplicationBaseDirectory { get; }
        bool IsWindows { get; }
        bool IsLinux { get; }
        bool IsOSX { get; }
        IDictionary GetEnvironmentVariables();
        string[] GetCommandLineArgs();
        void Start(Process process);
    }
}
