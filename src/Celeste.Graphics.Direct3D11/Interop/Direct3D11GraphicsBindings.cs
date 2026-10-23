using System;
using System.Runtime.InteropServices;
using Celeste.Core.Diagnostics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Direct3D11.Interop
{
    internal static unsafe class Direct3D11GraphicsBindings
    {
        private const string Library = "CelesteGraphicsD3D11";

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuCreateDeviceContext();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuRetainDeviceContext(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuReleaseDeviceContext(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern ulong SourceGpuDeviceGeneration(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuExecutePhysicalPacket(IntPtr device, IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuConfigureFrameOutput(IntPtr device, uint width, uint height);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuReadFrameRgba(IntPtr device, IntPtr destination, uint capacity,
            out uint written);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuGetLastError();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuBeginPhysicalPacket(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuSealPhysicalPacket();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateBuffer(IntPtr device, ref D3D11BufferDesc description, IntPtr bytes,
            out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateTexture2D(IntPtr device, ref D3D11Texture2DDesc description,
            out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateRenderTargetView(IntPtr device, IntPtr texture, IntPtr description,
            out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateShaderResourceView(IntPtr device, IntPtr texture, IntPtr description,
            out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordBufferWrite(IntPtr device, IntPtr buffer, IntPtr bytes, uint count,
            uint offset, uint mapping);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordTextureWrite(IntPtr device, IntPtr texture, uint subresource,
            IntPtr box, IntPtr bytes, uint count, uint rowPitch, uint depthPitch);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordViewport(IntPtr device, ref D3D11Viewport viewport);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordScissor(IntPtr device, ref D3D11Rect rectangle);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordBlend(IntPtr device, ref D3D11BlendDesc description, float* factor,
            uint mask);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordDepthStencil(IntPtr device, ref D3D11DepthStencilDesc description,
            uint stencil);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordRasterizer(IntPtr device, ref D3D11RasterizerDesc description);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSampler(IntPtr device, uint index, IntPtr texture,
            ref D3D11SamplerDesc description, int vertex);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordTargets(IntPtr device, IntPtr* targets, uint count, IntPtr depth);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordClearTarget(IntPtr device, IntPtr target, float* color);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordClearDepth(IntPtr device, IntPtr target, uint flags, float depth,
            byte stencil);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordVertexBuffer(IntPtr device, uint slot, IntPtr buffer, uint stride,
            uint offset);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordIndexBuffer(IntPtr device, IntPtr buffer, uint format, uint offset);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordDraw(IntPtr device, D3D11InputElementDesc* elements,
            uint elementCount, ulong inputHash, uint topology, uint count, uint start, int baseVertex, uint instances,
            int indexed);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuReleaseResource(IntPtr resource);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateEffect(IntPtr device, byte* code, uint length, out IntPtr effect,
            out IntPtr data);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCloneEffect(IntPtr original, out IntPtr effect, out IntPtr data);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuSetEffectTechnique(IntPtr effect, IntPtr technique);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuBeginEffect(IntPtr effect, IntPtr changes);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuBeginPass(IntPtr effect, uint pass);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCommitEffect(IntPtr effect);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuEndPass(IntPtr effect);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuEndEffect(IntPtr effect);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuDisposeEffect(IntPtr effect);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuApplyEffect(IntPtr effect, uint pass, IntPtr changes);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateTexture(IntPtr device, uint format,
            uint width, uint height, uint depth, uint levels, uint arraySize, uint dimension,
            uint renderTarget, uint bytesPerBlock, uint blockWidth, uint blockHeight, out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuDisposeTexture(IntPtr texture);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordTextureData(IntPtr texture, uint level, uint slice,
            uint x, uint y, uint z, uint width, uint height, uint depth, IntPtr bytes, uint length);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordTextureBinding(IntPtr device, uint slot, uint vertexStage,
            IntPtr texture);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuRecordTextureRead(IntPtr texture, uint level, uint slice,
            uint x, uint y, uint z, uint width, uint height, uint depth);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuReadbackCompletion(IntPtr ticket);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuReadbackBytes(IntPtr ticket, out uint length);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuReleaseReadback(IntPtr ticket);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordVertexBufferWrite(IntPtr device, IntPtr buffer,
            uint offset, IntPtr bytes, uint elementCount, uint elementSize, uint stride, uint mapping);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuTryReuseVertexBindings(IntPtr device, out uint owned, out uint reused);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuSetVertexBindings(IntPtr device, D3D11VertexBinding* bindings,
            uint bindingCount, D3D11InputElementDesc* elements, uint elementCount, ulong inputHash);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordBoundDraw(IntPtr device, uint topology,
            uint count, uint start, int baseVertex, uint instances, int indexed);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuHookLogFunctions(
            SourceFnaLogFunction info,
            SourceFnaLogFunction warn,
            SourceFnaLogFunction error);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuRetainPacket(IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuReleasePacket(IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuPacketCompletion(IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuCreateRenderbuffer(IntPtr device, uint width, uint height,
            uint format, uint samples, int sourceDepthFormat, IntPtr optionalTexture, uint slice, out IntPtr result);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuDisposeRenderbuffer(IntPtr renderbuffer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordRenderTargets(IntPtr device, IntPtr* colors,
            uint colorCount, IntPtr depth);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetCurrentDepthFormat(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordResolve(IntPtr colorBuffer, IntPtr texture, uint level, uint slice);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetFormatSupport(IntPtr device, uint format, out uint support);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetMultisampleQuality(IntPtr device, uint format, uint samples,
            out uint quality);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuRecordVertexBufferRead(IntPtr device, IntPtr buffer,
            uint offset, uint elementCount, uint elementSize, uint stride);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordClearRenderbuffer(IntPtr renderbuffer, float* color,
            uint clearColor, uint clearDepth, uint clearStencil, float depth, byte stencil);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetBackbufferDescription(IntPtr device, out uint width,
            out uint height, out uint format, out uint samples, out int depthFormat);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordBackbufferTargets(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordClearBackbuffer(IntPtr device, float* color,
            uint clearColor, uint clearDepth, uint clearStencil, float depth, byte stencil);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordClearCurrent(IntPtr device, float* color,
            uint clearColor, uint clearDepth, uint clearStencil, float depth, byte stencil);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern uint SourceGpuGetBlendFactor(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetSampleMask(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetStencilReference(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordBlendFactor(IntPtr device, uint packedColor);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSampleMask(IntPtr device, int sampleMask);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordStencilReference(IntPtr device, int stencilReference);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceBlend(IntPtr device, ref D3D11BlendDesc state,
            uint packedColor, int sampleMask);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceDepthStencil(IntPtr device,
            ref D3D11DepthStencilDesc state, int stencilReference);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceSampler(IntPtr device, uint slot,
            IntPtr texture, ref D3D11SamplerDesc state, uint vertexStage);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceTargets(IntPtr device,
            SourceNativeRenderTargetBinding* bindings,
            uint count, IntPtr depthBuffer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceResolve(
            SourceNativeRenderTargetBinding* binding);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordTextureCopy(IntPtr source, IntPtr destination);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuBorrowOrBeginPhysicalPacket(IntPtr device, out uint ownsScope);

        internal static void RequireSuccess(int status)
        {
            if (status != 0) return;
            var message = SourceGpuGetLastError();
            throw new InvalidOperationException(message == IntPtr.Zero
                ? "Physical source GPU operation failed without an error message."
                : Marshal.PtrToStringUTF8(message));
        }

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuReadBackbuffer(IntPtr device, uint x, uint y, uint width, uint height);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordPresent(IntPtr device, IntRect* source,
            IntRect* destination);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuDisposeVertexBuffer(IntPtr device, IntPtr buffer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuDisposeIndexBuffer(IntPtr device, IntPtr buffer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuSetTextureName(IntPtr texture, byte* utf8, uint length);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuAllocate(uint bytes);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuFree(IntPtr pointer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuDestroySourceDevice(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuEnsureSourceDevice(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuGetBackbufferSurfaceFormat(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern uint SourceGpuHashSourceVertexBindings(
            SourceNativeVertexBufferBinding* bindings, int count);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSourceBoundDraw(IntPtr device, int sourcePrimitiveType,
            int primitiveCount, uint start, int baseVertex, uint instances, int indexed);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuResetBackbuffer(IntPtr device, uint width, uint height,
            uint colorFormat, uint bytesPerPixel, uint samples, uint depthFormat, int sourceDepth, int sourceSurface);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuInitializeBackbuffer(IntPtr device, uint width, uint height,
            uint colorFormat, uint bytesPerPixel, uint samples, uint depthFormat, int sourceDepth,
            int sourceSurface, uint scaleNearest);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuSetPresentationInterval(IntPtr device, int sourceInterval);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuAddDisposeTexture(IntPtr texture);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern void SourceGpuAddDisposeRenderbuffer(IntPtr renderbuffer);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern IntPtr SourceGpuGetSpriteGroupPacket(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int SourceGpuRecordSpriteGroups(IntPtr device, IntPtr packet,
            SourceSpriteTextureGroup* groups, int count, int baseSprite,
            IntPtr indices, uint indexFormat, ref D3D11RasterizerDesc rasterizer, ref D3D11SamplerDesc sampler,
            ref SourceSpriteGroupProgress progress);
    }
}
