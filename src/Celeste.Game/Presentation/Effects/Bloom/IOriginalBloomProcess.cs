using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Effects.Blur;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public interface IOriginalBloomProcess : ISourceGaussianBlurEnvironment
    {
        OriginalGameGraphicsResources Graphics { get; }
        IOriginalBloomBlendStates BloomBlendStates { get; }
    }
}
