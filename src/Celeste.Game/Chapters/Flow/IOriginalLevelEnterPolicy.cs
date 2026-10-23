using System.Collections;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalLevelEnterPolicy
    {
        void Go(ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process);

        IEnumerator SelectRoutine(LevelEnterSequence actualScene);
    }
}
