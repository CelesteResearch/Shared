using Celeste.Core.Threading;
using Celeste.Game.Presentation.Effects.Bloom;

namespace Celeste.Everest.Presentation.Effects.Bloom
{
    public sealed class
        EverestBloomBlendStateInitializationFactory : ISourceTypeInitializationFactory<IOriginalBloomBlendStates>
    {
        public IOriginalBloomBlendStates Allocate()
        {
            return new EverestBloomBlendStates();
        }

        public void Initialize(IOriginalBloomBlendStates instance)
        {
        }
    }
}
