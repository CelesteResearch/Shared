using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public interface IOriginalChapterMapLoadPolicy
    {
        void Load(OriginalChapterMapData map);
        OriginalLevelRoomData Get(OriginalChapterMapData map, string levelName);
    }
}
