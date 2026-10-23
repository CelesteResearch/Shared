using System.IO;

namespace Celeste.Game.Content.Fonts
{
    public interface IOriginalFontRegistryContentPolicy
    {
        string[] GetFiles(IOriginalFontRegistryProcess process, string path, string pattern, SearchOption searchOption);
        Stream OpenRead(IOriginalFontRegistryProcess process, string path);
    }
}
