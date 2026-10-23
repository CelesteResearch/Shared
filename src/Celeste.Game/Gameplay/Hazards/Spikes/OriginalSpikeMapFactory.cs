using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Hazards.Spikes
{
    public static class OriginalSpikeMapFactory
    {
        public static SpikesState CreateSpikes(EntityData data, Vector2 offset, SpikeDirection direction,
            ISourceEngineContext engine)
        {
            return new SpikesState(data.Position + offset,
                (uint)direction > 1u ? data.Height : data.Width,
                direction, EntityAttributeReader.Attr(data.Values, "type", "default"), engine);
        }

        public static TriggerSpikesState CreateTriggerSpikes(EntityData data, Vector2 offset,
            TriggerSpikesDirection direction, ISourceEngineContext engine)
        {
            return new TriggerSpikesState(data.Position + offset,
                (uint)direction > 1u ? data.Height : data.Width,
                direction, engine);
        }
    }
}
