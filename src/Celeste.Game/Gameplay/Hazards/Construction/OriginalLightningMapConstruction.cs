using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Gameplay.Hazards.Construction
{
    public static class OriginalLightningMapConstruction
    {
        public static LightningState Create(EntityData data, Vector2 offset, ISourceEngineContext engine)
            => new LightningState(data.Position + offset, data.Width, data.Height, FirstNodeNullable(data, offset),
                EntityAttributeReader.Float(data.Values, "moveTime", 0f), engine);

        private static Vector2? FirstNodeNullable(EntityData data, Vector2 offset)
            => data.Nodes == null || data.Nodes.Length == 0 ? (Vector2?)null : data.Nodes[0] + offset;
    }
}
