using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals.Handlers.Audio
{
    public sealed class SoundDecalRegistryHandler : EverestDecalPropertyHandler
    {
        public SoundDecalRegistryHandler(EverestDecalFeatureContext context) : base(context)
        {
        }

        private string _event;

        public override string Name => "sound";

        public override void Parse(XmlAttributeCollection xml)
        {
            _event = GetString(xml, "event", null);
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            var text = _event;
            if (text != null) Context.AddSound(decal, text);
        }
    }
}
