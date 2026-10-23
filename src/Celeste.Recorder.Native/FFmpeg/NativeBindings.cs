using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public static class NativeBindings
    {
        public static string LibraryDirectory { get; set; }
        private static readonly Dictionary<string, IntPtr> libraries = new();

        public static T Get<T>(string library, string symbol) where T : Delegate
        {
            lock (libraries)
            {
                var windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                var mac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
                if (!libraries.TryGetValue(library, out var handle))
                {
                    var version = library switch
                    {
                        "avcodec" or "avformat" => "60", "avutil" => "58", "swscale" => "7", _ => "4",
                    };
                    var name = windows ? library + "-" + version + ".dll" :
                        mac ? "lib" + library + "." + version + ".dylib" : "lib" + library + ".so." + version;
                    var path = string.IsNullOrEmpty(LibraryDirectory) ? name : Path.Combine(LibraryDirectory, name);
                    handle = windows ? LoadLibraryEx(path, IntPtr.Zero, 8) :
                        mac ? MacOpen(path, 2) : LinuxOpen(path, 2);
                    if (handle == IntPtr.Zero) throw new DllNotFoundException("Cannot load FFmpeg library " + path);
                    libraries.Add(library, handle);
                }

                var address = windows ? GetProcAddress(handle, symbol) :
                    mac ? MacSymbol(handle, symbol) : LinuxSymbol(handle, symbol);
                return address != IntPtr.Zero
                    ? Marshal.GetDelegateForFunctionPointer<T>(address)
                    : throw new EntryPointNotFoundException(library + ": " + symbol);
            }
        }

        [DllImport("kernel32", EntryPoint = "LoadLibraryExW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibraryEx(string name, IntPtr file, uint flags);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr library, string symbol);

        [DllImport("libdl.so.2", EntryPoint = "dlopen")]
        private static extern IntPtr LinuxOpen(string path, int flags);

        [DllImport("libdl.so.2", EntryPoint = "dlsym")]
        private static extern IntPtr LinuxSymbol(IntPtr library, string symbol);

        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr MacOpen(string path, int flags);

        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr MacSymbol(IntPtr library, string symbol);
    }
}
