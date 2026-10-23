using System;
using System.Xml;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed class LegacyEverestDecalPropertyHandler : EverestDecalPropertyHandler
    {
        private readonly Action<SourceDecalEntityState, XmlAttributeCollection> action;
        private XmlAttributeCollection attributes;
        public override string Name { get; }

        public LegacyEverestDecalPropertyHandler(string name,
            Action<SourceDecalEntityState, XmlAttributeCollection> action)
        {
            Name = name;
            this.action = action;
        }

        public override void Parse(XmlAttributeCollection xml)
        {
            attributes = xml;
        }

        public override void ApplyTo(SourceDecalEntityState decal)
        {
            action(decal, attributes);
        }
    }
}
