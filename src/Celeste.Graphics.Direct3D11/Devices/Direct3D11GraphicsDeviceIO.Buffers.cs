using System;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public IntPtr GenVertexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount)
        {
            return CreatePhysicalBuffer(dynamic, byteCount, 1);
        }

        public IntPtr GenIndexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount)
        {
            return CreatePhysicalBuffer(dynamic, byteCount, 2);
        }

        private IntPtr CreatePhysicalBuffer(byte dynamic, int byteCount, uint bindFlags)
        {
            // FNA3D's D3D11 descriptor does not use the BufferUsage argument.
            var description = new D3D11BufferDesc
            {
                ByteWidth = unchecked((uint)byteCount),
                Usage = dynamic != 0 ? 2u : 0u,
                BindFlags = bindFlags,
                CPUAccessFlags = dynamic != 0 ? 65536u : 0u,
                MiscFlags = 0,
                StructureByteStride = 0,
            };
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuCreateBuffer(device, ref description,
                    IntPtr.Zero, out var buffer));
            SourceFrameDiagnostics.Current?.RecordLoadResource(false, false);
            return buffer;
        }

        private static uint GetBufferWriteMapping(IntPtr buffer, SourceSetDataOptions options)
        {
            // The returned resource is ID3D11Buffer; GetDesc is vtable slot 10.
            D3D11BufferDesc description;
            var vtable = *(IntPtr**)buffer;
            var getDesc = (delegate* unmanaged[Stdcall]<IntPtr, D3D11BufferDesc*, void>)vtable[10];
            getDesc(buffer, &description);
            return description.Usage == 2u
                ? options == SourceSetDataOptions.NoOverwrite ? 5u : 4u
                : 0u;
        }

        public void SetVertexBufferData(IntPtr buffer, int offset, IntPtr data, int elementCount,
            int elementSize, int stride, SourceSetDataOptions options)
        {
            var owned = BorrowWriteScope();
            SourceFrameDiagnostics.Current?.RecordLoadUpload(false,
                (long)elementCount * elementSize);
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordVertexBufferWrite(device, buffer,
                        unchecked((uint)offset), data, unchecked((uint)elementCount),
                        unchecked((uint)elementSize), unchecked((uint)stride),
                        GetBufferWriteMapping(buffer, options)));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount,
            SourceSetDataOptions options)
        {
            SetVertexBufferData(buffer, offset, data, byteCount, 1, 1, options);
        }
    }
}
