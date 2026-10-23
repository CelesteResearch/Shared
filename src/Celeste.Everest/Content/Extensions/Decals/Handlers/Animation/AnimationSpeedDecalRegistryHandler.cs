using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Animation
{
    public sealed class AnimationSpeedDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public AnimationSpeedDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float? _value;

        public override string Name => "animationSpeed";

        public override void Parse(XmlAttributeCollection xml)
        {
            _value = GetNullableFloat(xml, "value");
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var value = _value;
            if (!value.HasValue)
                return;
            var valueOrDefault = value.GetValueOrDefault();
            decal.AnimationSpeed = valueOrDefault;
        }
    }
}
