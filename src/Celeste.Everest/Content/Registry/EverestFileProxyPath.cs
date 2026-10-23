using System.IO;
using Celeste.Core.IO.Content;

namespace Celeste.Everest.Content.Registry
{
    public static class EverestFileProxyPath
    {
        public static string Modize(string path, EverestContentRegistry content)
        {
            path = ContentFilePath.Normalize(path);
            string directoryName = Path.GetDirectoryName(path);
            path = Path.GetFileNameWithoutExtension(path);
            if (!string.IsNullOrEmpty(directoryName)) path = Path.Combine(directoryName, path);
            if (path.StartsWith(content.PathContentOrig))
                path = path.Substring(content.PathContentOrig.Length + 1);
            path = path.Replace('\\', '/');
            return path;
        }
    }
}
