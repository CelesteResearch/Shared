using System.Collections;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalLevelEnterPolicy
    {
        void Go(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process);

        IEnumerator SelectRoutine(LevelEnterSequence actualScene);
    }
}
