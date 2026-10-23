using Celeste.Core.Maps;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface IStrawberryPersistencePolicy
    {
        string GetSeedCollectionFlag(MapEntityId id);
    }
}
