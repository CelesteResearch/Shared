using System.IO;

namespace Celeste.Core.IO.Content
{
    public static class ContentFilePath
    {
        public static string Resolve(string titleLocation, string name)
        {
            return Path.GetFullPath(Path.Combine(titleLocation, Normalize(name)));
        }

        public static string Normalize(string name)
        {
            return name?.Replace(Path.DirectorySeparatorChar == '\\' ? '/' : '\\', Path.DirectorySeparatorChar);
        }
    }
}
