using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuRegisterView
    {
        public IntPtr VertexIdentity, PixelIdentity;
        public IntPtr VertexFloat;
        public uint VertexFloatCount;
        public IntPtr PixelFloat;
        public uint PixelFloatCount;
        public IntPtr VertexInt;
        public uint VertexIntCount;
        public IntPtr PixelInt;
        public uint PixelIntCount;
        public IntPtr VertexBool;
        public uint VertexBoolCount;
        public IntPtr PixelBool;
        public uint PixelBoolCount;
    }
}
