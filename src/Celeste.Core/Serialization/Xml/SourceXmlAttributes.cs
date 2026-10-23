using System;
using System.Globalization;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlAttributes
    {
        public static bool HasAttr(this XmlElement xml, string attributeName)
        {
            return xml.Attributes[attributeName] != null;
        }

        public static string Attr(this XmlElement xml, string attributeName)
        {
            return xml.Attributes[attributeName].InnerText;
        }

        public static string Attr(this XmlElement xml, string attributeName, string defaultValue)
        {
            if (!xml.HasAttr(attributeName))
            {
                return defaultValue;
            }

            return xml.Attributes[attributeName].InnerText;
        }

        public static bool AttrBool(this XmlElement xml, string attributeName)
        {
            return Convert.ToBoolean(xml.Attributes[attributeName].InnerText);
        }

        public static bool AttrBool(this XmlElement xml, string attributeName, bool defaultValue)
        {
            if (!xml.HasAttr(attributeName))
            {
                return defaultValue;
            }

            return xml.AttrBool(attributeName);
        }

        public static int AttrInt(this XmlElement xml, string attributeName)
        {
            return Convert.ToInt32(xml.Attributes[attributeName].InnerText);
        }

        public static int AttrInt(this XmlElement xml, string attributeName, int defaultValue)
        {
            if (!xml.HasAttr(attributeName))
            {
                return defaultValue;
            }

            return Convert.ToInt32(xml.Attributes[attributeName].InnerText);
        }

        public static float AttrFloat(this XmlElement xml, string attributeName)
        {
            return Convert.ToSingle(xml.Attributes[attributeName].InnerText, CultureInfo.InvariantCulture);
        }

        public static float AttrFloat(this XmlElement xml, string attributeName, float defaultValue)
        {
            if (!xml.HasAttr(attributeName))
            {
                return defaultValue;
            }

            return Convert.ToSingle(xml.Attributes[attributeName].InnerText, CultureInfo.InvariantCulture);
        }

        public static void SetAttr(this XmlElement xml, string attributeName, object setTo)
        {
            XmlAttribute xmlAttribute;
            if (xml.HasAttr(attributeName))
                xmlAttribute = xml.Attributes[attributeName];
            else
            {
                xmlAttribute = xml.OwnerDocument.CreateAttribute(attributeName);
                xml.Attributes.Append(xmlAttribute);
            }

            xmlAttribute.Value = setTo.ToString();
        }
    }
}
