using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        private static readonly byte[] vertexSemanticNames = System.Text.Encoding.ASCII.GetBytes(
            "POSITION\0COLOR\0TEXCOORD\0NORMAL\0BINORMAL\0TANGENT\0BLENDINDICES\0BLENDWEIGHT\0SV_DEPTH\0FOG\0PSIZE\0SV_SampleIndex\0TESSFACTOR\0");

        private static readonly int[] vertexSemanticOffsets = { 0, 9, 15, 24, 31, 40, 48, 61, 73, 82, 86, 92, 107 };

        public void ApplyVertexBufferBindings(SourceNativeVertexBufferBinding* bindings,
            int count, byte updated, int baseVertex)
        {
            if (updated == 0)
            {
                uint ownedScope = 0;
                uint reused;
                try
                {
                    Direct3D11GraphicsBindings.RequireSuccess(
                        Direct3D11GraphicsBindings.SourceGpuTryReuseVertexBindings(device,
                            out ownedScope, out reused));
                    if (reused != 0) return;
                }
                finally
                {
                    CompleteWriteScope(ownedScope);
                }
            }

            int elementCount = 0;
            for (int i = 0; i < count; i++)
                elementCount = unchecked(elementCount + bindings[i].vertexDeclaration.elementCount);
            Span<D3D11VertexBinding> physicalBindings = (uint)count <= 16u
                ? stackalloc D3D11VertexBinding[count]
                : new D3D11VertexBinding[count];
            Span<D3D11InputElementDesc> descriptions = (uint)elementCount <= 32u
                ? stackalloc D3D11InputElementDesc[elementCount]
                : new D3D11InputElementDesc[elementCount];

            uint owned = BorrowWriteScope();
            try
            {
                int destination = 0;
                for (int slot = 0; slot < count; slot++)
                {
                    SourceNativeVertexBufferBinding binding = bindings[slot];
                    physicalBindings[slot] = new D3D11VertexBinding
                    {
                        Buffer = binding.vertexBuffer,
                        Stride = unchecked((uint)binding.vertexDeclaration.vertexStride),
                        Offset = unchecked((uint)(binding.vertexOffset * binding.vertexDeclaration.vertexStride))
                    };
                    var elements = (SourceVertexElement*)binding.vertexDeclaration.elements;
                    for (int i = 0; i < binding.vertexDeclaration.elementCount; i++, destination++)
                    {
                        SourceVertexElement element = elements[i];
                        int semanticOffset = vertexSemanticOffsets[(int)element.VertexElementUsage];
                        descriptions[destination] = new D3D11InputElementDesc
                        {
                            SemanticName = (IntPtr)semanticOffset,
                            SemanticIndex = unchecked((uint)element.UsageIndex),
                            Format = D3D11Conversions.VertexFormat((int)element.VertexElementFormat),
                            InputSlot = unchecked((uint)slot),
                            AlignedByteOffset = unchecked((uint)element.Offset),
                            InputSlotClass = binding.instanceFrequency > 0 ? 1u : 0u,
                            InstanceDataStepRate = binding.instanceFrequency > 0
                                ? unchecked((uint)binding.instanceFrequency)
                                : 0u
                        };
                    }
                }

                uint hash = Direct3D11GraphicsBindings.SourceGpuHashSourceVertexBindings(bindings, count);
                fixed (byte* names = vertexSemanticNames)
                {
                    for (int i = 0; i < elementCount; i++)
                        descriptions[i].SemanticName = (IntPtr)(names + descriptions[i].SemanticName.ToInt32());
                    fixed (D3D11VertexBinding* physical = physicalBindings)
                    fixed (D3D11InputElementDesc* description = descriptions)
                        Direct3D11GraphicsBindings.RequireSuccess(
                            Direct3D11GraphicsBindings.SourceGpuSetVertexBindings(device,
                                physical, unchecked((uint)count), description, unchecked((uint)elementCount), hash));
                }
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void DrawPrimitives(SourcePrimitiveType type, int startVertex, int primitiveCount)
            => DrawPhysical(type, primitiveCount, startVertex, 0, 1, IntPtr.Zero, default, false);

        public void DrawIndexedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, IntPtr indices, SourceIndexElementSize indexSize)
            => DrawPhysical(type, primitiveCount, startIndex, baseVertex, 1, indices, indexSize, true);

        public void DrawInstancedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, int instanceCount, IntPtr indices,
            SourceIndexElementSize indexSize)
            => DrawPhysical(type, primitiveCount, startIndex, baseVertex, instanceCount, indices, indexSize, true);

        private void DrawPhysical(SourcePrimitiveType type, int primitiveCount, int start, int baseVertex,
            int instances, IntPtr indices, SourceIndexElementSize indexSize, bool indexed)
        {
            uint owned = BorrowWriteScope();
            try
            {
                if (indexed)
                    Direct3D11GraphicsBindings.RequireSuccess(
                        Direct3D11GraphicsBindings.SourceGpuRecordIndexBuffer(device, indices,
                            D3D11Conversions.IndexFormat((int)indexSize), 0));
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSourceBoundDraw(device,
                        (int)type, primitiveCount, unchecked((uint)start), baseVertex,
                        unchecked((uint)instances), indexed ? 1 : 0));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
