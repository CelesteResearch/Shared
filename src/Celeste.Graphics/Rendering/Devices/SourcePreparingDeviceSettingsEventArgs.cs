using System;

namespace Celeste.Graphics.Rendering.Devices
{
    public class SourcePreparingDeviceSettingsEventArgs : EventArgs
    {
        public SourceGraphicsDeviceInformation GraphicsDeviceInformation { get; private set; }

        public SourcePreparingDeviceSettingsEventArgs(SourceGraphicsDeviceInformation graphicsDeviceInformation)
        {
            GraphicsDeviceInformation = graphicsDeviceInformation;
        }
    }
}
