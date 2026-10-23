using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using System.Numerics;

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
            int x = _x;
            int y = _y;
            int width = _width;
            int height = _height;
            decal.ScaleRectangle(ref x, ref y, ref width, ref height);
            Context.AddLightOcclude(decal, x, y, width, height, _alpha);
        }
    }
}
