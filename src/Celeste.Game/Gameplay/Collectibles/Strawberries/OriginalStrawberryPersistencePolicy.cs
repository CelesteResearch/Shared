using Celeste.Core.Maps;
using Celeste.Formats.Map.Identifiers;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
    public sealed class OriginalStrawberryPersistencePolicy : IStrawberryPersistencePolicy
    {
        public static readonly OriginalStrawberryPersistencePolicy Instance = new OriginalStrawberryPersistencePolicy();

        private OriginalStrawberryPersistencePolicy()
        {
        }

        public string GetSeedCollectionFlag(MapEntityId id)
            => "collected_seeds_of_" + EntityIdCodec.Format(id);
    }
}
