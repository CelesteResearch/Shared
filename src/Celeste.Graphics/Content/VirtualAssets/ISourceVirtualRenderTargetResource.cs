using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public interface ISourceVirtualRenderTargetResource : IDisposable
    {
        bool IsDisposed { get; }
        bool IsGraphicsDeviceDisposed { get; }
        IntRect Bounds { get; }
        object NativeTarget { get; }
    }
}
