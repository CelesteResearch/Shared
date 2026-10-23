using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuShaderDescription
    {
        public IntPtr Profile;
        public IntPtr EntryPoint;
        public IntPtr Tokens;
        public uint TokenLength;
        public IntPtr Swizzles;
        public uint SwizzleCount;
        public IntPtr SamplerMap;
        public uint SamplerMapCount;
        public IntPtr Parsed;
        public int FloatCount, IntCount, BoolCount;
        public int Stage;
        public IntPtr Output;
        public int OutputLength;
        public IntPtr OutputEntryPoint;
        public IntPtr Uniforms;
        public int UniformCount;
        public IntPtr Samplers;
        public int SamplerCount;
        public IntPtr Attributes;
        public int AttributeCount;
        public IntPtr Outputs;
        public int OutputCount;
        public IntPtr Identity;
        public IntPtr Packing;
        public int PackingCount, ConstantBufferBytes;
    }
}
