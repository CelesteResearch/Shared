using Celeste.Core.Scheduling;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
// The two source event groups share process lifetime, not LevelEnter scene lifetime.
    public sealed class EverestLevelEnterEvents
    {
        public delegate ISourceSceneExecution
            CustomVignetteHandler(ChapterCompletionSession session, bool fromSaveData);

        public delegate void EnterHandler(ChapterCompletionSession session, bool fromSaveData);

        public event CustomVignetteHandler OnPlayVignette;
        public event EnterHandler OnEnter;

        public ISourceSceneExecution PlayVignette(ChapterCompletionSession session, bool fromSaveData)
        {
            if (OnPlayVignette == null)
                return null;
            var invocationList = OnPlayVignette.GetInvocationList();
            for (var i = 0; i < invocationList.Length; i++)
            {
                var scene = ((CustomVignetteHandler)invocationList[i])(session, fromSaveData);
                if (scene != null)
                    return scene;
            }

            return null;
        }

        public void Enter(ChapterCompletionSession session, bool fromSaveData)
        {
            OnEnter?.Invoke(session, fromSaveData);
        }
    }
}
