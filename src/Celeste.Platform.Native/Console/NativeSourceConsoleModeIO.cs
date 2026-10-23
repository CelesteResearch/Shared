using System;
using System.Runtime.InteropServices;
using Celeste.Core.IO.Console;

namespace Celeste.Platform.Native.Console
{
    public sealed class NativeSourceConsoleModeIO : ISourceConsoleModeIO
    {
        public IntPtr GetStdHandle(int kind)
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? NativeGetStdHandle(kind)
                : IntPtr.Zero;
        }

        public bool GetConsoleMode(IntPtr handle, out uint mode)
        {
            mode = 0;
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && NativeGetConsoleMode(handle, out mode);
        }

        public bool SetConsoleMode(IntPtr handle, uint mode)
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && NativeSetConsoleMode(handle, mode);
        }

        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true)]
        private static extern IntPtr NativeGetStdHandle(int kind);

        [DllImport("kernel32.dll", EntryPoint = "GetConsoleMode")]
        private static extern bool NativeGetConsoleMode(IntPtr handle, out uint mode);

        [DllImport("kernel32.dll", EntryPoint = "SetConsoleMode")]
        private static extern bool NativeSetConsoleMode(IntPtr handle, uint mode);
    }
}
