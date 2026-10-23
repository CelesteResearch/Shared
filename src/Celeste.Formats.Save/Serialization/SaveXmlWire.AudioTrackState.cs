using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteAudioTrackState(string name, AudioTrackState value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Event != null) element.Add(new XAttribute("Event", value.Event));
            if (value.Parameters != null)
            {
                var items = new XElement("Parameters");
                foreach (var item in value.Parameters)
                    items.Add(item == null ? Nil("MEP") : WriteMEP("MEP", item));
                element.Add(items);
            }

            return element;
        }

        internal static AudioTrackState ReadAudioTrackState(XElement element, bool nullable)
        {
            ValidateType(element, "AudioTrackState");
            if (nullable && IsNil(element)) return null;
            var value = new AudioTrackState();
            var fieldEvent = element.Attribute("Event");
            if (fieldEvent != null) value.Event = fieldEvent.Value;
            foreach (var container in element.Elements("Parameters"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("MEP"))
                    value.Parameters.Add(ReadMEP(item, true));
            }

            return value;
        }
    }
}
