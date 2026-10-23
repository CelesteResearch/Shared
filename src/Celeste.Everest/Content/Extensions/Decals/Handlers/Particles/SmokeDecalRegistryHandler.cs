using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using System.Numerics;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Particles
{
    public sealed class SmokeDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public SmokeDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float _offX;

        private float _offY;

        private bool _inbg;

        public override string Name => "smoke";

        public override void Parse(XmlAttributeCollection xml)
        {
            _offX = Get(xml, "offsetX", 0f);
            _offY = Get(xml, "offsetY", 0f);
            _inbg = GetBool(xml, "inbg", def: false);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            Vector2 scaledOffset = decal.GetScaledOffset(_offX, _offY);
            Context.CreateSmoke(decal, scaledOffset, _inbg);
        }
    }
}
