using System;

namespace Celeste.Core.Framework.Graphics
{
    public interface ISourceGraphicsDeviceService
    {
        object GraphicsDevice { get; }
        event EventHandler<EventArgs> DeviceDisposing;
        event EventHandler<EventArgs> DeviceCreated;
    }
}
