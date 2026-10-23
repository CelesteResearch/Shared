using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Animation
{
    public sealed class RandomizeFrameDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public RandomizeFrameDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        public override string Name => "randomizeFrame";

        public override void Parse(XmlAttributeCollection xml)
        {
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            Context.RandomizeStartingFrame(decal);
        }
    }
}
