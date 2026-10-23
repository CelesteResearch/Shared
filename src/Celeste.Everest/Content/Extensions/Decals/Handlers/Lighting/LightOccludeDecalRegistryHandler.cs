using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting
{
    public sealed class LightOccludeDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public LightOccludeDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int _x;

        private int _y;

        private int _width;

        private int _height;

        private float _alpha;

        public override string Name => "lightOcclude";

        public override void Parse(XmlAttributeCollection xml)
        {
            _x = Get(xml, "x", 0);
            _y = Get(xml, "y", 0);
            _width = Get(xml, "width", 16);
            _height = Get(xml, "height", 16);
            _alpha = Get(xml, "alpha", 1f);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var x = _x;
            var y = _y;
            var width = _width;
            var height = _height;
            decal.ScaleRectangle(ref x, ref y, ref width, ref height);
            Context.AddLightOcclude(decal, x, y, width, height, _alpha);
        }
    }
}
