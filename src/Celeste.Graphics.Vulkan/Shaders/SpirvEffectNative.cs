using Celeste.Graphics.Rendering.Devices.Native.Interop;
using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Shaders
{
    internal static class SpirvEffectNative
    {
        private const string Library = "CelesteGraphicsEffects";

        internal static void Require(int result)
        {
            if (result == 0)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8(CelesteSpirvGetError()));
        }

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern IntPtr CelesteSpirvGetError();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern unsafe int CelesteSpirvCreateProgram(IntPtr vertexShader, IntPtr pixelShader,
            SpirvVertexAttribute* attributes, int count, out IntPtr program);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteSpirvGetBinary(IntPtr program, int vertex, out SpirvBinaryView view);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void CelesteSpirvDestroyProgram(IntPtr program);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteSpirvGetVertexLocation(IntPtr program, int usage, int usageIndex,
            out int location);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteSpirvCopyConstants(IntPtr effect, int vertex, IntPtr destination,
            uint capacityBytes);
    }
}
