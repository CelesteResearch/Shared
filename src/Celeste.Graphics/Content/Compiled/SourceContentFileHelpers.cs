using System;
using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    internal static class SourceContentFileHelpers
    {
        public static readonly char ForwardSlash = '/';

        public static readonly string ForwardSlashString = new string(ForwardSlash, 1);

        public static readonly char BackwardSlash = '\\';

        public static readonly char NotSeparator =
            ((Path.DirectorySeparatorChar == BackwardSlash) ? ForwardSlash : BackwardSlash);

        public static readonly char Separator = Path.DirectorySeparatorChar;

        public static string NormalizeFilePathSeparators(string name)
        {
            return name.Replace(NotSeparator, Separator);
        }

        /// <summary>
        /// Combines the filePath and relativeFile based on relativeFile being a file in the same location as filePath.
        /// Relative directory operators (..) are also resolved
        /// </summary>
        /// <example>"A\B\C.txt","D.txt" becomes "A\B\D.txt"</example>
        /// <example>"A\B\C.txt","..\D.txt" becomes "A\D.txt"</example>
        /// <param name="filePath">Path to the file we are starting from</param>
        /// <param name="relativeFile">Relative location of another file to resolve the path to</param>
        public static string ResolveRelativePath(string filePath, string relativeFile)
        {
            filePath = filePath.Replace(BackwardSlash, ForwardSlash);
            while (filePath.Contains("//"))
            {
                filePath = filePath.Replace("//", "/");
            }

            bool num = filePath.StartsWith(ForwardSlashString);
            if (!num)
            {
                filePath = ForwardSlashString + filePath;
            }

            string text = new Uri(new Uri("file://" + filePath), relativeFile).LocalPath;
            if (!num && text.StartsWith("/"))
            {
                text = text.Substring(1);
            }

            return NormalizeFilePathSeparators(text);
        }
    }
}
