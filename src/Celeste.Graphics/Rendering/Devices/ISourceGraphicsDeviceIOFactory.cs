using Celeste.Graphics.Content.Images;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsDeviceIOFactory
    {
        ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess actualImageStreams);
    }
}
