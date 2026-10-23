using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeVertexBufferBinding
    {
        public IntPtr vertexBuffer;
        public SourceNativeVertexDeclaration vertexDeclaration;
        public int vertexOffset;
        public int instanceFrequency;
    }
}
