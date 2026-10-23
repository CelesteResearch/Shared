using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Platforms
{
    public sealed class StaticMoverDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public StaticMoverDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int _x;

        private int _y;

        private int _width;

        private int _height;

        public override string Name => "staticMover";

        public override void Parse(XmlAttributeCollection xml)
        {
            _x = Get(xml, "x", 0);
            _y = Get(xml, "y", 0);
            _width = Get(xml, "width", 16);
            _height = Get(xml, "height", 16);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var x = _x;
            var y = _y;
            var width = _width;
            var height = _height;
            decal.ScaleRectangle(ref x, ref y, ref width, ref height);
            Context.MakeStaticMover(decal, x, y, width, height);
        }
    }
}
