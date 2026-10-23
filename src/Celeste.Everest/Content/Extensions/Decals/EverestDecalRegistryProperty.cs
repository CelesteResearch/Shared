using System.Xml;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed class EverestDecalRegistryProperty
    {
        public string Name;
        public XmlAttributeCollection Attributes;
        public EverestDecalPropertyHandler Handler;
    }
}
