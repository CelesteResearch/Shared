using System.Collections.Generic;
using System.Xml;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public struct EverestDecalInfo
    {
        public List<KeyValuePair<string, XmlAttributeCollection>> CustomProperties;
        internal List<EverestDecalPropertyHandler> Handlers { get; set; }
    }
}
