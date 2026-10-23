using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Submission;

namespace Celeste.Graphics.Direct3D12.Devices
{
    public sealed class Direct3D12GraphicsDeviceIOFactory : ISourceGraphicsDeviceIOFactory, ISourceHostDrawTransportIO
    {
        private readonly INativeGraphicsSubmission _submission;
        private readonly IntPtr _hostWindow;
        private Direct3D12GraphicsDeviceIO _actualDevice;

        // ReSharper disable once ConvertToPrimaryConstructor
        public Direct3D12GraphicsDeviceIOFactory(INativeGraphicsSubmission submission, IntPtr hostWindow)
        {
            _submission = submission ?? throw new ArgumentNullException(nameof(submission));
            _hostWindow = hostWindow;
        }

        public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess imageStreams)
        {
            if (_actualDevice != null) throw new InvalidOperationException("The Direct3D12 device IO already exists.");
            var created = new Direct3D12GraphicsDeviceIO(imageStreams, _submission, _hostWindow);
            created.InitializeHostDevice();
            _actualDevice = created;
            return created;
        }

        // ReSharper disable once UnusedMember.Global
        public void AbortUnsubmittedDraws()
        {
            _actualDevice?.AbortUnsubmittedPhysicalPrefix();
        }

        public void BeginAcceptedSourceDraw()
        {
            if (_actualDevice == null) throw new InvalidOperationException("The Direct3D12 device IO does not exist.");
            _submission.PrepareDraw();
            _actualDevice.BeforeDraw();
        }
    }
}
