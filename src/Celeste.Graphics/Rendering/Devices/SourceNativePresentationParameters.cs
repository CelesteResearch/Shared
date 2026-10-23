using Celeste.Core.Display;
using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativePresentationParameters
    {
        public int backBufferWidth;

        public int backBufferHeight;

        public SourceSurfaceFormat backBufferFormat;

        public int multiSampleCount;

        public IntPtr deviceWindowHandle;

        public byte isFullScreen;

        public SourceDepthFormat depthStencilFormat;

        public SourcePresentInterval presentationInterval;

        public SourceDisplayOrientation displayOrientation;

        public SourceRenderTargetUsage renderTargetUsage;
    }
}
