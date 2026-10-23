using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Celeste.Recorder
{
    public static class RecorderEncoderCapabilities
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint VersionFunction();

        private static readonly Dictionary<string, bool> binaryChecked = new Dictionary<string, bool>();
        private static readonly Dictionary<string, bool> nativeChecked = new Dictionary<string, bool>();

        public static string[] BinaryVersion(string path)
        {
            using (var process = Process.Start(new ProcessStartInfo(path, "-version")
                   {
                       UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true,
                       RedirectStandardError = true
                   }))
            {
                var error = process.StandardError.ReadToEndAsync();
                string text = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (process.ExitCode != 0) throw new IOException(error.GetAwaiter().GetResult());
                return text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static bool BinaryInstalled(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return false;
            lock (binaryChecked)
            {
                if (binaryChecked.TryGetValue(path, out bool found)) return found;
                try
                {
                    BinaryVersion(path);
                    found = true;
                }
                catch
                {
                    found = false;
                }

                return binaryChecked[path] = found;
            }
        }

        public static IReadOnlyDictionary<string, string> NativeVersions(string directory)
        {
            FFmpeg.NativeBindings.LibraryDirectory = directory;
            var result = new Dictionary<string, string>();
            foreach (var item in new[]
                         { ("avutil", 58), ("avformat", 60), ("avcodec", 60), ("swresample", 4), ("swscale", 7) })
            {
                uint version = FFmpeg.NativeBindings.Get<VersionFunction>(item.Item1, item.Item1 + "_version")();
                if (version < (uint)(item.Item2 << 16))
                    throw new NotSupportedException(item.Item1 + " version is too old.");
                result[item.Item1] = $"{version >> 16}.{(version >> 8) & 255}.{version & 255}";
            }

            return result;
        }

        public static bool LibrariesInstalled(string directory)
        {
            string key = directory ?? "";
            lock (nativeChecked)
            {
                if (nativeChecked.TryGetValue(key, out bool found)) return found;
                try
                {
                    NativeVersions(directory);
                    found = true;
                }
                catch
                {
                    found = false;
                }

                return nativeChecked[key] = found;
            }
        }

        public static bool Available(RecorderSettings settings) => BinaryInstalled(settings.FFmpegPath) ||
                                                                   LibrariesInstalled(settings.NativeLibraryDirectory);
    }
}
