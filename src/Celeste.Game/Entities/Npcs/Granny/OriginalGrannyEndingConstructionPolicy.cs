using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public sealed class OriginalGrannyEndingConstructionPolicy : IOriginalGrannyEndingConstructionPolicy
    {
        public static readonly OriginalGrannyEndingConstructionPolicy Instance = new();

        private OriginalGrannyEndingConstructionPolicy()
        {
        }

        public OriginalGrannyEndingState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            bool ch9EasterEgg = false)
        {
            return new(engine, data, offset, ch9EasterEgg);
        }
    }
}
