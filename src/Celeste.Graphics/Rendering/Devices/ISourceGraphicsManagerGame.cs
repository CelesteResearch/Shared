using Celeste.Core.Framework.Services;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsManagerGame
    {
        SourceGameServiceContainer Services { get; }
        ISourceGraphicsManagerWindow Window { get; }
    }
}
