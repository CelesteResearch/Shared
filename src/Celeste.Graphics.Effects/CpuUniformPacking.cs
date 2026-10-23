using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuUniformPacking
    {
        public int Type, RegisterIndex, RegisterCount, ByteOffset;
    }
}
