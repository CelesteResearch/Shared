using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public unsafe interface ISourceGraphicsDeviceTargetIO
    {
        void SetViewport(ref CameraViewport viewport);
        void SetScissorRect(ref IntRect rectangle);
        SourceDepthFormat GetBackbufferDepthFormat();
        void Clear(SourceClearOptions options, ref Vector4 color, float depth, int stencil);

        void SetRenderTargets(SourceNativeRenderTargetBinding* targets, int count,
            IntPtr depthStencilBuffer, SourceDepthFormat depthFormat, byte preserve);

        void SetRenderTargets(IntPtr targets, int count,
            IntPtr depthStencilBuffer, SourceDepthFormat depthFormat, byte preserve);

        void ResolveTarget(ref SourceNativeRenderTargetBinding binding);
    }
}
