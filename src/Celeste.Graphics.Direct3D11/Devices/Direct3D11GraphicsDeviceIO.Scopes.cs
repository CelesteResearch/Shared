using System;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        // Only the native TLS recorder owns the active physical prefix. The source batch stays open.
        internal void BeforeDraw()
        {
            var packet = Direct3D11GraphicsBindings.SourceGpuBeginPhysicalPacket(device);
            if (packet == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
        }

        public static void AbortUnsubmittedPhysicalPrefix()
        {
            // Sealing first clears the native thread-local recorder. Release discards
            // the failed frame's retained commands without presenting partial output.
            var packet = Direct3D11GraphicsBindings.SourceGpuSealPhysicalPacket();
            if (packet != IntPtr.Zero)
                Direct3D11GraphicsBindings.SourceGpuReleasePacket(packet);
        }

        internal void PresentPhysicalPrefix()
        {
            FlushPhysicalPrefix();
        }

        private void FlushPhysicalPrefix()
        {
            var packet = Direct3D11GraphicsBindings.SourceGpuSealPhysicalPacket();
            if (packet == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            try
            {
                SubmitMeasured(packet);
            }
            finally
            {
                Direct3D11GraphicsBindings.SourceGpuReleasePacket(packet);
            }
        }

        private void CompleteReadScope(uint owned)
        {
            SourceFrameDiagnostics.Current?.RecordLoadRead(owned);
            // A borrowed frame is split at the synchronous read, then continues in a fresh recorder.
            // This does not call SourceSpriteBatch.End/Begin or copy source device state.
            try
            {
                FlushPhysicalPrefix();
            }
            finally
            {
                if (owned == 0) BeforeDraw();
            }
        }

        private void CopyCompletedReadback(IntPtr ticket, IntPtr destination, int expectedBytes)
        {
            var completion = Direct3D11GraphicsBindings.SourceGpuReadbackCompletion(ticket);
            if (completion == 2) return; // Original compressed GetData logs and leaves the buffer untouched.
            if (completion != 1) Direct3D11GraphicsBindings.RequireSuccess(0);
            var bytes = Direct3D11GraphicsBindings.SourceGpuReadbackBytes(ticket, out var length);
            if (length < unchecked((uint)expectedBytes))
                throw new InvalidOperationException("The physical readback returned fewer bytes than requested.");
            Buffer.MemoryCopy((void*)bytes, (void*)destination, expectedBytes, expectedBytes);
        }
    }
}
