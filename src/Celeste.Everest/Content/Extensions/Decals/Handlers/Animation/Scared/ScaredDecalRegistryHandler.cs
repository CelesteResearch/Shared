using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.Scared
{
    public sealed class ScaredDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public ScaredDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private int[] _idleFrames;

        private int[] _hiddenFrames;

        private int[] _hideFrames;

        private int[] _showFrames;

        private int _hideRange;

        private int _showRange;

        public override string Name => "scared";

        public override void Parse(XmlAttributeCollection xml)
        {
            _hideRange = Get(xml, "range", 32);
            _showRange = Get(xml, "range", 48);
            _hideRange = Get(xml, "hideRange", _hideRange);
            _showRange = Get(xml, "showRange", _showRange);
            _idleFrames = GetCSVIntWithTricks(xml, "idleFrames", "0");
            _hiddenFrames = GetCSVIntWithTricks(xml, "hiddenFrames", "0");
            _hideFrames = GetCSVIntWithTricks(xml, "hideFrames", "0");
            _showFrames = GetCSVIntWithTricks(xml, "showFrames", "0");
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            int hideRange = (int)decal.GetScaledRadius(_hideRange);
            int showRange = (int)decal.GetScaledRadius(_showRange);
            Context.MakeScaredAnimation(decal, hideRange, showRange, _idleFrames, _hiddenFrames, _showFrames,
                _hideFrames);
        }
    }
}
