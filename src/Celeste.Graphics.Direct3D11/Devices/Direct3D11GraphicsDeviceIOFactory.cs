using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Direct3D11.Submission;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed class Direct3D11GraphicsDeviceIOFactory : ISourceGraphicsDeviceIOFactory, ISourceHostDrawTransportIO
    {
        private readonly IDirect3D11GraphicsSubmission submission;
        private Direct3D11GraphicsDeviceIO actualDevice;
        private readonly IntPtr hostWindow;
        private readonly ISourceSDLHintDevice hints;

        public Direct3D11GraphicsDeviceIOFactory(IDirect3D11GraphicsSubmission submission, IntPtr hostWindow,
            ISourceSDLHintDevice hints)
        {
            this.submission = submission ?? throw new ArgumentNullException(nameof(submission));
            this.hostWindow = hostWindow;
            this.hints = hints ?? throw new ArgumentNullException(nameof(hints));
        }

        public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess actualImageStreams)
        {
            if (actualDevice != null)
                throw new InvalidOperationException("The actual source device IO is already created.");
            actualDevice = new Direct3D11GraphicsDeviceIO(actualImageStreams, submission, hostWindow, hints);
            actualDevice.InitializeHostBackbuffer();
            return actualDevice;
        }

        public void BeginAcceptedSourceDraw()
        {
            if (actualDevice == null)
                throw new InvalidOperationException("The actual source device IO is not created.");
            submission.PrepareDraw();
            actualDevice.BeforeDraw();
        }
    }
}
