using System.IO;

namespace Celeste.Core.IO.Content
{
    public interface IContentSource
    {
        string TitleLocation { get; }
        Stream OpenTitleStream(string name);
        bool FileExists(string name);
        string[] GetFiles(string directory, SearchOption searchOption = SearchOption.TopDirectoryOnly);
    }
}
