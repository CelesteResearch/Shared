using System;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Timing;

namespace Celeste.Platform.Native.Timing
{
    public sealed class WindowsThreadCycleClock : ISourceThreadCycleClock
    {
        private readonly IntPtr currentThread;
        private readonly bool available;

        public WindowsThreadCycleClock()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
            currentThread = GetCurrentThread();
            available = true;
        }

        public bool TryRead(out ulong cycles)
        {
            cycles = 0;
            return available && QueryThreadCycleTime(currentThread, out cycles);
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentThread();

        [DllImport("kernel32.dll", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool QueryThreadCycleTime(IntPtr threadHandle, out ulong cycleTime);
    }
}
