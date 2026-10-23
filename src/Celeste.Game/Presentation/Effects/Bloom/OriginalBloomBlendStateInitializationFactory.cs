using Celeste.Core.Threading;
using Celeste.Game.Presentation.Effects.Bloom;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public sealed class
        OriginalBloomBlendStateInitializationFactory : ISourceTypeInitializationFactory<IOriginalBloomBlendStates>
    {
        public IOriginalBloomBlendStates Allocate() => new OriginalBloomBlendStates();

        public void Initialize(IOriginalBloomBlendStates instance)
        {
        }
    }
}
