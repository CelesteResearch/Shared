using System;
using Celeste.Everest.Runtime.Failures;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Runtime.Threading;

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
