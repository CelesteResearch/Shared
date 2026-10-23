using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Hosting.Runtime.Graphics;

public sealed class RgbaEmbeddedGraphicsSession : IEmbeddedGraphicsSession, IOffscreenGraphicsPresentation
{
    private readonly ISourceHostWindowIO window;
    private readonly GraphicsOwnerDispatcher dispatcher;
    private readonly IOffscreenGraphicsBackend backend;
    private bool presenting = true;
    private bool disposed;

    public RgbaEmbeddedGraphicsSession(ISourceHostWindowIO window, ISourceSDLHintDevice hints, int ownerThread,
        IOffscreenGraphicsBackendFactory factory)
    {
        this.window = window ?? throw new ArgumentNullException(nameof(window));
        if (factory == null) throw new ArgumentNullException(nameof(factory));
        dispatcher = new GraphicsOwnerDispatcher(ownerThread);
        try
        {
            backend = factory.Create(hints, dispatcher, this);
        }
        catch
        {
            dispatcher.Dispose();
            throw;
        }
    }

    public ISourceGraphicsDeviceIOFactory DeviceFactory => backend.DeviceFactory;
    public ISourceHostDrawTransportIO DrawTransport => backend.DrawTransport;
    public int Width { get; private set; }
    public int Height { get; private set; }
    public byte[] FrameRgba { get; private set; } = Array.Empty<byte>();
    public long FrameNumber { get; private set; }

    public void InvalidateOutput()
    {
        dispatcher.RequireOwnerThread();
        Width = Height = 0;
    }

    public void PrepareDraw()
    {
        dispatcher.RequireOwnerThread();
        window.GetDrawableSize(out int width, out int height);
        if (Width == width && Height == height) return;
        backend.ConfigureOutput(width, height);
        Width = width;
        Height = height;
        int capacity = checked(width * height * 4);
        if (FrameRgba.Length != capacity) FrameRgba = new byte[capacity];
    }

    public void PresentCompleted()
    {
        if (dispatcher.IsOwnerThread) PresentOnOwner();
        else dispatcher.Invoke(PresentOnOwner);
    }

    private void PresentOnOwner()
    {
        dispatcher.RequireOwnerThread();
        if (!presenting) return;
        int written = backend.ReadRgba(FrameRgba);
        if (written != FrameRgba.Length)
            throw new InvalidOperationException("The source output does not match its configured RGBA byte count.");
        FrameNumber++;
    }

    public void Pump() => dispatcher.Pump();

    public void StopPresenting()
    {
        dispatcher.RequireOwnerThread();
        presenting = false;
        dispatcher.StopWorkerRequests();
    }

    public void Dispose()
    {
        if (disposed) return;
        dispatcher.RequireOwnerThread();
        disposed = true;
        presenting = false;
        FrameRgba = Array.Empty<byte>();
        dispatcher.StopWorkerRequests();
        try
        {
            backend.Dispose();
        }
        finally
        {
            dispatcher.Dispose();
        }
    }
}
