using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    [XmlRoot("ModSaveData")]
    public sealed class ModSaveData
    {
        public List<LevelSetStats> LevelSets = [];
        public List<LevelSetStats> LevelSetRecycleBin = [];
        public AreaKey LastArea_Safe = new();
        public Session CurrentSession_Safe;
    }
}
