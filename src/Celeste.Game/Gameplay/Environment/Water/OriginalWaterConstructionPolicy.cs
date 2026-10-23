using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public sealed class OriginalWaterConstructionPolicy : IOriginalWaterConstructionPolicy
    {
        public static readonly OriginalWaterConstructionPolicy Instance = new();

        private OriginalWaterConstructionPolicy()
        {
        }

        public OriginalWaterState Create(ISourceEngineContext engine, EntityData data, Vector2 offset) =>
            new(engine, data, offset);
    }
}
