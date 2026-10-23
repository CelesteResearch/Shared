using System;
using System.Collections.Generic;

namespace Celeste.Everest.Content.Registry
{
    public static class EverestContentPath
    {
        internal static readonly char[] DirectorySeparators = ['/'];

        public static string ResolveTyped(string path)
        {
            var parts = new List<string>(path.Replace('\\', '/').Split(
                DirectorySeparators, StringSplitOptions.RemoveEmptyEntries));
            for (var i = 0; i < parts.Count; i++)
                if (parts[i] == "..")
                {
                    parts.RemoveAt(i);
                    parts.RemoveAt(i - 1);
                    i -= 2;
                }
                else if (parts[i] == ".")
                {
                    parts.RemoveAt(i);
                    i--;
                }

            return string.Join("/", parts);
        }
    }
}
