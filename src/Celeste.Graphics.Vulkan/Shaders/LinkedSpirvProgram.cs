using System;
using Celeste.Graphics.Effects;

namespace Celeste.Graphics.Vulkan.Shaders
{
    // Created once per shader pair/vertex declaration; consumed by native pipeline creation, never per draw.
    public sealed class LinkedSpirvProgram : IDisposable
    {
        private IntPtr handle;

        public unsafe LinkedSpirvProgram(CpuShaderLease vertex, CpuShaderLease pixel,
            ReadOnlySpan<SpirvVertexAttribute> attributes)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));
            if (pixel == null) throw new ArgumentNullException(nameof(pixel));
            var vertexHandle = vertex.BorrowNativeHandle(CpuEffectNative.Instance);
            var pixelHandle = pixel.BorrowNativeHandle(CpuEffectNative.Instance);
            fixed (SpirvVertexAttribute* layout = attributes)
            {
                SpirvEffectNative.Require(SpirvEffectNative.CelesteSpirvCreateProgram(vertexHandle, pixelHandle,
                    layout, attributes.Length, out handle));
            }
        }

        public SpirvBinaryView BorrowBinary(bool vertex)
        {
            if (handle == IntPtr.Zero) throw new ObjectDisposedException(nameof(LinkedSpirvProgram));
            SpirvEffectNative.Require(SpirvEffectNative.CelesteSpirvGetBinary(handle, vertex ? 1 : 0, out var binary));
            return binary;
        }

        // Resolve once when building the vertex input state. Unused semantics return -1.
        public int GetVertexLocation(int usage, int usageIndex)
        {
            if (handle == IntPtr.Zero) throw new ObjectDisposedException(nameof(LinkedSpirvProgram));
            SpirvEffectNative.Require(SpirvEffectNative.CelesteSpirvGetVertexLocation(handle, usage, usageIndex,
                out var location));
            return location;
        }

        // All operations follow the existing device-owner thread contract.
        public void Dispose()
        {
            if (handle == IntPtr.Zero) return;
            SpirvEffectNative.CelesteSpirvDestroyProgram(handle);
            handle = IntPtr.Zero;
        }
    }
}
