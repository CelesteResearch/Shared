using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class
        ChapterTempleEndingMusicSceneState : global::Celeste.Game.Execution.LevelLoader.ChapterGlobalSceneState
    {
        public ChapterTempleEndingMusicSceneState() : base(0,
            OriginalSceneTags.Global | OriginalSceneTags.TransitionUpdate)
        {
        }
    }
}
