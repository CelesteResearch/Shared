using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Core.Rendering.Resources;
using System.Numerics;

namespace Celeste.Graphics.Rendering.Textures
{
    public enum SourceRenderTargetUsage
    {
        DiscardContents,
        PreserveContents,
        PlatformContents
    }
}
