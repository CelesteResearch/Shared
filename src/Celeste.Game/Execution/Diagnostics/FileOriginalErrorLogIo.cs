using System.Diagnostics;
using System.IO;

namespace Celeste.Game.Execution.Diagnostics
{
    public sealed class FileOriginalErrorLogIo : IOriginalErrorLogIo
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public TextReader OpenReader(string path)
        {
            return new StreamReader(path);
        }

        public TextWriter OpenWriter(string path, bool append)
        {
            return new StreamWriter(path, append);
        }

        public void OpenDocument(string path)
        {
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }
    }
}
