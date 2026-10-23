using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Effects.Blur
{
    public interface ISourceGaussianBlurEnvironment : ISourceDrawScope, ISourceGraphicsDeviceEnvironment
    {
        SourceEffect FxGaussianBlur { get; }
    }
}
