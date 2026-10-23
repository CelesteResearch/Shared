using System;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteGraphicsBackbufferInfo
    {
        public int width, height;
        public SourceSurfaceFormat format;
        public SourceDepthFormat depthFormat;
        public int multiSampleCount;
    }
}
