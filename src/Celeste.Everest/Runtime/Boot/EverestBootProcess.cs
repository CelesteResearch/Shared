#nullable enable annotations
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Celeste.Everest.Runtime.Boot
{
    public sealed class EverestBootProcess
    {
        private readonly IEverestBootProcessIo? io;

        public EverestBootProcess(IEverestBootProcessIo? io)
        {
            this.io = io;
        }

        public Process? StartCelesteProcess(string? gameDir = null, bool clearFNAEnv = true)
        {
            if (io == null) return null;
            if (gameDir == null) gameDir = io.ApplicationBaseDirectory;
            var process = new Process();
            // .NET 8 source ProcessStartInfo has an empty constructor and false
            // UseShellExecute. Select that source default explicitly across hosts.
            process.StartInfo.UseShellExecute = false;
            var startInfo = process.StartInfo;
            var path = gameDir;
            object path2;
            if (!io.IsWindows)
            {
                if (!io.IsLinux)
                {
                    if (!io.IsOSX) throw new("Unknown OS platform");
                    path2 = "Celeste";
                }
                else
                {
                    path2 = "Celeste";
                }
            }
            else
            {
                path2 = "Celeste.exe";
            }

            startInfo.FileName = Path.Combine(path, (string)path2);
            process.StartInfo.WorkingDirectory = gameDir;
            if (clearFNAEnv)
            {
                process.StartInfo.Environment.Clear();
                foreach (DictionaryEntry environmentVariable in io.GetEnvironmentVariables())
                {
                    var text = (string)environmentVariable.Key;
                    if (!text.StartsWith("FNA_") && !text.StartsWith("FNA3D_"))
                        process.StartInfo.Environment.Add(text, (string)environmentVariable.Value);
                }
            }

            var escapeArg = new Regex("(\\\\+)$");
            process.StartInfo.Arguments = string.Join(" ", from s in io.GetCommandLineArgs().Skip(1)
                select "\"" + escapeArg.Replace(s, "$1$1") + "\"");
            io.Start(process);
            return process;
        }
    }
}
