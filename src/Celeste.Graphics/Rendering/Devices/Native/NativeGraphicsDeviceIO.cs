using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Devices.Native.Submission;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO : ISourceGraphicsDeviceIO, ISourceTextureIO,
        ISourceImageStreamProcessEnvironment
    {
        private readonly INativeGraphicsSubmission submission;
        private readonly IntPtr hostWindow;
        private readonly CelesteGraphicsDeviceApi* api;
        private readonly string shaderProfile;
        private IntPtr device;
        private IntPtr packet;
        private bool transferOnlyPacket;
        private const ulong TextureUploadWaitBytes = 32UL * 1024 * 1024;
        private const int TextureUploadWaitOperations = 256;
        private ulong textureUploadBytesSinceWait;
        private int textureUploadOperationsSinceWait;

        // ReSharper disable once ConvertToPrimaryConstructor
        public NativeGraphicsDeviceIO(SourceImageStreamProcess imageStreams, INativeGraphicsSubmission submission,
            IntPtr hostWindow, CelesteGraphicsDeviceApi* deviceApi, string shaderProfile)
        {
            ImageStreams = imageStreams ?? throw new ArgumentNullException(nameof(imageStreams));
            this.submission = submission ?? throw new ArgumentNullException(nameof(submission));
            this.hostWindow = hostWindow;
            api = NativeGraphicsDeviceApi.RequireComplete(deviceApi);
            this.shaderProfile = shaderProfile ?? throw new ArgumentNullException(nameof(shaderProfile));
        }

        public SourceImageStreamProcess ImageStreams { get; }

        public void InitializeHostDevice()
        {
            if (device != IntPtr.Zero)
                return;
            device = submission.AcquireDevice();
            if (device == IntPtr.Zero)
                RequireSuccess(0);
        }

        private void RequireSuccess(int result)
        {
            if (result == 1)
                return;
            var error = Marshal.PtrToStringUTF8((IntPtr)api->GetLastError());
            AbortUnsubmittedPhysicalPrefix();
            throw new InvalidOperationException(error ?? "Native graphics operation failed.");
        }

        private uint BorrowWriteScope(bool deferTextureUploads = false)
        {
            if (packet != IntPtr.Zero)
                return transferOnlyPacket ? 1u : 0u;
            BeforeDraw();
            transferOnlyPacket = deferTextureUploads;
            return 1;
        }

        public void BeforeDraw()
        {
            if (packet != IntPtr.Zero)
            {
                if (!transferOnlyPacket)
                    throw new InvalidOperationException("The prior Native graphics recording is still open.");
                DrainDisposedEffects();
                transferOnlyPacket = false;
                return;
            }

            if (device == IntPtr.Zero)
                throw new InvalidOperationException("The Native graphics device is not initialized.");
            DrainDisposedEffects();
            IntPtr created;
            RequireSuccess(api->BeginPacket(device, &created));
            packet = created;
        }

        public void AbortUnsubmittedPhysicalPrefix()
        {
            var abandoned = packet;
            packet = IntPtr.Zero;
            transferOnlyPacket = false;
            if (abandoned != IntPtr.Zero)
                api->ReleasePacket(abandoned);
        }

        private void CompleteWriteScope(uint owned, bool deferTextureUploads = false)
        {
            SourceFrameDiagnostics.Current?.RecordLoadWrite(owned);
            if (packet == IntPtr.Zero)
                return;
            var wait = textureUploadBytesSinceWait >= TextureUploadWaitBytes ||
                       textureUploadOperationsSinceWait >= TextureUploadWaitOperations;
            if (!wait && (owned == 0 || deferTextureUploads))
                return;
            FlushPhysicalPrefix(wait);
            if (owned == 0)
                BeforeDraw();
        }

        private void CompleteReadScope(uint owned)
        {
            SourceFrameDiagnostics.Current?.RecordLoadRead(owned);
            if (packet == IntPtr.Zero)
                return;
            FlushPhysicalPrefix(true);
            if (owned == 0)
                BeforeDraw();
        }

        private void FlushPhysicalPrefix(bool waitForCompletion)
        {
            var completed = packet;
            packet = IntPtr.Zero;
            transferOnlyPacket = false;
            if (completed == IntPtr.Zero)
                return;
            var diagnostics = SourceFrameDiagnostics.Current;
            var started = diagnostics?.BeginFrameSubmission() ?? 0;
            var loadStarted = diagnostics?.BeginLoadSubmission(started) ?? 0;
            try
            {
                submission.Submit(completed, waitForCompletion);
                if (waitForCompletion)
                {
                    textureUploadBytesSinceWait = 0;
                    textureUploadOperationsSinceWait = 0;
                }
            }
            finally
            {
                api->ReleasePacket(completed);
                if (started != 0)
                {
                    var finished = Stopwatch.GetTimestamp();
                    diagnostics.EndFrameSubmission(started, finished);
                    diagnostics.EndLoadSubmission(loadStarted, finished);
                }
            }
        }
    }
}
