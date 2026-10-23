using System.IO;

namespace Celeste.Game.Execution.Diagnostics
{
    public interface IOriginalErrorLogIo
    {
        bool FileExists(string path);
        bool DirectoryExists(string path);
        void CreateDirectory(string path);
        TextReader OpenReader(string path);
        TextWriter OpenWriter(string path, bool append);
        void OpenDocument(string path);
    }
}
