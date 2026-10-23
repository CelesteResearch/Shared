using System;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Devices.Native.Submission;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Rendering.Offscreen
{
    public abstract unsafe class NativeOffscreenGraphicsBackend(
        CelesteGraphicsDeviceApi* api,
        string shaderProfile,
        GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation) : IOffscreenGraphicsBackend, ISourceGraphicsDeviceIOFactory,
        ISourceHostDrawTransportIO, INativeGraphicsSubmission
    {
        private readonly CelesteGraphicsDeviceApi* api = NativeGraphicsDeviceApi.RequireComplete(api);
        private readonly string shaderProfile = shaderProfile ?? throw new ArgumentNullException(nameof(shaderProfile));

        private readonly GraphicsOwnerDispatcher dispatcher =
            dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));

        private readonly IOffscreenGraphicsPresentation presentation =
            presentation ?? throw new ArgumentNullException(nameof(presentation));

        private readonly Action prepareOnOwner = presentation.PrepareDraw;
        private NativeGraphicsDeviceIO actualDevice;
        private IntPtr device;
        private IntPtr texture;
        private int width;
        private int height;
        private bool disposed;
        public ISourceGraphicsDeviceIOFactory DeviceFactory => this;
        public ISourceHostDrawTransportIO DrawTransport => this;

        protected abstract IntPtr CreateOwnedDevice();
        protected abstract IntPtr AcquireTextureOutput(IntPtr actualDevice, IntPtr outputTexture);

        public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess imageStreams)
        {
            if (actualDevice != null)
                throw new InvalidOperationException("The graphics device IO already exists.");
            var created = new NativeGraphicsDeviceIO(imageStreams, this, IntPtr.Zero, api, shaderProfile);
            created.InitializeHostDevice();
            actualDevice = created;
            return created;
        }

        public IntPtr AcquireDevice()
        {
            if (dispatcher.IsOwnerThread)
                return AcquireOnOwner();
            var acquired = IntPtr.Zero;
            dispatcher.Invoke(() => acquired = AcquireOnOwner());
            return acquired;
        }

        private IntPtr AcquireOnOwner()
        {
            dispatcher.RequireOwnerThread();
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (device != IntPtr.Zero)
                return device;
            device = CreateOwnedDevice();
            RequireSuccess(device != IntPtr.Zero ? 1 : 0);
            presentation.PrepareDraw();
            return device;
        }

        public void ConfigureOutput(int width, int height)
        {
            dispatcher.RequireOwnerThread();
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height));
            if (texture != IntPtr.Zero && this.width == width && this.height == height)
                return;
            var info = new CelesteGraphicsTextureInfo
            {
                sourceFormat = SourceSurfaceFormat.Color,
                dimension = 0,
                width = (uint)width,
                height = (uint)height,
                depth = 1,
                levels = 1,
                renderTarget = 1,
            };
            IntPtr replacement;
            RequireSuccess(api->CreateTexture(device, &info, &replacement));
            var previous = texture;
            texture = replacement;
            this.width = width;
            this.height = height;
            if (previous != IntPtr.Zero)
                api->ReleaseTexture(previous);
        }

        public void BeginAcceptedSourceDraw()
        {
            if (actualDevice == null)
                throw new InvalidOperationException("The graphics device IO does not exist.");
            PrepareDraw();
            actualDevice.BeforeDraw();
        }

        public void AbortUnsubmittedDraws()
        {
            actualDevice?.AbortUnsubmittedPhysicalPrefix();
        }

        public void PrepareDraw()
        {
            if (dispatcher.IsOwnerThread)
                presentation.PrepareDraw();
            else
                dispatcher.Invoke(prepareOnOwner);
        }

        public void SetPresentationInterval(SourcePresentInterval interval)
        {
            // The enclosing host owns display timing; this output has no window or swapchain.
        }

        public IntPtr AcquireOutput(IntPtr actualDevice)
        {
            if (actualDevice != device)
                throw new ArgumentException("The device belongs to another backend.", nameof(actualDevice));
            return AcquireTextureOutput(actualDevice, texture);
        }

        public void Submit(IntPtr packet, bool waitForCompletion)
        {
            if (dispatcher.IsOwnerThread)
                SubmitOnOwner(packet, waitForCompletion);
            else
                SubmitFromWorker(packet, waitForCompletion);
        }

        private void SubmitFromWorker(IntPtr packet, bool waitForCompletion)
        {
            dispatcher.Invoke(() => SubmitOnOwner(packet, waitForCompletion));
        }

        private void SubmitOnOwner(IntPtr packet, bool waitForCompletion)
        {
            dispatcher.RequireOwnerThread();
            IntPtr submitted;
            RequireSuccess(api->Submit(packet, &submitted));
            try
            {
                if (waitForCompletion)
                    RequireSuccess(api->Wait(submitted));
            }
            finally
            {
                api->ReleaseSubmission(submitted);
            }
        }

        public void PresentCompleted()
        {
            presentation.PresentCompleted();
        }

        public int ReadRgba(byte[] destination)
        {
            dispatcher.RequireOwnerThread();
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));
            var bytes = checked(width * height * 4);
            if (destination.Length != bytes)
                throw new ArgumentException("The output buffer has a different size.", nameof(destination));
            fixed (byte* pointer = destination)
            {
                actualDevice.GetTextureData2D(texture, 0, 0, width, height, 0, (IntPtr)pointer, bytes);
            }

            return bytes;
        }

        public void ReleaseDevice(IntPtr actualDevice)
        {
            if (actualDevice != device)
                throw new ArgumentException("The device belongs to another backend.", nameof(actualDevice));
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
                return;
            if (dispatcher.IsOwnerThread)
                DisposeOnOwner();
            else
                dispatcher.Invoke(DisposeOnOwner);
        }

        private void DisposeOnOwner()
        {
            dispatcher.RequireOwnerThread();
            actualDevice?.AbortUnsubmittedPhysicalPrefix();
            if (texture != IntPtr.Zero)
            {
                api->ReleaseTexture(texture);
                texture = IntPtr.Zero;
            }

            if (device != IntPtr.Zero)
            {
                RequireSuccess(api->DestroyDevice(device));
                device = IntPtr.Zero;
            }

            disposed = true;
        }

        private void RequireSuccess(int result)
        {
            if (result != 1)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8((IntPtr)api->GetLastError()) ??
                                                    "Native graphics operation failed.");
        }
    }
}
