using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Shaders
{
    // Borrowed native pointers, valid only while the owning LinkedSpirvProgram remains undisposed.
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SpirvBinaryView
    {
        public readonly IntPtr Words;
        public readonly uint ByteCount;
        public readonly IntPtr EntryPoint;
    }
}
