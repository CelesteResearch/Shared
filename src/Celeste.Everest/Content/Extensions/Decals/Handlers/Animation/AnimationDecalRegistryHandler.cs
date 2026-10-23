using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Animation
{
    public sealed class AnimationDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public AnimationDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int[] _frames;

        public override string Name => "animation";

        public override void Parse(XmlAttributeCollection xml)
        {
            _frames = GetCSVIntWithTricks(xml, "frames", "0");
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            decal.MakeAnimation(_frames);
        }
    }
}
