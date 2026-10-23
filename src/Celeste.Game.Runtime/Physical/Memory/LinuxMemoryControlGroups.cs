using System;
using System.Globalization;
using System.IO;

namespace Celeste.Game.Runtime.Physical.Memory
{
    internal static class LinuxMemoryControlGroups
    {
        internal static ulong ReadLimit(ulong physical)
        {
            return ReadLimit(physical, "/proc/self/cgroup", "/proc/self/mountinfo");
        }

        internal static ulong ReadLimit(ulong physical, string membershipPath, string mountInfoPath)
        {
            var memberships = File.ReadAllLines(membershipPath);
            foreach (var mount in File.ReadLines(mountInfoPath))
            {
                var separator = mount.IndexOf(" - ", StringComparison.Ordinal);
                var filesystem = mount.Substring(separator + 3).Split(' ');
                var unified = filesystem[0] == "cgroup2";
                if (!unified && (filesystem[0] != "cgroup" ||
                                 Array.IndexOf(filesystem[2].Split(','), "memory") < 0)) continue;
                var fields = mount.Substring(0, separator).Split(' ');
                var root = Unescape(fields[3]);
                var mountPoint = Unescape(fields[4]);
                foreach (var membership in memberships)
                {
                    var first = membership.IndexOf(':');
                    var second = membership.IndexOf(':', first + 1);
                    var controllers = membership.Substring(first + 1, second - first - 1);
                    if (unified ? controllers.Length != 0 : Array.IndexOf(controllers.Split(','), "memory") < 0)
                        continue;
                    var path = membership.Substring(second + 1);
                    string relative;
                    if (root == "/") relative = path.TrimStart('/');
                    else if (path == root) relative = string.Empty;
                    else if (path.StartsWith(root + "/", StringComparison.Ordinal))
                        relative = path.Substring(root.Length + 1);
                    else continue;
                    var directory = Path.GetFullPath(Path.Combine(mountPoint, relative));
                    if (directory != mountPoint &&
                        !directory.StartsWith(mountPoint.TrimEnd(Path.DirectorySeparatorChar) +
                                              Path.DirectorySeparatorChar, StringComparison.Ordinal)) continue;
                    var file = unified ? "memory.max" : "memory.limit_in_bytes";
                    var memberDirectory = true;
                    while (true)
                    {
                        var limitPath = Path.Combine(directory, file);
                        var hierarchyPath = Path.Combine(directory, "memory.use_hierarchy");
                        var applies = memberDirectory || unified || !File.Exists(hierarchyPath) ||
                                      File.ReadAllText(hierarchyPath).Trim() != "0";
                        if (applies && File.Exists(limitPath) && ulong.TryParse(File.ReadAllText(limitPath).Trim(),
                                NumberStyles.None, CultureInfo.InvariantCulture, out var limit))
                            physical = Math.Min(physical, limit);
                        if (directory == mountPoint) break;
                        directory = Path.GetDirectoryName(directory);
                        memberDirectory = false;
                    }
                }
            }

            return physical;
        }

        private static string Unescape(string path)
        {
            return path.Replace("\\040", " ").Replace("\\011", "\t").Replace("\\012", "\n")
                .Replace("\\134", "\\");
        }
    }
}
