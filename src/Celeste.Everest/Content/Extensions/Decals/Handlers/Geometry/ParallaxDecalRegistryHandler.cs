using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry
{
    public sealed class ParallaxDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public ParallaxDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float? _amount;

        public override string Name => "parallax";

        public override void Parse(XmlAttributeCollection xml)
        {
            _amount = GetNullableFloat(xml, "amount");
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var amount = _amount;
            if (!amount.HasValue)
                return;
            var valueOrDefault = amount.GetValueOrDefault();
            decal.MakeParallax(valueOrDefault);
        }
    }
}
