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
            string[] memberships = File.ReadAllLines(membershipPath);
            foreach (string mount in File.ReadLines(mountInfoPath))
            {
                int separator = mount.IndexOf(" - ", StringComparison.Ordinal);
                string[] filesystem = mount.Substring(separator + 3).Split(' ');
                bool unified = filesystem[0] == "cgroup2";
                if (!unified && (filesystem[0] != "cgroup" ||
                                 Array.IndexOf(filesystem[2].Split(','), "memory") < 0)) continue;
                string[] fields = mount.Substring(0, separator).Split(' ');
                string root = Unescape(fields[3]);
                string mountPoint = Unescape(fields[4]);
                foreach (string membership in memberships)
                {
                    int first = membership.IndexOf(':');
                    int second = membership.IndexOf(':', first + 1);
                    string controllers = membership.Substring(first + 1, second - first - 1);
                    if (unified ? controllers.Length != 0 : Array.IndexOf(controllers.Split(','), "memory") < 0)
                        continue;
                    string path = membership.Substring(second + 1);
                    string relative;
                    if (root == "/") relative = path.TrimStart('/');
                    else if (path == root) relative = string.Empty;
                    else if (path.StartsWith(root + "/", StringComparison.Ordinal))
                        relative = path.Substring(root.Length + 1);
                    else continue;
                    string directory = Path.GetFullPath(Path.Combine(mountPoint, relative));
                    if (directory != mountPoint &&
                        !directory.StartsWith(mountPoint.TrimEnd(Path.DirectorySeparatorChar) +
                                              Path.DirectorySeparatorChar, StringComparison.Ordinal)) continue;
                    string file = unified ? "memory.max" : "memory.limit_in_bytes";
                    bool memberDirectory = true;
                    while (true)
                    {
                        string limitPath = Path.Combine(directory, file);
                        string hierarchyPath = Path.Combine(directory, "memory.use_hierarchy");
                        bool applies = memberDirectory || unified || !File.Exists(hierarchyPath) ||
                                       File.ReadAllText(hierarchyPath).Trim() != "0";
                        if (applies && File.Exists(limitPath) && ulong.TryParse(File.ReadAllText(limitPath).Trim(),
                                NumberStyles.None, CultureInfo.InvariantCulture, out ulong limit))
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
