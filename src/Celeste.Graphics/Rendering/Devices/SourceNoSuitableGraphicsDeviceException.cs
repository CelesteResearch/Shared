using System;

namespace Celeste.Graphics.Rendering.Devices
{
    [Serializable]
    public sealed class SourceNoSuitableGraphicsDeviceException : Exception
    {
        public SourceNoSuitableGraphicsDeviceException()
        {
        }

        public SourceNoSuitableGraphicsDeviceException(string message)
            : base(message)
        {
        }

        public SourceNoSuitableGraphicsDeviceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
