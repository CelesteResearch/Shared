using System.Xml;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry
{
    public sealed class DepthDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public DepthDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int? _depth;

        public override string Name => "depth";

        public override void Parse(XmlAttributeCollection xml)
        {
            _depth = GetNullableInt(xml, "value");
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var depth = _depth;
            if (!depth.HasValue)
                return;
            var valueOrDefault = depth.GetValueOrDefault();
            if (!(decal is OriginalDecalEntity original && original.DepthSetByPlacement))
                decal.Depth = valueOrDefault;
        }
    }
}
