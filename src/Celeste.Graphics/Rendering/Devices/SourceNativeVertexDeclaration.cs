using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeVertexDeclaration
    {
        public int vertexStride;
        public int elementCount;
        public IntPtr elements;
    }
}
