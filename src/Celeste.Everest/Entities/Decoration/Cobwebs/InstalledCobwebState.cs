using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Everest.Entities.Decoration.Culling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Decoration.Cobwebs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Entities.Decoration.Cobwebs
{
    public sealed class InstalledCobwebState : OriginalCobwebState
    {
        public PackedColor[] OverrideColors;

        public InstalledCobwebState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
        }

        public override void Added(object scene)
        {
            var area = (OriginalAreaData)((OriginalLevelSceneRoot)scene)
                .AreaData;
            var savedColors = area.CobwebColor;
            if (OverrideColors != null) area.CobwebColor = OverrideColors;
            base.Added(scene);
            area.CobwebColor = savedColors;
        }

        protected override bool ShouldDrawCurve(SimpleCurve curve)
        {
            return InstalledCurveCulling.IsVisible(Engine, curve, 8f);
        }
    }
}
