using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteAudioState(string name, AudioState value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(WriteAudioTrackState("Music", value.Music));
        element.Add(WriteAudioTrackState("Ambience", value.Ambience));
        element.Add(value.AmbienceVolume.HasValue
            ? new XElement("AmbienceVolume", XmlConvert.ToString(value.AmbienceVolume.Value))
            : Nil("AmbienceVolume"));
        return element;
    }

    internal static AudioState ReadAudioState(XElement element, bool nullable)
    {
        ValidateType(element, "AudioState");
        if (nullable && IsNil(element)) return null;
        var value = new AudioState();
        var fieldMusic = element.Element("Music");
        if (fieldMusic != null) value.Music = ReadAudioTrackState(fieldMusic, false);
        var fieldAmbience = element.Element("Ambience");
        if (fieldAmbience != null) value.Ambience = ReadAudioTrackState(fieldAmbience, false);
        var fieldAmbienceVolume = element.Element("AmbienceVolume");
        if (fieldAmbienceVolume != null)
            value.AmbienceVolume = IsNil(fieldAmbienceVolume)
                ? (float?)null
                : XmlConvert.ToSingle(ReadText(fieldAmbienceVolume));
        return value;
    }
}
