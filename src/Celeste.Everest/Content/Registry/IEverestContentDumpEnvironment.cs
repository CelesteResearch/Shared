using Celeste.Everest.Content.Serialization;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Everest.Content.Registry
{
    public interface IEverestContentDumpEnvironment
    {
        ISourceDataTextureFactory TextureFactory { get; }
        ISourceTexturePngWriter PngWriter { get; }
        EverestYamlProcess Yaml { get; }
        IEverestContentDumpDiagnostics Diagnostics { get; }
    }
}
