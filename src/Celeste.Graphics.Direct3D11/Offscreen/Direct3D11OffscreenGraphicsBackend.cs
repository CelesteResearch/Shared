using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Direct3D11.Devices;
using Celeste.Graphics.Direct3D11.Submission;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D11.Offscreen;

public sealed class Direct3D11OffscreenGraphicsBackend : IOffscreenGraphicsBackend, IDirect3D11GraphicsSubmission
{
    private readonly GraphicsOwnerDispatcher dispatcher;
    private readonly IOffscreenGraphicsPresentation presentation;
    private readonly Direct3D11GraphicsDeviceIOFactory graphics;
    private Direct3D11GraphicsContext context;
    private IntPtr device;
    private ulong generation;

    public Direct3D11OffscreenGraphicsBackend(ISourceSDLHintDevice hints, GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation)
    {
        this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        this.presentation = presentation ?? throw new ArgumentNullException(nameof(presentation));
        graphics = new Direct3D11GraphicsDeviceIOFactory(this, IntPtr.Zero, hints);
    }

    public ISourceGraphicsDeviceIOFactory DeviceFactory => graphics;
    public ISourceHostDrawTransportIO DrawTransport => graphics;

    public IntPtr AcquireDevice()
    {
        if (dispatcher.IsOwnerThread) return AcquireOnOwner();
        return AcquireFromWorker();
    }

    private IntPtr AcquireFromWorker()
    {
        IntPtr acquired = IntPtr.Zero;
        dispatcher.Invoke(() => acquired = AcquireOnOwner());
        return acquired;
    }

    private IntPtr AcquireOnOwner()
    {
        dispatcher.RequireOwnerThread();
        context ??= new Direct3D11GraphicsContext();
        IntPtr acquired = context.AcquireDevice();
        if (acquired == IntPtr.Zero) throw new InvalidOperationException("The offscreen device was not acquired.");
        ulong actualGeneration = context.Generation;
        if (device != acquired || generation != actualGeneration)
        {
            device = acquired;
            generation = actualGeneration;
            presentation.InvalidateOutput();
            presentation.PrepareDraw();
        }

        return device;
    }

    public void SubmitAndWait(IntPtr sealedPhysicalPacket)
    {
        if (dispatcher.IsOwnerThread) SubmitOnOwner(sealedPhysicalPacket);
        else SubmitFromWorker(sealedPhysicalPacket);
    }

    private void SubmitFromWorker(IntPtr packet)
    {
        dispatcher.Invoke(() => SubmitOnOwner(packet));
    }

    private void SubmitOnOwner(IntPtr packet)
    {
        dispatcher.RequireOwnerThread();
        Direct3D11GraphicsPackets.Execute(device, packet);
        if (Direct3D11GraphicsPackets.GetCompletion(packet) != 1)
            throw new InvalidOperationException(Direct3D11GraphicsPackets.LastError ??
                                                "Native graphics operation failed.");
    }

    public void ConfigureOutput(int width, int height) => Direct3D11FrameOutput.Configure(device, width, height);
    public int ReadRgba(byte[] destination) => Direct3D11FrameOutput.ReadRgba(device, destination);
    public void PrepareDraw() => presentation.PrepareDraw();
    public void PresentCompleted() => presentation.PresentCompleted();

    public void SetPresentationSyncInterval(int count)
    {
    }

    public void Dispose()
    {
        context?.Dispose();
        context = null;
        device = IntPtr.Zero;
    }
}
