using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Game.Execution.Startup;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public class SourceSafeRoutine : IEnumerator
    {
        private readonly ISourceEngineContext engine;
        private IEnumerator Inner;
        private SceneEntityState CoroutineEntity;
        private SimulationCoroutine Coroutine;
        public object Current => null;

        public SourceSafeRoutine(IEnumerator inner, ISourceEngineContext engine)
        {
            Inner = inner;
            this.engine = engine;
        }

        public bool MoveNext()
        {
            if (Coroutine == null)
            {
                CoroutineEntity =
                    new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
                CoroutineEntity.Tags =
                    ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
                CoroutineEntity.Add(Coroutine = new SimulationCoroutine(engine, Inner, true));
                ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(CoroutineEntity);
            }

            bool finished = Coroutine.Finished;
            if (finished)
            {
                CoroutineEntity.RemoveSelf();
                CoroutineEntity = null;
            }

            return !finished;
        }

        public void Reset()
        {
            Inner.Reset();
            CoroutineEntity?.RemoveSelf();
            Coroutine = null;
            CoroutineEntity = null;
        }
    }
}
