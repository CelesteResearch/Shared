using Celeste.Core.Display;
using System;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Display;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public unsafe interface ISourceGraphicsDeviceIO : ISourceGraphicsDeviceStateIO, ISourceGraphicsDeviceTargetIO
    {
        ISourceTextureIO TextureIO { get; }
        void GetBlendFactor(out PackedColor color);
        void SetBlendFactor(ref PackedColor color);
        int GetMultiSampleMask();
        void SetMultiSampleMask(int mask);
        int GetReferenceStencil();
        void SetReferenceStencil(int stencil);
        void GetBackbufferSize(out int width, out int height);
        SourceSurfaceFormat GetBackbufferSurfaceFormat();
        void ReadBackbuffer(int x, int y, int width, int height, IntPtr data, int dataLength);
        IntPtr CreateDevice(ref SourceNativePresentationParameters parameters, byte debugMode);
        IntPtr GenVertexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount);

        void SetVertexBufferData(IntPtr buffer, int offset, IntPtr data, int elementCount,
            int elementSize, int stride, SourceSetDataOptions options);

        void ApplyVertexBufferBindings(SourceNativeVertexBufferBinding* bindings, int count, byte updated,
            int baseVertex);

        void DrawPrimitives(SourcePrimitiveType primitiveType, int startVertex, int primitiveCount);
        byte SupportsNoOverwrite();
        byte SupportsHardwareInstancing();

        void DrawIndexedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex, int numVertices,
            int startIndex, int primitiveCount, IntPtr indices, SourceIndexElementSize indexSize);

        void DrawInstancedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex, int numVertices,
            int startIndex, int primitiveCount, int instanceCount, IntPtr indices, SourceIndexElementSize indexSize);

        IntPtr GenIndexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount);
        void SetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount, SourceSetDataOptions options);
        void GetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount);
        void GetVertexBufferData(IntPtr buffer, int offset, IntPtr data, int elementCount, int elementSize, int stride);
        void ResetBackbuffer(ref SourceNativePresentationParameters parameters);
        void SwapBuffers(IntPtr source, IntPtr destination, IntPtr window);
        void SwapBuffers(ref IntRect source, IntPtr destination, IntPtr window);
        void SwapBuffers(IntPtr source, ref IntRect destination, IntPtr window);
        void SwapBuffers(ref IntRect source, ref IntRect destination, IntPtr window);
        void GetMaxTextureSlots(out int fragmentSlots, out int vertexSlots);
        IntPtr Allocate(int bytes);
        void Free(IntPtr pointer);
        void DestroyDevice();
        void AddDisposeVertexBuffer(IntPtr buffer);
        void AddDisposeIndexBuffer(IntPtr buffer);
        void CreateEffect(byte[] code, int length, out IntPtr effect, out IntPtr effectData);
        void CloneEffect(IntPtr originalEffect, out IntPtr effect, out IntPtr effectData);
        void SetEffectTechnique(IntPtr effect, IntPtr technique);
        void AddDisposeEffect(IntPtr effect);
        void ApplyEffect(IntPtr effect, uint pass, IntPtr changes);
    }
}
