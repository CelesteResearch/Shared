using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Devices.Native.Interop;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO : ISourceGraphicsDeviceTargetIO
{
    public void SetViewport(ref CameraViewport viewport)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (CameraViewport* pointer = &viewport)
                RequireSuccess(api->SetViewport(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void SetScissorRect(ref IntRect rectangle)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (IntRect* pointer = &rectangle)
                RequireSuccess(api->SetScissorRect(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public SourceDepthFormat GetBackbufferDepthFormat()
    {
        CelesteGraphicsBackbufferInfo info;
        RequireSuccess(api->GetBackbufferInfo(device, &info));
        return info.depthFormat;
    }

    public void Clear(SourceClearOptions options, ref Vector4 color, float depth, int stencil)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (Vector4* pointer = &color)
                RequireSuccess(api->Clear(packet, options, (float*)pointer, depth, stencil));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void SetRenderTargets(SourceNativeRenderTargetBinding* targets, int count,
        IntPtr depthStencilBuffer, SourceDepthFormat depthFormat, byte preserve)
    {
        uint owned = BorrowWriteScope();
        try
        {
            RequireSuccess(api->SetRenderTargets(packet, targets, count, depthStencilBuffer, depthFormat, preserve));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void SetRenderTargets(IntPtr targets, int count, IntPtr depthStencilBuffer,
        SourceDepthFormat depthFormat, byte preserve)
        => SetRenderTargets((SourceNativeRenderTargetBinding*)targets, count, depthStencilBuffer, depthFormat,
            preserve);

    public void ResolveTarget(ref SourceNativeRenderTargetBinding binding)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativeRenderTargetBinding* pointer = &binding)
                RequireSuccess(api->ResolveTarget(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }
}
