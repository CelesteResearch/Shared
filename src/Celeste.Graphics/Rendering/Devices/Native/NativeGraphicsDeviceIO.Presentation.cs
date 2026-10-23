using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        public void SwapBuffers(IntPtr source, IntPtr destination, IntPtr window)
        {
            PresentRectangles((IntRect*)source, (IntRect*)destination, window);
        }

        public void SwapBuffers(ref IntRect source, IntPtr destination, IntPtr window)
        {
            fixed (IntRect* pointer = &source)
            {
                PresentRectangles(pointer, (IntRect*)destination, window);
            }
        }

        public void SwapBuffers(IntPtr source, ref IntRect destination, IntPtr window)
        {
            fixed (IntRect* pointer = &destination)
            {
                PresentRectangles((IntRect*)source, pointer, window);
            }
        }

        public void SwapBuffers(ref IntRect source, ref IntRect destination, IntPtr window)
        {
            fixed (IntRect* sourcePointer = &source)
            fixed (IntRect* destinationPointer = &destination)
            {
                PresentRectangles(sourcePointer, destinationPointer, window);
            }
        }

        private void PresentRectangles(IntRect* source, IntRect* destination, IntPtr window)
        {
            if (window != IntPtr.Zero && window != hostWindow)
                throw new NotSupportedException("The Native graphics submission belongs to a different host window.");
            BorrowWriteScope();
            var output = IntPtr.Zero;
            try
            {
                output = submission.AcquireOutput(device);
                if (output == IntPtr.Zero) RequireSuccess(0);
                RequireSuccess(api->PresentBackbuffer(packet, output, source, destination));
                FlushPhysicalPrefix(false);
                submission.PresentCompleted();
            }
            catch
            {
                AbortUnsubmittedPhysicalPrefix();
                throw;
            }
            finally
            {
                if (output != IntPtr.Zero) api->ReleaseOutput(output);
            }
        }
    }
}
