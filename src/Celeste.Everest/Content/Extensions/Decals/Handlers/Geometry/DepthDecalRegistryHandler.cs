using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;

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
            int? depth = _depth;
            if (depth.HasValue)
            {
                int valueOrDefault = depth.GetValueOrDefault();
                if (!(decal is OriginalDecalEntity original && original.DepthSetByPlacement))
                {
                    decal.Depth = valueOrDefault;
                }
            }
        }
    }
}
