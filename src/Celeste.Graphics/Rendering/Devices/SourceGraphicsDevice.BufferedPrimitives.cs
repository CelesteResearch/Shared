using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        private readonly SourceVertexBufferBinding[] vertexBufferBindings = new SourceVertexBufferBinding[16];
        private int vertexBufferCount;
        private int userIndexBufferSize;
        public SourceIndexBuffer Indices { get; set; }

        public void SetVertexBuffer(SourceVertexBuffer vertexBuffer)
        {
            SetVertexBuffer(vertexBuffer, 0);
        }

        public void SetVertexBuffer(SourceVertexBuffer vertexBuffer, int vertexOffset)
        {
            if (vertexBuffer == null)
            {
                if (vertexBufferCount != 0)
                {
                    for (int i = 0; i < vertexBufferCount; i++)
                    {
                        vertexBufferBindings[i] = SourceVertexBufferBinding.None;
                    }

                    vertexBufferCount = 0;
                    vertexBuffersUpdated = true;
                }

                return;
            }

            if (vertexBufferBindings[0].VertexBuffer != vertexBuffer ||
                vertexBufferBindings[0].VertexOffset != vertexOffset)
            {
                vertexBufferBindings[0] = new SourceVertexBufferBinding(vertexBuffer, vertexOffset);
                vertexBuffersUpdated = true;
            }

            if (vertexBufferCount > 1)
            {
                for (int j = 1; j < vertexBufferCount; j++)
                {
                    vertexBufferBindings[j] = SourceVertexBufferBinding.None;
                }

                vertexBuffersUpdated = true;
            }

            vertexBufferCount = 1;
        }

        public void SetVertexBuffers(params SourceVertexBufferBinding[] vertexBuffers)
        {
            if (vertexBuffers == null)
            {
                if (vertexBufferCount != 0)
                {
                    for (int i = 0; i < vertexBufferCount; i++)
                    {
                        vertexBufferBindings[i] = SourceVertexBufferBinding.None;
                    }

                    vertexBufferCount = 0;
                    vertexBuffersUpdated = true;
                }

                return;
            }

            if (vertexBuffers.Length > vertexBufferBindings.Length)
            {
                throw new ArgumentOutOfRangeException("vertexBuffers",
                    $"Max Vertex Buffers supported is {vertexBufferBindings.Length}");
            }

            int j;
            for (j = 0; j < vertexBuffers.Length; j++)
            {
                if (vertexBufferBindings[j].VertexBuffer != vertexBuffers[j].VertexBuffer ||
                    vertexBufferBindings[j].VertexOffset != vertexBuffers[j].VertexOffset ||
                    vertexBufferBindings[j].InstanceFrequency != vertexBuffers[j].InstanceFrequency)
                {
                    vertexBufferBindings[j] = vertexBuffers[j];
                    vertexBuffersUpdated = true;
                }
            }

            if (vertexBuffers.Length < vertexBufferCount)
            {
                for (; j < vertexBufferCount; j++)
                {
                    vertexBufferBindings[j] = SourceVertexBufferBinding.None;
                }

                vertexBuffersUpdated = true;
            }

            vertexBufferCount = vertexBuffers.Length;
        }

        public SourceVertexBufferBinding[] GetVertexBuffers()
        {
            SourceVertexBufferBinding[] array = new SourceVertexBufferBinding[vertexBufferCount];
            Array.Copy(vertexBufferBindings, array, vertexBufferCount);
            return array;
        }

        public void DrawIndexedPrimitives(SourcePrimitiveType primitiveType, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount)
        {
            ApplyState();
            PrepareVertexBindingArray(baseVertex);
            deviceIO.DrawIndexedPrimitives(primitiveType, baseVertex, minVertexIndex, numVertices, startIndex,
                primitiveCount, Indices.buffer, Indices.IndexElementSize);
        }

        public void DrawInstancedPrimitives(SourcePrimitiveType primitiveType, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, int instanceCount)
        {
            if (deviceIO.SupportsHardwareInstancing() == 0)
            {
                throw new SourceNoSuitableGraphicsDeviceException(
                    "Your hardware does not support hardware instancing!");
            }

            ApplyState();
            PrepareVertexBindingArray(baseVertex);
            deviceIO.DrawInstancedPrimitives(primitiveType, baseVertex, minVertexIndex, numVertices, startIndex,
                primitiveCount, instanceCount, Indices.buffer, Indices.IndexElementSize);
        }

        public void DrawPrimitives(SourcePrimitiveType primitiveType, int vertexStart, int primitiveCount)
        {
            ApplyState();
            PrepareVertexBindingArray(0);
            deviceIO.DrawPrimitives(primitiveType, vertexStart, primitiveCount);
        }

        public void DrawUserIndexedPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int numVertices, short[] indexData, int indexOffset, int primitiveCount) where T : struct, ISourceVertexType
        {
            ApplyState();
            GCHandle gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            GCHandle gCHandle2 = GCHandle.Alloc(indexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), numVertices, vertexOffset,
                SourceVertexDeclarationCache<T>.VertexDeclaration);
            PrepareUserIndexBuffer(gCHandle2.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                indexOffset, 2);
            gCHandle2.Free();
            gCHandle.Free();
            deviceIO.DrawIndexedPrimitives(primitiveType, 0, 0, numVertices, 0, primitiveCount, userIndexBuffer,
                SourceIndexElementSize.SixteenBits);
        }

        public void DrawUserIndexedPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int numVertices, short[] indexData, int indexOffset, int primitiveCount,
            SourceVertexDeclaration vertexDeclaration) where T : struct
        {
            ApplyState();
            GCHandle gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            GCHandle gCHandle2 = GCHandle.Alloc(indexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), numVertices, vertexOffset, vertexDeclaration);
            PrepareUserIndexBuffer(gCHandle2.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                indexOffset, 2);
            gCHandle2.Free();
            gCHandle.Free();
            deviceIO.DrawIndexedPrimitives(primitiveType, 0, 0, numVertices, 0, primitiveCount, userIndexBuffer,
                SourceIndexElementSize.SixteenBits);
        }

        public void DrawUserIndexedPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, ISourceVertexType
        {
            ApplyState();
            GCHandle gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            GCHandle gCHandle2 = GCHandle.Alloc(indexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), numVertices, vertexOffset,
                SourceVertexDeclarationCache<T>.VertexDeclaration);
            PrepareUserIndexBuffer(gCHandle2.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                indexOffset, 4);
            gCHandle2.Free();
            gCHandle.Free();
            deviceIO.DrawIndexedPrimitives(primitiveType, 0, 0, numVertices, 0, primitiveCount, userIndexBuffer,
                SourceIndexElementSize.ThirtyTwoBits);
        }

        public void DrawUserIndexedPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int numVertices, int[] indexData, int indexOffset, int primitiveCount,
            SourceVertexDeclaration vertexDeclaration) where T : struct
        {
            ApplyState();
            GCHandle gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            GCHandle gCHandle2 = GCHandle.Alloc(indexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), numVertices, vertexOffset, vertexDeclaration);
            PrepareUserIndexBuffer(gCHandle2.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                indexOffset, 4);
            gCHandle2.Free();
            gCHandle.Free();
            deviceIO.DrawIndexedPrimitives(primitiveType, 0, 0, numVertices, 0, primitiveCount, userIndexBuffer,
                SourceIndexElementSize.ThirtyTwoBits);
        }

        private unsafe void PrepareVertexBindingArray(int baseVertex)
        {
            fixed (SourceNativeVertexBufferBinding* ptr = &nativeBufferBindings[0])
            {
                for (int i = 0; i < vertexBufferCount; i++)
                {
                    SourceVertexBuffer vertexBuffer = vertexBufferBindings[i].VertexBuffer;
                    ptr[i].vertexBuffer = vertexBuffer.buffer;
                    ptr[i].vertexDeclaration.vertexStride = vertexBuffer.VertexDeclaration.VertexStride;
                    ptr[i].vertexDeclaration.elementCount = vertexBuffer.VertexDeclaration.elements.Length;
                    ptr[i].vertexDeclaration.elements = vertexBuffer.VertexDeclaration.elementsPin;
                    ptr[i].vertexOffset = vertexBufferBindings[i].VertexOffset;
                    ptr[i].instanceFrequency = vertexBufferBindings[i].InstanceFrequency;
                }

                deviceIO.ApplyVertexBufferBindings(ptr, vertexBufferCount, vertexBuffersUpdated ? ((byte)1) : ((byte)0),
                    baseVertex);
            }

            vertexBuffersUpdated = false;
        }

        private void PrepareUserIndexBuffer(IntPtr indexData, int numIndices, int indexOffset,
            int indexElementSizeInBytes)
        {
            int num = numIndices * indexElementSizeInBytes;
            if (num > userIndexBufferSize)
            {
                if (userIndexBuffer != IntPtr.Zero)
                {
                    deviceIO.AddDisposeIndexBuffer(userIndexBuffer);
                }

                userIndexBuffer = deviceIO.GenIndexBuffer(1, SourceBufferUsage.WriteOnly, num);
                userIndexBufferSize = num;
            }

            deviceIO.SetIndexBufferData(userIndexBuffer, 0, indexData + indexOffset * indexElementSizeInBytes, num,
                SourceSetDataOptions.Discard);
        }
    }
}
