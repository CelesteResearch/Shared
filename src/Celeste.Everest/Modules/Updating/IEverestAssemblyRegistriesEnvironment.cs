using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Everest.Entities.Triggers.Events;
using Celeste.Everest.Content.Maps.Backdrops;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Everest.Content.Extensions.Collectibles;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestAssemblyRegistriesEnvironment
    {
        EverestEntityRegistryProcess EntityRegistry { get; }
        EverestLevelEntityLoadProcess EntityLoaders { get; }
        InstalledStrawberryRegistryState StrawberryRegistry { get; }
        EverestEventTriggerRuntimePolicy EventTriggers { get; }
        EverestBackdropLoaders Backdrops { get; }
        EverestMapWipeProcess Wipes { get; }
    }
}
