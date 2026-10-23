using System;
using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Banners
{
    public sealed class BannerDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public BannerDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private float _speed;

        private float _amplitude;

        private float _sliceSinIncrement;

        private float _offset;

        private int _sliceSize;

        private bool _easeDown;

        private bool _onlyIfWindy;

        public override string Name => "banner";

        public override void Parse(XmlAttributeCollection xml)
        {
            _speed = Get(xml, "speed", 1f);
            _amplitude = Get(xml, "amplitude", 1f);
            _sliceSize = Get(xml, "sliceSize", 1);
            _sliceSinIncrement = Get(xml, "sliceSinIncrement", 1f);
            _easeDown = GetBool(xml, "easeDown", false);
            _offset = Get(xml, "offset", 0f);
            _onlyIfWindy = GetBool(xml, "onlyIfWindy", false);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var scale = decal.Scale;
            var amplitude = _amplitude * scale.X;
            var offset = _offset * Math.Sign(scale.X) * Math.Abs(scale.Y);
            Context.MakeBanner(decal, _speed, amplitude, _sliceSize, _sliceSinIncrement, _easeDown, offset,
                _onlyIfWindy);
        }
    }
}
