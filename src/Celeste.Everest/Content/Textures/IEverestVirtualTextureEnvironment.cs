using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Runtime.Failures;
using Celeste.Everest.Runtime.Threading;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Content.Textures
{
    public interface IEverestVirtualTextureEnvironment : ISourceVirtualTextureEnvironment,
        IEverestFastTextureLoadingEnvironment
    {
        bool IsHeadless { get; }
        EverestCoreSettings Settings { get; }
        EverestMainThreadProcess MainThread { get; }

        EverestTextureDataBuffers Buffers { get; }
        EverestContentRegistry Content { get; }
        EverestYamlProcess Yaml { get; }
        ISourceRawImageCodec ImageCodec { get; }
        IEverestVirtualTextureDiagnostics Diagnostics { get; }
        IEverestCriticalFailureProcess Failures { get; }
    }
}
