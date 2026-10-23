using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO
{
    public void ReadBackbuffer(int x, int y, int width, int height, IntPtr data, int dataLength)
    {
        uint owned = BorrowWriteScope();
        IntPtr ticket = IntPtr.Zero;
        try
        {
            try
            {
                var rectangle = new IntRect(x, y, width, height);
                RequireSuccess(api->ReadBackbuffer(packet, &rectangle, &ticket));
            }
            finally
            {
                CompleteReadScope(owned);
            }

            CopyCompletedReadback(ticket, data, dataLength);
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

    private void CopyCompletedReadback(IntPtr ticket, IntPtr destination, int expectedBytes)
    {
        int status = api->GetReadbackStatus(ticket);
        if (status == 2) return; // Only the original compressed-read log/unchanged behavior allows this status.
        if (status < 0) RequireSuccess(0);
        if (status != 1)
            throw new InvalidOperationException(
                "The Native graphics readback did not complete with its submitted prefix.");
        void* bytes;
        uint length;
        RequireSuccess(api->GetReadbackBytes(ticket, &bytes, &length));
        if (expectedBytes < 0 || length < (uint)expectedBytes)
            throw new InvalidOperationException("The Native graphics readback returned fewer bytes than requested.");
        Buffer.MemoryCopy(bytes, (void*)destination, expectedBytes, expectedBytes);
    }
}
