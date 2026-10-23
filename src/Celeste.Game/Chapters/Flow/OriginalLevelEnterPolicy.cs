using System.Collections;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalLevelEnterPolicy : IOriginalLevelEnterPolicy
    {
        public void Go(ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process)
        {
            OriginalLevelEntryRouting.Go(session, fromSaveData, process.Frame.Scenes,
                ((IOriginalLevelEntryEnvironment)process).LevelEntries);
        }

        public IEnumerator SelectRoutine(LevelEnterSequence actualScene)
        {
            return actualScene.OriginalRoutine();
        }
    }
}
