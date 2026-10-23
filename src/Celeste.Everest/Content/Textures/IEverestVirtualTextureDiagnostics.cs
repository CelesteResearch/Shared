using System;
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
    public interface IEverestVirtualTextureDiagnostics
    {
        void InvalidPngMagic(ulong value, string path);
        void InvalidPngFirstChunkLength(uint value, string path);
        void InvalidPngHeaderMarker(uint value, string path);
    }
}
