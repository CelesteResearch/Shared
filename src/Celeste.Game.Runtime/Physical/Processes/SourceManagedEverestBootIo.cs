using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Celeste.Everest.Runtime.Boot;

namespace Celeste.Game.Runtime.Physical.Processes
{
    public sealed class SourceManagedEverestBootIo : IEverestBootProcessIo
    {
        public string ApplicationBaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public bool IsOSX => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();
        public string[] GetCommandLineArgs() => Environment.GetCommandLineArgs();
        public void Start(Process process) => process.Start();
    }
}
