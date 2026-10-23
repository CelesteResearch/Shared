using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime.Physical.Memory
{
    /// <summary>Samples Windows process limits using the original CoreCLR 8 default memory budget policy.</summary>
    public sealed class WindowsSourceRuntimeMemoryCapacity : ISourceRuntimeMemoryCapacity
    {
        public long ReadTotalAvailableMemoryBytes()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException("Windows process memory capacity requires Windows.");

            var memory = new MemoryStatus { Length = (uint)Marshal.SizeOf<MemoryStatus>() };
            if (!GlobalMemoryStatusEx(ref memory)) throw new Win32Exception(Marshal.GetLastWin32Error());
            if (memory.TotalPhysical == 0 || memory.TotalVirtual == 0)
                throw new InvalidOperationException("Windows did not expose physical and virtual memory capacity.");
            if (!IsProcessInJob(GetCurrentProcess(), IntPtr.Zero, out var inJob))
                throw new Win32Exception(Marshal.GetLastWin32Error());

            var limit = ulong.MaxValue;
            if (inJob)
            {
                if (!QueryInformationJobObject(IntPtr.Zero, 9, out var job,
                        (uint)Marshal.SizeOf<ExtendedJobLimits>(), IntPtr.Zero))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                if ((job.Basic.LimitFlags & 0x200) != 0) limit = Math.Min(limit, job.JobMemoryLimit.ToUInt64());
                if ((job.Basic.LimitFlags & 0x100) != 0) limit = Math.Min(limit, job.ProcessMemoryLimit.ToUInt64());
                if ((job.Basic.LimitFlags & 0x1) != 0)
                    limit = Math.Min(limit, job.Basic.MaximumWorkingSetSize.ToUInt64());
            }

            var restricted = limit != ulong.MaxValue && limit != 0;
            if (restricted)
            {
                limit = Math.Min(limit, memory.TotalPhysical);
                // CoreCLR discards the job restriction when virtual address space is smaller.
                if (memory.TotalVirtual < limit) restricted = false;
            }

            if (!restricted) limit = Math.Min(memory.TotalPhysical, memory.TotalVirtual);
            if (restricted && IntPtr.Size == 8)
                limit = Math.Max(20UL * 1024 * 1024, limit / 100 * 75 + limit % 100 * 75 / 100);
            if (limit == 0 || limit > long.MaxValue)
                throw new InvalidOperationException("Windows did not return a valid process memory capacity.");
            return (long)limit;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(ref MemoryStatus memory);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsProcessInJob(IntPtr process, IntPtr job,
            [MarshalAs(UnmanagedType.Bool)] out bool result);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool QueryInformationJobObject(IntPtr job, int informationClass,
            out ExtendedJobLimits information, uint length, IntPtr returnedLength);

        // These fields are populated by the Windows ABI, rather than managed assignments.
#pragma warning disable CS0649
        [StructLayout(LayoutKind.Sequential)]
        private struct MemoryStatus
        {
            public uint Length, MemoryLoad;
            public ulong TotalPhysical, AvailablePhysical, TotalPageFile, AvailablePageFile;
            public ulong TotalVirtual, AvailableVirtual, AvailableExtendedVirtual;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct BasicJobLimits
        {
            public long PerProcessUserTimeLimit, PerJobUserTimeLimit;
            public uint LimitFlags;
            public UIntPtr MinimumWorkingSetSize, MaximumWorkingSetSize;
            public uint ActiveProcessLimit;
            public UIntPtr Affinity;
            public uint PriorityClass, SchedulingClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IoCounters
        {
            public ulong ReadOperationCount, WriteOperationCount, OtherOperationCount;
            public ulong ReadTransferCount, WriteTransferCount, OtherTransferCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ExtendedJobLimits
        {
            public BasicJobLimits Basic;
            public IoCounters Io;
            public UIntPtr ProcessMemoryLimit, JobMemoryLimit, PeakProcessMemoryUsed, PeakJobMemoryUsed;
        }
#pragma warning restore CS0649
    }
}
