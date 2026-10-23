using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Direct3D11.Submission;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed class Direct3D11GraphicsDeviceIOFactory(
        IDirect3D11GraphicsSubmission submission,
        IntPtr hostWindow,
        ISourceSDLHintDevice hints) : ISourceGraphicsDeviceIOFactory, ISourceHostDrawTransportIO
    {
        private readonly IDirect3D11GraphicsSubmission submission =
            submission ?? throw new ArgumentNullException(nameof(submission));

        private Direct3D11GraphicsDeviceIO actualDevice;
        private readonly IntPtr hostWindow = hostWindow;
        private readonly ISourceSDLHintDevice hints = hints ?? throw new ArgumentNullException(nameof(hints));

        public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess actualImageStreams)
        {
            if (actualDevice != null)
                throw new InvalidOperationException("The actual source device IO is already created.");
            actualDevice = new(actualImageStreams, submission, hostWindow, hints);
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
