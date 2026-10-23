using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Game.Runtime.Physical.Processes
{
    public sealed class SourceFnaMainArgumentEnvironment : ISourceFnaMainArgumentEnvironment
    {
        public void SetSourceFnaEnvironmentVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && setenv(name, value, 1) != 0)
                throw new Win32Exception();
        }

        [DllImport("libc", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int setenv(string name, string value, int overwrite);
    }
}
