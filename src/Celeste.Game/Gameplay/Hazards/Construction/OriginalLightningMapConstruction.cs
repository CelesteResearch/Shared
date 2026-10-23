using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Gameplay.Hazards.Construction
{
    public static class OriginalLightningMapConstruction
    {
        public static LightningState Create(EntityData data, Vector2 offset, ISourceEngineContext engine)
        {
            return new(data.Position + offset, data.Width, data.Height, FirstNodeNullable(data, offset),
                EntityAttributeReader.Float(data.Values, "moveTime"), engine);
        }

        private static Vector2? FirstNodeNullable(EntityData data, Vector2 offset)
        {
            return data.Nodes == null || data.Nodes.Length == 0 ? null : data.Nodes[0] + offset;
        }
    }
}
