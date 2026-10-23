using System.Numerics;
using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry
{
    public sealed class ScaleDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public ScaleDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private Vector2 _scale;

        public override string Name => "scale";

        public override void Parse(XmlAttributeCollection xml)
        {
            _scale = GetVector2(xml, "multiplyX", "multiplyY", Vector2.One);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            decal.Scale *= _scale;
        }
    }
}
