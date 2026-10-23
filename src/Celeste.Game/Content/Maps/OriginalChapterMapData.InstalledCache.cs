using System.Collections.Generic;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        public Dictionary<string, OriginalLevelRoomData> LevelsByName;
        public List<OriginalLevelEntityData> DashlessGoldenberries;
    }
}
