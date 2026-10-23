using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Submission;

namespace Celeste.Graphics.Direct3D12.Devices;

public sealed class Direct3D12GraphicsDeviceIOFactory : ISourceGraphicsDeviceIOFactory, ISourceHostDrawTransportIO
{
    private readonly INativeGraphicsSubmission submission;
    private readonly IntPtr hostWindow;
    private Direct3D12GraphicsDeviceIO actualDevice;

    public Direct3D12GraphicsDeviceIOFactory(INativeGraphicsSubmission submission, IntPtr hostWindow)
    {
        this.submission = submission ?? throw new ArgumentNullException(nameof(submission));
        this.hostWindow = hostWindow;
    }

    public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess imageStreams)
    {
        if (actualDevice != null) throw new InvalidOperationException("The Direct3D12 device IO already exists.");
        var created = new Direct3D12GraphicsDeviceIO(imageStreams, submission, hostWindow);
        created.InitializeHostDevice();
        actualDevice = created;
        return created;
    }

    public void AbortUnsubmittedDraws() => actualDevice?.AbortUnsubmittedPhysicalPrefix();

    public void BeginAcceptedSourceDraw()
    {
        if (actualDevice == null) throw new InvalidOperationException("The Direct3D12 device IO does not exist.");
        submission.PrepareDraw();
        actualDevice.BeforeDraw();
    }
}
