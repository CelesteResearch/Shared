using System.Numerics;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalChapterMapStartPolicy : IOriginalChapterMapStartPolicy
    {
        public OriginalLevelRoomData StartLevel(OriginalChapterMapData actualMap)
        {
            return actualMap.GetAt(Vector2.Zero);
        }
    }
}
