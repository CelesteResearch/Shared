using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    // This static wire graph never requires reflection emit or generated serializers.
    internal static partial class SaveXmlWire
    {
        private static readonly XNamespace Xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly XNamespace Xsd = "http://www.w3.org/2001/XMLSchema";

        internal static void WriteDocument(Stream stream, string name, XElement root)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            try
            {
                var nil = root == null;
                root ??= new(name);
                root.Add(new XAttribute(XNamespace.Xmlns + "xsi", Xsi.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "xsd", Xsd.NamespaceName));
                if (nil) root.Add(new XAttribute(Xsi + "nil", "true"));
                using var writer = XmlWriter.Create(stream, new()
                {
                    Encoding = new UTF8Encoding(false), Indent = true, CloseOutput = false,
                });
                writer.WriteStartDocument();
                root.WriteTo(writer);
                writer.WriteEndDocument();
            }
            catch (Exception error)
            {
                throw new InvalidOperationException("There was an error generating the XML document.", error);
            }
        }

        internal static XElement ReadDocument(Stream stream, string name)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using var reader = XmlReader.Create(stream, new() { CloseInput = false });
            reader.MoveToContent();
            var root = (XElement)XNode.ReadFrom(reader);
            if (root.Name != XName.Get(name))
                throw new InvalidOperationException($"<{root.Name}> was not expected.");
            return root;
        }

        private static XElement TextElement(string name, string text)
        {
            return text.Length == 0 ? new(name) : new XElement(name, text);
        }

        private static XElement Nil(string name)
        {
            return new(name, new XAttribute(Xsi + "nil", "true"));
        }

        private static bool IsNil(XElement element)
        {
            var nil = element.Attribute(Xsi + "nil");
            return nil != null && XmlConvert.ToBoolean(nil.Value);
        }

        private static string ReadText(XElement element)
        {
            if (element.HasElements) throw new XmlException("An XML scalar cannot contain child elements.");
            return element.Value;
        }

        private static void ValidateType(XElement element, string expected)
        {
            var type = element.Attribute(Xsi + "type");
            if (type == null) return;
            var text = type.Value.Trim();
            var separator = text.IndexOf(':');
            var local = separator < 0 ? text : text.Substring(separator + 1);
            var ns = separator < 0
                ? element.GetDefaultNamespace()
                : element.GetNamespaceOfPrefix(text.Substring(0, separator));
            if (local != expected || ns != XNamespace.None)
                throw new InvalidOperationException($"The specified type was not recognized: {text}.");
        }

        private static AreaMode ReadAreaMode(string value)
        {
            return value switch
            {
                "Normal" => AreaMode.Normal,
                "BSide" => AreaMode.BSide,
                "CSide" => AreaMode.CSide,
                _ => throw new InvalidOperationException($"Invalid AreaMode value: {value}."),
            };
        }

        private static string WriteAreaMode(AreaMode value)
        {
            return value switch
            {
                AreaMode.Normal => "Normal",
                AreaMode.BSide => "BSide",
                AreaMode.CSide => "CSide",
                _ => throw new InvalidOperationException($"Invalid AreaMode value: {value}."),
            };
        }

        private static DashMode ReadDashMode(string value)
        {
            return value switch
            {
                "Normal" => DashMode.Normal,
                "Two" => DashMode.Two,
                "Infinite" => DashMode.Infinite,
                _ => throw new InvalidOperationException($"Invalid DashMode value: {value}."),
            };
        }

        private static string WriteDashMode(DashMode value)
        {
            return value switch
            {
                DashMode.Normal => "Normal",
                DashMode.Two => "Two",
                DashMode.Infinite => "Infinite",
                _ => throw new InvalidOperationException($"Invalid DashMode value: {value}."),
            };
        }

        private static CoreMode ReadCoreMode(string value)
        {
            return value switch
            {
                "None" => CoreMode.None,
                "Hot" => CoreMode.Hot,
                "Cold" => CoreMode.Cold,
                _ => throw new InvalidOperationException($"Invalid CoreMode value: {value}."),
            };
        }

        private static string WriteCoreMode(CoreMode value)
        {
            return value switch
            {
                CoreMode.None => "None",
                CoreMode.Hot => "Hot",
                CoreMode.Cold => "Cold",
                _ => throw new InvalidOperationException($"Invalid CoreMode value: {value}."),
            };
        }
    }
}
