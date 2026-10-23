using System.Xml;
using Celeste.Core.Display;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting
{
    public sealed class LightDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public LightDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float _offX;

        private float _offY;

        private float _alpha;

        private int _startFade;

        private int _endFade;

        private PackedColor _color;

        public override string Name => "light";

        public override void Parse(XmlAttributeCollection xml)
        {
            _offX = Get(xml, "offsetX", 0f);
            _offY = Get(xml, "offsetY", 0f);
            _color = GetHexColor(xml, "color", PackedColor.White);
            _alpha = Get(xml, "alpha", 1f);
            _startFade = Get(xml, "startFade", 16);
            _endFade = Get(xml, "endFade", 24);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var scaledOffset = decal.GetScaledOffset(_offX, _offY);
            var startFade = (int)decal.GetScaledRadius(_startFade);
            var endFade = (int)decal.GetScaledRadius(_endFade);
            Context.AddLight(decal, scaledOffset, _color, _alpha, startFade, endFade);
        }
    }
}
