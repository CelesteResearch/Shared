using System.Collections.Generic;
using System.Xml;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private static void WriteBinding(XmlWriter writer, string name, FileSettingsBindingXml binding)
        {
            if (binding == null) return;
            writer.WriteStartElement(name);
            if (binding.Keyboard != null)
            {
                writer.WriteStartElement("Keyboard");
                foreach (var key in binding.Keyboard) writer.WriteElementString("Keys", FormatFileSettingsKey(key));
                writer.WriteEndElement();
            }

            if (binding.Controller != null)
            {
                writer.WriteStartElement("Controller");
                foreach (var button in binding.Controller)
                    writer.WriteElementString("Buttons", FormatFileSettingsButton(button));
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static FileSettingsBindingXml ReadBinding(XmlReader reader)
        {
            ValidateXmlType(reader, "FileSettingsBindingXml");
            var binding = new FileSettingsBindingXml();
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return binding;
            }

            reader.ReadStartElement();
            while (MoveToElementOrEnd(reader))
                if (reader.NamespaceURI.Length == 0 && reader.LocalName == "Keyboard")
                    ReadKeys(reader, binding.Keyboard);
                else if (reader.NamespaceURI.Length == 0 && reader.LocalName == "Controller")
                    ReadButtons(reader, binding.Controller);
                else reader.Skip();

            reader.ReadEndElement();
            return binding;
        }

        private static void ReadKeys(XmlReader reader, List<FileSettingsKey> keys)
        {
            if (ReadEmptyList(reader)) return;
            reader.ReadStartElement();
            while (MoveToElementOrEnd(reader))
                if (reader.NamespaceURI.Length == 0 && reader.LocalName == "Keys")
                    keys.Add(ParseFileSettingsKey(reader.ReadElementContentAsString()));
                else reader.Skip();

            reader.ReadEndElement();
        }

        private static void ReadButtons(XmlReader reader, List<FileSettingsButton> buttons)
        {
            if (ReadEmptyList(reader)) return;
            reader.ReadStartElement();
            while (MoveToElementOrEnd(reader))
                if (reader.NamespaceURI.Length == 0 && reader.LocalName == "Buttons")
                    buttons.Add(ParseFileSettingsButton(reader.ReadElementContentAsString()));
                else reader.Skip();

            reader.ReadEndElement();
        }

        private static bool ReadEmptyList(XmlReader reader)
        {
            var nil = reader.GetAttribute("nil", SchemaInstanceNamespace);
            if (nil != null && XmlConvert.ToBoolean(nil))
            {
                reader.Skip();
                return true;
            }

            if (!reader.IsEmptyElement) return false;
            reader.Read();
            return true;
        }
    }
}
