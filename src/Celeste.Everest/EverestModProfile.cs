using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Celeste.Everest
{
    // A profile is an explicit Mods root. Merely finding an archive does not load it.
    public sealed class EverestModProfile
    {
        public string ModsDirectory { get; }
        public string WhitelistFile { get; set; }
        public string TemporaryBlacklistFile { get; set; }
        public bool WhitelistFullOverride { get; set; }

        public EverestModProfile(string modsDirectory)
        {
            ModsDirectory = Path.GetFullPath(modsDirectory ?? throw new ArgumentNullException(nameof(modsDirectory)));
        }

        public IReadOnlyList<string> ActiveSources()
        {
            if (!Directory.Exists(ModsDirectory)) return (string[])[];
            var blacklist = ReadNames("blacklist.txt");
            var temporary = ReadNames(TemporaryBlacklistFile);
            var whitelist = WhitelistFile == null ? null : ReadNames(WhitelistFile);

            bool Enabled(string name)
            {
                return WhitelistFullOverride && whitelist != null
                    ? whitelist.Contains(name)
                    : whitelist?.Contains(name) == true || (!blacklist.Contains(name) && !temporary.Contains(name));
            }

            var zips = Directory.GetFiles(ModsDirectory).Where(path => path.EndsWith(".zip", StringComparison.Ordinal))
                .OrderBy(path => path).Where(path => Enabled(Path.GetFileName(path)));
            var dirs = Directory.GetDirectories(ModsDirectory).OrderBy(path => path)
                .Where(path => Path.GetFileName(path) != "Cache" && Enabled(Path.GetFileName(path)));
            return (string[])[.. zips.Concat(dirs)];
        }

        private HashSet<string> ReadNames(string file)
        {
            var names = new HashSet<string>(StringComparer.Ordinal);
            if (string.IsNullOrEmpty(file)) return names;
            var path = Path.IsPathRooted(file) ? file : Path.Combine(ModsDirectory, file);
            if (File.Exists(path))
                foreach (var raw in File.ReadAllLines(path))
                {
                    var value = (raw.StartsWith("#", StringComparison.Ordinal) ? "" : raw).Trim();
                    if (value.Length != 0) names.Add(value);
                }

            return names;
        }
    }
}
