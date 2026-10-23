using System.IO;

namespace Celeste.Core.IO.Content
{
    public static class ContentFilePath
    {
        public static string Resolve(string titleLocation, string name)
            => Path.GetFullPath(Path.Combine(titleLocation, Normalize(name)));

        public static string Normalize(string name)
            => name?.Replace(Path.DirectorySeparatorChar == '\\' ? '/' : '\\', Path.DirectorySeparatorChar);
    }
}
