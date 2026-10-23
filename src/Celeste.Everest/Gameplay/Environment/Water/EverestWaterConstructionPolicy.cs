using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Environment.Water;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public sealed class EverestWaterConstructionPolicy : IOriginalWaterConstructionPolicy
    {
        public static readonly EverestWaterConstructionPolicy Instance = new();

        private EverestWaterConstructionPolicy()
        {
        }

        public OriginalWaterState Create(ISourceEngineContext engine, EntityData data, Vector2 offset) =>
            new EverestWaterState(engine, data, offset);
    }
}
