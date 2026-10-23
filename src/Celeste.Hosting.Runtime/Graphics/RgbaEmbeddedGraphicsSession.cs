using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Hosting.Runtime.Graphics
{
    public sealed class RgbaEmbeddedGraphicsSession : IEmbeddedGraphicsSession, IOffscreenGraphicsPresentation
    {
        private readonly ISourceHostWindowIO _window;
        private readonly GraphicsOwnerDispatcher _dispatcher;
        private readonly IOffscreenGraphicsBackend _backend;
        private bool _presenting = true;
        private bool _disposed;

        public RgbaEmbeddedGraphicsSession(ISourceHostWindowIO window, ISourceSDLHintDevice hints, int ownerThread,
            IOffscreenGraphicsBackendFactory factory)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            _dispatcher = new(ownerThread);
            try
            {
                _backend = factory.Create(hints, _dispatcher, this);
            }
            catch
            {
                _dispatcher.Dispose();
                throw;
            }
        }

        public ISourceGraphicsDeviceIOFactory DeviceFactory => _backend.DeviceFactory;
        public ISourceHostDrawTransportIO DrawTransport => _backend.DrawTransport;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public byte[] FrameRgba { get; private set; } = [];
        public long FrameNumber { get; private set; }

        public void InvalidateOutput()
        {
            _dispatcher.RequireOwnerThread();
            Width = Height = 0;
        }

        public void PrepareDraw()
        {
            _dispatcher.RequireOwnerThread();
            _window.GetDrawableSize(out var width, out var height);
            if (Width == width && Height == height) return;
            _backend.ConfigureOutput(width, height);
            Width = width;
            Height = height;
            var capacity = checked(width * height * 4);
            if (FrameRgba.Length != capacity) FrameRgba = new byte[capacity];
        }

        public void PresentCompleted()
        {
            if (_dispatcher.IsOwnerThread) PresentOnOwner();
            else _dispatcher.Invoke(PresentOnOwner);
        }

        private void PresentOnOwner()
        {
            _dispatcher.RequireOwnerThread();
            if (!_presenting) return;
            var written = _backend.ReadRgba(FrameRgba);
            if (written != FrameRgba.Length)
                throw new InvalidOperationException("The source output does not match its configured RGBA byte count.");
            FrameNumber++;
        }

        public void Pump()
        {
            _dispatcher.Pump();
        }

        public void StopPresenting()
        {
            _dispatcher.RequireOwnerThread();
            _presenting = false;
            _dispatcher.StopWorkerRequests();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _dispatcher.RequireOwnerThread();
            _disposed = true;
            _presenting = false;
            FrameRgba = [];
            _dispatcher.StopWorkerRequests();
            try
            {
                _backend.Dispose();
            }
            finally
            {
                _dispatcher.Dispose();
            }
        }
    }
}
