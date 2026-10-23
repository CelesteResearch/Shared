using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Formats.Graphics.Models
{
    public interface ISourceObjModelPolicy
    {
        ObjectModel CreateModel(ISourceGraphicsDeviceEnvironment environment);
        bool SkipStreamRead(ISourceGraphicsDeviceEnvironment environment);
    }
}
