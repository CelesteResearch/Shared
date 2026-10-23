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
    public unsafe struct CelesteGraphicsTextureRegion
    {
        public uint level, layer, x, y, z, width, height, depth;
    }
}
