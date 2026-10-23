using System.IO;

namespace Celeste.Everest.Content.Graphics
{
    public interface IEverestGraphicsContentIo
    {
        bool OriginalXmlExists(string path);
        Stream OpenOriginalXml(string path);
    }
}
