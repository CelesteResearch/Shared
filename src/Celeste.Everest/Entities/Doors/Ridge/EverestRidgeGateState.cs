using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Doors.Ridge;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Entities.Doors.Ridge
{
    public class EverestRidgeGateState : OriginalRidgeGateState
    {
        public EverestRidgeGateState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                data.FirstNodeNullable(offset),
                EntityAttributeReader.Attr(data.Values, "texture",
                    EntityAttributeReader.Bool(data.Values, "ridge", true)
                        ? "objects/ridgeGate"
                        : "objects/farewellGate"), world)
        {
        }

        public EverestRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool ridgeImage, ISourceSolidWorld world)
            : this(engine, position, width, height, node, ridgeImage ? "objects/ridgeGate" : "objects/farewellGate",
                world)
        {
        }

        public EverestRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, string texture, ISourceSolidWorld world)
            : base(engine, position, width, height, node, texture, world)
        {
        }

        public EverestRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, ISourceSolidWorld world)
            : this(engine, position, width, height, node, "objects/ridgeGate", world)
        {
        }
    }
}
