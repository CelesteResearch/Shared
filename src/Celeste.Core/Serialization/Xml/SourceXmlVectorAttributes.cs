using System.Globalization;
using System.Numerics;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlVectorAttributes
    {
        public static Vector3 AttrVector3(this XmlElement xml, string attributeName)
        {
            string[] array = xml.Attr(attributeName).Split(',');
            float x = float.Parse(array[0].Trim(), CultureInfo.InvariantCulture);
            float y = float.Parse(array[1].Trim(), CultureInfo.InvariantCulture);
            float z = float.Parse(array[2].Trim(), CultureInfo.InvariantCulture);
            return new Vector3(x, y, z);
        }
    }
}
