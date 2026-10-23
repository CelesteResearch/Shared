using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Content.Maps
{
    public interface IOriginalChapterMapConstructionEnvironment
    {
        OriginalChapterMapData CreateMapData(OriginalAreaKey actualArea);
    }
}
