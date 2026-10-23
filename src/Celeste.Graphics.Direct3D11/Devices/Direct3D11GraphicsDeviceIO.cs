using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;
using Celeste.Graphics.Content.Images;
using Celeste.Core.IO.Platform.SDL;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO : ISourceImageStreamProcessEnvironment
    {
        private readonly SourceImageStreamProcess imageStreams;
        private readonly IDirect3D11GraphicsSubmission submission;
        private readonly IntPtr hostWindow;

        private readonly ISourceSDLHintDevice hints;

        // SourceGraphicsDevice owns source state and resources. The native backend
        // determines whether the physical device is borrowed or owned.
        private IntPtr device;

        public Direct3D11GraphicsDeviceIO(SourceImageStreamProcess actualImageStreams,
            IDirect3D11GraphicsSubmission actualSubmission, IntPtr actualHostWindow,
            ISourceSDLHintDevice actualHints)
        {
            imageStreams = actualImageStreams ?? throw new ArgumentNullException(nameof(actualImageStreams));
            submission = actualSubmission ?? throw new ArgumentNullException(nameof(actualSubmission));
            hostWindow = actualHostWindow;
            hints = actualHints ?? throw new ArgumentNullException(nameof(actualHints));
        }

        public SourceImageStreamProcess ImageStreams => imageStreams;

        internal void InitializeHostBackbuffer()
        {
            AdoptDevice(submission.AcquireDevice());
            IntPtr recording = Direct3D11GraphicsBindings.SourceGpuBeginPhysicalPacket(device);
            if (recording == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            IntPtr packet = Direct3D11GraphicsBindings.SourceGpuSealPhysicalPacket();
            if (packet == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            try
            {
                SubmitMeasured(packet);
            }
            finally
            {
                // SubmitAndWait does not consume this caller-owned packet reference.
                Direct3D11GraphicsBindings.SourceGpuReleasePacket(packet);
            }
        }

        private void AdoptDevice(IntPtr acquired)
        {
            if (acquired == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            if (device == acquired) return;
            Direct3D11GraphicsBindings.SourceGpuRetainDeviceContext(acquired);
            Direct3D11GraphicsBindings.SourceGpuReleaseDeviceContext(device);
            device = acquired;
        }

        private void SubmitMeasured(IntPtr packet)
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long started = diagnostics?.BeginFrameSubmission() ?? 0;
            long loadStarted = diagnostics?.BeginLoadSubmission(started) ?? 0;
            try
            {
                submission.SubmitAndWait(packet);
            }
            finally
            {
                if (started != 0)
                {
                    long completed = global::System.Diagnostics.Stopwatch.GetTimestamp();
                    diagnostics.EndFrameSubmission(started, completed);
                    diagnostics.EndLoadSubmission(loadStarted, completed);
                }
            }
        }

        private uint BorrowWriteScope()
        {
            IntPtr packet = Direct3D11GraphicsBindings.SourceGpuBorrowOrBeginPhysicalPacket(device, out uint owned);
            if (packet == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            return owned;
        }

        private void CompleteWriteScope(uint owned)
        {
            global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current?.RecordLoadWrite(owned);
            if (owned == 0) return;
            IntPtr packet = Direct3D11GraphicsBindings.SourceGpuSealPhysicalPacket();
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
    }
}
