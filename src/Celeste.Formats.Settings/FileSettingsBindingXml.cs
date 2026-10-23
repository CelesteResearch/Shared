using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public sealed class FileSettingsBindingXml
    {
        [XmlArrayItem("Keys")] public List<FileSettingsKey> Keyboard = new List<FileSettingsKey>();
        [XmlArrayItem("Buttons")] public List<FileSettingsButton> Controller = new List<FileSettingsButton>();
    }
}
