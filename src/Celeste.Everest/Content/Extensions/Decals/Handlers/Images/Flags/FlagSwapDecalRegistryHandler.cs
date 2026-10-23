using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Flags
{
    public sealed class FlagSwapDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public FlagSwapDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private string _flag;

        private string _offPath;

        private string _onPath;

        public override string Name => "flagSwap";

        public override void Parse(XmlAttributeCollection xml)
        {
            _flag = GetString(xml, "flag", null);
            _offPath = GetString(xml, "offPath", null);
            _onPath = GetString(xml, "onPath", null);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            string flag = _flag;
            if (flag != null)
            {
                Context.MakeFlagSwap(decal, flag, _offPath, _onPath);
            }
        }
    }
}
