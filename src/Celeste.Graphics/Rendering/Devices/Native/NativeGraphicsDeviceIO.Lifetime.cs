using System;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        public IntPtr CreateDevice(ref SourceNativePresentationParameters parameters, byte debugMode)
        {
            if (debugMode != 0)
                throw new NotSupportedException(
                    "Graphics validation must be enabled when the host creates its device.");
            InitializeHostDevice();
            ResetBackbuffer(ref parameters);
            return device;
        }

        public void DestroyDevice()
        {
            if (device == IntPtr.Zero) return;
            AbortUnsubmittedPhysicalPrefix();
            // Host retires borrowed command buffers before releasing the backend wrapper.
            // Native release may fail and retains its device for retry in that case.
            submission.ReleaseDevice(device);
            device = IntPtr.Zero;
            DisposeEffects();
        }

        private CelesteGraphicsBackbufferInfo ReadBackbufferInfo()
        {
            CelesteGraphicsBackbufferInfo info;
            RequireSuccess(api->GetBackbufferInfo(device, &info));
            return info;
        }

        public void GetBackbufferSize(out int width, out int height)
        {
            var info = ReadBackbufferInfo();
            width = info.width;
            height = info.height;
        }

        public SourceSurfaceFormat GetBackbufferSurfaceFormat()
        {
            return ReadBackbufferInfo().format;
        }
    }
}
