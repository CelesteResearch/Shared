using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using W = Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Xml
{
    [XmlRoot("ModSaveData")]
    public sealed class ModSaveData
    {
        public List<LevelSetStats> LevelSets = new List<LevelSetStats>();
        public List<LevelSetStats> LevelSetRecycleBin = new List<LevelSetStats>();
        public AreaKey LastArea_Safe = new AreaKey();
        public Session CurrentSession_Safe;
    }
}
