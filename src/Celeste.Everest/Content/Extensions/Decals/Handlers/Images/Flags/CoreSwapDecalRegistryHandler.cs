using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Game.Entities.Decoration.Decals;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Flags
{
    public sealed class CoreSwapDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public CoreSwapDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private string _hotPath;

        private string _coldPath;

        public override string Name => "coreSwap";

        public override void Parse(XmlAttributeCollection xml)
        {
            _hotPath = GetString(xml, "hotPath", null);
            _coldPath = GetString(xml, "coldPath", null);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            Context.MakeFlagSwap(decal, "cold", _hotPath, _coldPath);
        }
    }
}
