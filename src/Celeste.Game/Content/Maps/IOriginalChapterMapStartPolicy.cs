using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public interface IOriginalChapterMapStartPolicy
    {
        OriginalLevelRoomData StartLevel(OriginalChapterMapData actualMap);
    }
}
