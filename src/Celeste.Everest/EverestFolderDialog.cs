using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest
{
    public static class EverestFolderDialog
    {
        public static Task<string> Select(string initialDirectory)
        {
            var completion = new TaskCompletionSource<string>();
            var thread = new Thread(() =>
            {
                try
                {
                    completion.SetResult(SelectCore(initialDirectory));
                }
                catch (Exception ex)
                {
                    completion.SetException(ex);
                }
            });
            thread.IsBackground = true;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return completion.Task;
        }

        private static string SelectCore(string initial)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                BrowseCallback callback = (window, message, param, data) =>
                {
                    if (message == 1) SendMessage(window, 0x467, new(1), initial);
                    return 0;
                };
                var buffer = new StringBuilder(32768);
                var info = new BrowseInfo
                {
                    Title = "Select Output Directory", Flags = 0x41, Callback = callback,
                    DisplayName = Marshal.AllocHGlobal(32768 * 2),
                };
                var selected = IntPtr.Zero;
                try
                {
                    selected = SHBrowseForFolder(ref info);
                    if (selected == IntPtr.Zero) return null;
                    if (!SHGetPathFromIDListEx(selected, buffer, (uint)buffer.Capacity, 0))
                        throw new InvalidOperationException("Selected item is not a filesystem directory.");
                    return buffer.ToString();
                }
                finally
                {
                    if (selected != IntPtr.Zero) Marshal.FreeCoTaskMem(selected);
                    Marshal.FreeHGlobal(info.DisplayName);
                    GC.KeepAlive(callback);
                }
            }

            var mac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            var start = new ProcessStartInfo
            {
                FileName = mac ? "osascript" : "zenity", UseShellExecute = false, CreateNoWindow = true,
                RedirectStandardOutput = true, RedirectStandardError = true,
            };
            start.Arguments =
                mac
                    ? "-e \"POSIX path of (choose folder with prompt \\\"Select Output Directory\\\")\""
                    : "--file-selection --directory --title=\"Select Output Directory\"";
            using (var process = Process.Start(start))
            {
                var value = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                if (process.ExitCode == 1) return null;
                if (process.ExitCode != 0) throw new InvalidOperationException(error);
                return value.TrimEnd('\r', '\n');
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate int BrowseCallback(IntPtr window, uint message, IntPtr param, IntPtr data);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct BrowseInfo
        {
            public IntPtr Owner, Root, DisplayName;
            [MarshalAs(UnmanagedType.LPWStr)] public string Title;
            public uint Flags;
            public BrowseCallback Callback;
            public IntPtr Param;
            public int Image;
        }

        [DllImport("shell32.dll", EntryPoint = "SHBrowseForFolderW", CharSet = CharSet.Unicode)]
        private static extern IntPtr SHBrowseForFolder(ref BrowseInfo info);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SHGetPathFromIDListEx(IntPtr item, StringBuilder path, uint length, uint flags);

        [DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr window, uint message, IntPtr param, string text);
    }
}
