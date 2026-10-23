using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Offscreen;

// Owns backend resources; the enclosing session owns scheduling and RGBA storage.
public interface IOffscreenGraphicsBackend : IDisposable
{
    ISourceGraphicsDeviceIOFactory DeviceFactory { get; }
    ISourceHostDrawTransportIO DrawTransport { get; }
    void ConfigureOutput(int width, int height);
    int ReadRgba(byte[] destination);
}
