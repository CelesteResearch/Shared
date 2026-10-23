using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Overlays
{
    public sealed class OverlayDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public OverlayDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        public override string Name => "overlay";

        public override void Parse(XmlAttributeCollection xml)
        {
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            decal.MakeOverlay();
        }
    }
}
