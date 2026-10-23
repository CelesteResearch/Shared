using System.Xml;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Formats.Graphics.Atlas
{
    public interface ISourceAtlasLoaderEnvironment
    {
        Celeste.Graphics.Content.Atlas.ISourceAtlasConstruction AtlasConstruction { get; }
        Celeste.Core.IO.Content.IContentSource ContentFiles { get; }
        string ContentDirectory { get; }
        VirtualContent VirtualContent { get; }
        XmlDocument LoadContentXml(string filename);
    }
}
