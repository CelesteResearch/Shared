using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Everest.Entities.Decoration.Culling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Decoration.Wires;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Entities.Decoration.Wires
{
    public sealed class InstalledWireState : OriginalWireState
    {
        public bool FixWindBehavior { get; }

        public InstalledWireState(Vector2 from, Vector2 to, bool above, ISourceEngineContext engine)
            : base(from, to, above, engine)
        {
        }

        public InstalledWireState(Vector2 from, Vector2 to, bool above, bool fixWindBehavior,
            ISourceEngineContext engine)
            : this(from, to, above, engine)
        {
            FixWindBehavior = fixWindBehavior;
        }

        public InstalledWireState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Nodes[0] + offset,
                EntityAttributeReader.Bool(data.Values, "above"),
                EntityAttributeReader.Bool(data.Values, "fixWindBehavior"), engine)
        {
        }

        protected override float ReadVisualWind(OriginalLevelSceneRoot level)
        {
            var visualWind = level.VisualWind;
            if (FixWindBehavior) visualWind /= 100f;
            return visualWind;
        }

        protected override bool ShouldDrawCurve()
        {
            return InstalledCurveCulling.IsVisible(Engine, Curve, 2f);
        }
    }
}
