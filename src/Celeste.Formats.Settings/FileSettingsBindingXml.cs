using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public sealed class FileSettingsBindingXml
    {
        [XmlArrayItem("Keys")] public List<FileSettingsKey> Keyboard = [];
        [XmlArrayItem("Buttons")] public List<FileSettingsButton> Controller = [];
    }
}
