using System;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO
{
    public IntPtr GenColorRenderbuffer(int width, int height, SourceSurfaceFormat format,
        int sampleCount, IntPtr texture)
    {
        IntPtr renderbuffer;
        RequireSuccess(api->CreateColorRenderbuffer(device, width, height, format, sampleCount, texture,
            &renderbuffer));
        return renderbuffer;
    }

    public IntPtr GenDepthStencilRenderbuffer(int width, int height, SourceDepthFormat format, int sampleCount)
    {
        IntPtr renderbuffer;
        RequireSuccess(api->CreateDepthRenderbuffer(device, width, height, format, sampleCount, &renderbuffer));
        return renderbuffer;
    }

    public void AddDisposeRenderbuffer(IntPtr renderbuffer) => api->ReleaseRenderbuffer(renderbuffer);
}
