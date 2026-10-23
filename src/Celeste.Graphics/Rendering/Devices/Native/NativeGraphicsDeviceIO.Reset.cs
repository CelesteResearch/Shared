using System;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO
{
    public void ResetBackbuffer(ref SourceNativePresentationParameters parameters)
    {
        if (parameters.deviceWindowHandle != IntPtr.Zero && parameters.deviceWindowHandle != hostWindow)
            throw new NotSupportedException("The Native graphics submission belongs to a different host window.");
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativePresentationParameters* pointer = &parameters)
                RequireSuccess(api->ConfigureBackbuffer(packet, pointer));
            submission.SetPresentationInterval(parameters.presentationInterval);
        }
        catch
        {
            AbortUnsubmittedPhysicalPrefix();
            throw;
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }
}
