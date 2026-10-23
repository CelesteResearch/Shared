using System;
using Celeste.Graphics.Direct3D12.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Devices.Native.Submission;

namespace Celeste.Graphics.Direct3D12.Submission
{
    // ReSharper disable once UnusedType.Global
    public sealed unsafe class OwnedDirect3D12GraphicsSubmission : INativeGraphicsSubmission, IDisposable
    {
        private readonly CelesteGraphicsDeviceApi* _api;
        private readonly INativeGraphicsPresentation _presentation;
        private IntPtr _device;

        public OwnedDirect3D12GraphicsSubmission(CelesteDirect3D12OwnedDeviceInfo info,
            INativeGraphicsPresentation presentation)
        {
            _presentation = presentation ?? throw new ArgumentNullException(nameof(presentation));
            _api = Direct3D12Native.GetDeviceApi();
            Direct3D12Native.RequireSuccess(Direct3D12Native.CelesteDirect3D12CreateOwnedDevice(&info, out _device));
        }

        public IntPtr AcquireDevice()
        {
            return _device != IntPtr.Zero
                ? _device
                : throw new ObjectDisposedException(nameof(OwnedDirect3D12GraphicsSubmission));
        }

        public void ReleaseDevice(IntPtr actualDevice)
        {
            if (actualDevice != _device)
                throw new ArgumentException("The device belongs to a different Direct3D12 submission.",
                    nameof(actualDevice));
            Dispose();
        }

        public void PrepareDraw()
        {
            _presentation.PrepareDraw();
        }

        public void SetPresentationInterval(SourcePresentInterval interval)
        {
            _presentation.SetPresentationInterval(interval);
        }

        public IntPtr AcquireOutput(IntPtr actualDevice)
        {
            return _presentation.AcquireOutput(actualDevice);
        }

        public void PresentCompleted()
        {
            _presentation.PresentCompleted();
        }

        public void Submit(IntPtr packet, bool waitForCompletion)
        {
            IntPtr submitted;
            Direct3D12Native.RequireSuccess(_api->Submit(packet, &submitted));
            try
            {
                if (waitForCompletion) Direct3D12Native.RequireSuccess(_api->Wait(submitted));
            }
            finally
            {
                _api->ReleaseSubmission(submitted);
            }
        }

        public void Dispose()
        {
            if (_device == IntPtr.Zero) return;
            Direct3D12Native.RequireSuccess(_api->DestroyDevice(_device));
            _device = IntPtr.Zero;
        }
    }
}
