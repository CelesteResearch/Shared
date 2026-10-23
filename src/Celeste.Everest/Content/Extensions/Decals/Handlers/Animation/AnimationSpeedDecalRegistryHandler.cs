using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;

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
            float? value = _value;
            if (value.HasValue)
            {
                float valueOrDefault = value.GetValueOrDefault();
                decal.AnimationSpeed = valueOrDefault;
            }
        }
    }
}
