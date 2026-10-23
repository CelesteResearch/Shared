using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting
{
    public sealed class BloomDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public BloomDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float _offX;

        private float _offY;

        private float _alpha;

        private float _radius;

        public override string Name => "bloom";

        public override void Parse(XmlAttributeCollection xml)
        {
            _offX = Get(xml, "offsetX", 0f);
            _offY = Get(xml, "offsetY", 0f);
            _alpha = Get(xml, "alpha", 1f);
            _radius = Get(xml, "radius", 1f);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var scaledOffset = decal.GetScaledOffset(_offX, _offY);
            var scaledRadius = decal.GetScaledRadius(_radius);
            Context.AddBloom(decal, scaledOffset, _alpha, scaledRadius);
        }
    }
}
