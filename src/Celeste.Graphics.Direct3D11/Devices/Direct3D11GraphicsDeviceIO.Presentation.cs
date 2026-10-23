using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public void ReadBackbuffer(int x, int y, int width, int height, IntPtr data, int dataLength)
        {
            uint owned = BorrowWriteScope();
            IntPtr ticket = IntPtr.Zero;
            try
            {
                try
                {
                    ticket = Direct3D11GraphicsBindings.SourceGpuReadBackbuffer(device,
                        unchecked((uint)x), unchecked((uint)y), unchecked((uint)width), unchecked((uint)height));
                    if (ticket == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
                }
                finally
                {
                    CompleteReadScope(owned);
                }

                CopyCompletedReadback(ticket, data, dataLength);
            }
            finally
            {
                if (ticket != IntPtr.Zero)
                    Direct3D11GraphicsBindings.SourceGpuReleaseReadback(ticket);
            }
        }

        public void SwapBuffers(IntPtr source, IntPtr destination, IntPtr window)
            => PresentRectangles((IntRect*)source, (IntRect*)destination, window);

        public void SwapBuffers(ref IntRect source, IntPtr destination, IntPtr window)
        {
            fixed (IntRect* sourcePointer = &source)
                PresentRectangles(sourcePointer, (IntRect*)destination, window);
        }

        public void SwapBuffers(IntPtr source, ref IntRect destination, IntPtr window)
        {
            fixed (IntRect* destinationPointer = &destination)
                PresentRectangles((IntRect*)source, destinationPointer, window);
        }

        public void SwapBuffers(ref IntRect source, ref IntRect destination, IntPtr window)
        {
            fixed (IntRect* sourcePointer = &source)
            fixed (IntRect* destinationPointer = &destination)
                PresentRectangles(sourcePointer, destinationPointer, window);
        }

        private void PresentRectangles(IntRect* source, IntRect* destination, IntPtr window)
        {
            // The single host output replaces a window swapchain.
            if (window != IntPtr.Zero && window != hostWindow)
                throw new NotSupportedException(
                    "Presenting to an alternate source window is not available by this host graphics transport.");
            BorrowWriteScope();
            bool presentRecorded = false;
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordPresent(device, source, destination));
                presentRecorded = true;
            }
            finally
            {
                // Present seals the current TLS recorder, including any continuation after a read.
                PresentPhysicalPrefix();
                if (presentRecorded) submission.PresentCompleted();
            }
        }
    }
}
