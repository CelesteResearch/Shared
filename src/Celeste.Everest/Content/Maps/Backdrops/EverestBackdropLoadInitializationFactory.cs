using Celeste.Core.Threading;

namespace Celeste.Everest.Content.Maps.Backdrops
{
    public sealed class
        EverestBackdropLoadInitializationFactory : ISourceTypeInitializationFactory<EverestBackdropLoaders>
    {
        public EverestBackdropLoaders Allocate() => new EverestBackdropLoaders();

        public void Initialize(EverestBackdropLoaders instance)
        {
        }
    }
}
