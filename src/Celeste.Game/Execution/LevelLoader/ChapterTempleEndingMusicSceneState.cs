using Celeste.Simulation;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class
        ChapterTempleEndingMusicSceneState : ChapterGlobalSceneState
    {
        public ChapterTempleEndingMusicSceneState() : base(0,
            OriginalSceneTags.Global | OriginalSceneTags.TransitionUpdate)
        {
        }
    }
}
