using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs.Granny;

namespace Celeste.Everest.Entities.Npcs.Granny
{
    public sealed class EverestGrannyEndingConstructionPolicy : IOriginalGrannyEndingConstructionPolicy
    {
        public static readonly EverestGrannyEndingConstructionPolicy Instance = new();

        private EverestGrannyEndingConstructionPolicy()
        {
        }

        public OriginalGrannyEndingState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            bool ch9EasterEgg = false)
        {
            return new EverestGrannyEndingState(engine, data, offset, ch9EasterEgg);
        }
    }
}
