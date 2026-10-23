using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Celeste.Simulation;
using YamlDotNet.Serialization;

namespace Celeste.Everest
{
    [Celeste.Everest.Settings.Metadata.SettingMenuName("CompatMode")]
    public enum EverestCompatMode
    {
        None,
        LegacyXNA,
        LegacyFNA
    }
}
