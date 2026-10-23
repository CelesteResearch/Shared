using System.Xml;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Formats.Graphics.Atlas
{
    public interface ISourceAtlasLoaderEnvironment
    {
        ISourceAtlasConstruction AtlasConstruction { get; }
        IContentSource ContentFiles { get; }
        string ContentDirectory { get; }
        VirtualContent VirtualContent { get; }
        XmlDocument LoadContentXml(string filename);
    }
}
