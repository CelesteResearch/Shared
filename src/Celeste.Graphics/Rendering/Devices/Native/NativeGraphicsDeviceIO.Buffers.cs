using System;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        public IntPtr GenVertexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount)
        {
            return CreatePhysicalBuffer(0, dynamic, usage, byteCount);
        }

        public IntPtr GenIndexBuffer(byte dynamic, SourceBufferUsage usage, int byteCount)
        {
            return CreatePhysicalBuffer(1, dynamic, usage, byteCount);
        }

        private IntPtr CreatePhysicalBuffer(byte indexBuffer, byte dynamic, SourceBufferUsage usage, int byteCount)
        {
            IntPtr buffer;
            RequireSuccess(api->CreateBuffer(device, indexBuffer, dynamic, usage, byteCount, &buffer));
            SourceFrameDiagnostics.Current?.RecordLoadResource(false, false);
            return buffer;
        }

        public void AddDisposeVertexBuffer(IntPtr buffer)
        {
            SourceFrameDiagnostics.Current?.RecordLoadResource(false, true);
            api->ReleaseBuffer(buffer);
        }

        public void AddDisposeIndexBuffer(IntPtr buffer)
        {
            AddDisposeVertexBuffer(buffer);
        }

        public void SetVertexBufferData(IntPtr buffer, int offset, IntPtr data, int elementCount,
            int elementSize, int stride, SourceSetDataOptions options)
        {
            var owned = BorrowWriteScope();
            SourceFrameDiagnostics.Current?.RecordLoadUpload(false,
                (long)elementCount * elementSize);
            try
            {
                RequireSuccess(api->WriteBuffer(packet, buffer, offset, (void*)data, elementCount, elementSize, stride,
                    options));
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

        public void GetIndexBufferData(IntPtr buffer, int offset, IntPtr data, int byteCount)
        {
            GetVertexBufferData(buffer, offset, data, byteCount, 1, 1);
        }

        public void GetVertexBufferData(IntPtr buffer, int offset, IntPtr data, int elementCount, int elementSize,
            int stride)
        {
            var owned = BorrowWriteScope();
            var ticket = IntPtr.Zero;
            try
            {
                try
                {
                    RequireSuccess(api->ReadBuffer(packet, buffer, offset, elementCount, elementSize, stride, &ticket));
                }
                finally
                {
                    CompleteReadScope(owned);
                }

                CopyCompletedReadback(ticket, data, checked(elementCount * elementSize));
            }
            catch
            {
                AbortUnsubmittedPhysicalPrefix();
                throw;
            }
            finally
            {
                if (ticket != IntPtr.Zero) api->ReleaseReadback(ticket);
            }
        }

        public IntPtr Allocate(int bytes)
        {
            void* pointer;
            RequireSuccess(api->Allocate(unchecked((uint)bytes), &pointer));
            return (IntPtr)pointer;
        }

        public void Free(IntPtr pointer)
        {
            api->Free((void*)pointer);
        }
    }
}
