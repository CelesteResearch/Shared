using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Platforms
{
    public sealed class SolidDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public SolidDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int _x;

        private int _y;

        private int _width;

        private int _height;

        private int _index;

        private int _priority;

        private bool _blockWaterfalls;

        private bool _safe;

        public override string Name => "solid";

        public override void Parse(XmlAttributeCollection xml)
        {
            _x = Get(xml, "x", 0);
            _y = Get(xml, "y", 0);
            _width = Get(xml, "width", 16);
            _height = Get(xml, "height", 16);
            _index = Get(xml, "index", 14);
            _priority = Get(xml, "priority", 0);
            _blockWaterfalls = GetBool(xml, "blockWaterfalls", true);
            _safe = GetBool(xml, "safe", true);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var x = _x;
            var y = _y;
            var width = _width;
            var height = _height;
            decal.ScaleRectangle(ref x, ref y, ref width, ref height);
            decal.MakeSolid(x, y, width, height, _index, _priority, _blockWaterfalls, _safe);
        }
    }
}
