using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public void GetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount)
            => GetVertexBufferData(buffer, offset, data, byteCount, 1, 1);

        public void GetVertexBufferData(IntPtr buffer, int offset, IntPtr data,
            int elementCount, int elementSize, int stride)
        {
            uint owned = BorrowWriteScope();
            IntPtr ticket = IntPtr.Zero;
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
