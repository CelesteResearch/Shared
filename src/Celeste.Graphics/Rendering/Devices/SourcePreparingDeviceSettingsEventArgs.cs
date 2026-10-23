using System;

namespace Celeste.Graphics.Rendering.Devices
{
    public class SourcePreparingDeviceSettingsEventArgs(SourceGraphicsDeviceInformation graphicsDeviceInformation)
        : EventArgs
    {
        public SourceGraphicsDeviceInformation GraphicsDeviceInformation { get; private set; } =
            graphicsDeviceInformation;
    }
}
