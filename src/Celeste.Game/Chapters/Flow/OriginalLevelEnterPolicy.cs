using Celeste.Game.Chapters.Flow;
using System.Collections;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalLevelEnterPolicy : IOriginalLevelEnterPolicy
    {
        public void Go(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process)
            => OriginalLevelEntryRouting.Go(session, fromSaveData, process.Frame.Scenes,
                ((IOriginalLevelEntryEnvironment)process).LevelEntries);

        public IEnumerator SelectRoutine(LevelEnterSequence actualScene) => actualScene.OriginalRoutine();
    }
}
