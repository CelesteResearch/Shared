using Celeste.Core.Threading;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public sealed class
        OriginalBloomBlendStateInitializationFactory : ISourceTypeInitializationFactory<IOriginalBloomBlendStates>
    {
        public IOriginalBloomBlendStates Allocate()
        {
            return new OriginalBloomBlendStates();
        }

        public void Initialize(IOriginalBloomBlendStates instance)
        {
        }
    }
}
