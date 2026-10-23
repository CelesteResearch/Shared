using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Hosting.Runtime.Graphics
{
    // Created, pumped and disposed on the session owner thread. Device disposal remains owned by the game.
    public interface IEmbeddedGraphicsSession : IDisposable
    {
        ISourceGraphicsDeviceIOFactory DeviceFactory { get; }
        ISourceHostDrawTransportIO DrawTransport { get; }
        int Width { get; }
        int Height { get; }
        byte[] FrameRgba { get; }
        long FrameNumber { get; }
        void Pump();
        void StopPresenting();
    }
}
