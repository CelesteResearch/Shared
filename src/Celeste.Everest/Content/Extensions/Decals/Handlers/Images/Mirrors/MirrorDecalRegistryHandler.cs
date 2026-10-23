using System;
using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Mirrors
{
    public sealed class MirrorDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public MirrorDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private bool _keepOffsetsClose;

        public override string Name => "mirror";

        public override void Parse(XmlAttributeCollection xml)
        {
            _keepOffsetsClose = GetBool(xml, "keepOffsetsClose", false);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var text = decal.Name.ToLower();
            if (text.StartsWith("decals/", StringComparison.Ordinal)) text = text.Substring(7);

            Context.MakeMirror(decal, text, _keepOffsetsClose);
        }
    }
}
