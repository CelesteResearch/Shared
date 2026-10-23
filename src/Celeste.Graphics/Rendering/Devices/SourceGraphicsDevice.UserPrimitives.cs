using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        private int userVertexBufferSize;
        private bool vertexBuffersUpdated;

        private readonly SourceNativeVertexBufferBinding[] nativeBufferBindings =
            new SourceNativeVertexBufferBinding[16];

        public void DrawUserPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int primitiveCount) where T : struct, ISourceVertexType
        {
            ApplyState();
            var gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                vertexOffset, SourceVertexDeclarationCache<T>.VertexDeclaration);
            gCHandle.Free();
            PhysicalIO.DrawPrimitives(primitiveType, 0, primitiveCount);
        }

        public void DrawUserPrimitives<T>(SourcePrimitiveType primitiveType, T[] vertexData, int vertexOffset,
            int primitiveCount, SourceVertexDeclaration vertexDeclaration) where T : struct
        {
            ApplyState();
            var gCHandle = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            PrepareUserVertexBuffer(gCHandle.AddrOfPinnedObject(), PrimitiveVerts(primitiveType, primitiveCount),
                vertexOffset, vertexDeclaration);
            gCHandle.Free();
            PhysicalIO.DrawPrimitives(primitiveType, 0, primitiveCount);
        }

        private unsafe void PrepareUserVertexBuffer(IntPtr vertexData, int numVertices, int vertexOffset,
            SourceVertexDeclaration vertexDeclaration)
        {
            var num = numVertices * vertexDeclaration.VertexStride;
            var num2 = vertexOffset * vertexDeclaration.VertexStride;
            vertexDeclaration.AssignSourceGraphicsDevice(this);
            if (num > userVertexBufferSize)
            {
                if (userVertexBuffer != IntPtr.Zero) PhysicalIO.AddDisposeVertexBuffer(userVertexBuffer);

                userVertexBuffer = PhysicalIO.GenVertexBuffer(1, SourceBufferUsage.WriteOnly, num);
                userVertexBufferSize = num;
            }

            PhysicalIO.SetVertexBufferData(userVertexBuffer, 0, vertexData + num2, num, 1, 1,
                SourceSetDataOptions.Discard);
            fixed (SourceNativeVertexBufferBinding* ptr = &nativeBufferBindings[0])
            {
                ptr->vertexBuffer = userVertexBuffer;
                ptr->vertexDeclaration.vertexStride = vertexDeclaration.VertexStride;
                ptr->vertexDeclaration.elementCount = vertexDeclaration.elements.Length;
                ptr->vertexDeclaration.elements = vertexDeclaration.elementsPin;
                ptr->vertexOffset = 0;
                ptr->instanceFrequency = 0;
                PhysicalIO.ApplyVertexBufferBindings(ptr, 1, 1, 0);
            }

            vertexBuffersUpdated = true;
        }

        private static int PrimitiveVerts(SourcePrimitiveType primitiveType, int primitiveCount)
        {
            return primitiveType switch
            {
                SourcePrimitiveType.TriangleList => primitiveCount * 3,
                SourcePrimitiveType.TriangleStrip => primitiveCount + 2,
                SourcePrimitiveType.LineList => primitiveCount * 2,
                SourcePrimitiveType.LineStrip => primitiveCount + 1,
                SourcePrimitiveType.PointListEXT => primitiveCount,
                _ => throw new InvalidOperationException("Unrecognized primitive type!"),
            };
        }
    }
}
