using System.Numerics;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.LevelLoader
{
    public interface IOriginalLevelLoaderFactory
    {
        OriginalLevelLoaderScene CreateLevelLoader(ChapterCompletionSession session,
            Vector2? startPosition = null);
    }
}
