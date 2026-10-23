using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime.Physical.Memory
{
    public sealed class NativeSourceRuntimeMemoryCapacity : ISourceRuntimeMemoryCapacity
    {
        private readonly WindowsSourceRuntimeMemoryCapacity windows = new();

        public long ReadTotalAvailableMemoryBytes()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return windows.ReadTotalAvailableMemoryBytes();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var physical = ReadLinuxPhysicalMemory();
                var limit = LinuxMemoryControlGroups.ReadLimit(physical);
                if (LinuxGetResourceLimit(9, out var addressSpace) != 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                limit = Math.Min(limit, addressSpace.Current);
                return ValidateCapacity(limit);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var length = (UIntPtr)sizeof(ulong);
                if (MacReadSystemControl("hw.memsize", out var physical, ref length, IntPtr.Zero,
                        UIntPtr.Zero) != 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                if (MacGetResourceLimit(5, out var addressSpace) != 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                return ValidateCapacity(Math.Min(physical, addressSpace.Current));
            }

            throw new PlatformNotSupportedException("Process memory capacity requires Windows, Linux or macOS.");
        }

        private static ulong ReadLinuxPhysicalMemory()
        {
            foreach (var line in File.ReadLines("/proc/meminfo"))
            {
                if (!line.StartsWith("MemTotal:", StringComparison.Ordinal)) continue;
                var fields = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                return checked(ulong.Parse(fields[1], CultureInfo.InvariantCulture) * 1024);
            }

            throw new InvalidOperationException("Linux did not expose MemTotal in /proc/meminfo.");
        }

        private static long ValidateCapacity(ulong capacity)
        {
            if (capacity == 0 || capacity > long.MaxValue)
                throw new InvalidOperationException(
                    "The operating system did not return a valid process memory capacity.");
            return (long)capacity;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ResourceLimit
        {
            public ulong Current;
            public ulong Maximum;
        }

        [DllImport("libc", EntryPoint = "getrlimit", SetLastError = true)]
        private static extern int LinuxGetResourceLimit(int resource, out ResourceLimit limit);

        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "getrlimit", SetLastError = true)]
        private static extern int MacGetResourceLimit(int resource, out ResourceLimit limit);

        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "sysctlbyname", SetLastError = true)]
        private static extern int MacReadSystemControl(string name, out ulong value, ref UIntPtr length,
            IntPtr newValue, UIntPtr newLength);
    }
}
