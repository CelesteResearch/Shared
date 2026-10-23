using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuShaderSampler
    {
        public int Type;
        public int Index;
        public IntPtr Name;
        public int TexBem;
    }
}
