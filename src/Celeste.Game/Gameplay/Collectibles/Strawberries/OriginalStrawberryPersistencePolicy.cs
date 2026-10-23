using Celeste.Core.Maps;
using Celeste.Formats.Map.Identifiers;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
    public sealed class OriginalStrawberryPersistencePolicy : IStrawberryPersistencePolicy
    {
        public static readonly OriginalStrawberryPersistencePolicy Instance = new();

        private OriginalStrawberryPersistencePolicy()
        {
        }

        public string GetSeedCollectionFlag(MapEntityId id)
        {
            return "collected_seeds_of_" + EntityIdCodec.Format(id);
        }
    }
}
