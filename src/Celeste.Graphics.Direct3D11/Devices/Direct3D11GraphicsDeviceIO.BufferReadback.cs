using System;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO
    {
        public void GetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount)
        {
            GetVertexBufferData(buffer, offset, data, byteCount, 1, 1);
        }

        public void GetVertexBufferData(IntPtr buffer, int offset, IntPtr data,
            int elementCount, int elementSize, int stride)
        {
            var owned = BorrowWriteScope();
            var ticket = IntPtr.Zero;
            try
            {
                try
                {
                    ticket = Direct3D11GraphicsBindings.SourceGpuRecordVertexBufferRead(device,
                        buffer, unchecked((uint)offset), unchecked((uint)elementCount),
                        unchecked((uint)elementSize), unchecked((uint)stride));
                    if (ticket == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
                }
                finally
                {
                    CompleteReadScope(owned);
                }

                CopyCompletedReadback(ticket, data, unchecked(elementCount * elementSize));
            }
            finally
            {
                if (ticket != IntPtr.Zero)
                    Direct3D11GraphicsBindings.SourceGpuReleaseReadback(ticket);
            }
        }
    }
}
