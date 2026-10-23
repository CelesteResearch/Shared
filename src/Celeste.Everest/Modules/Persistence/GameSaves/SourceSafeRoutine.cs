using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public class SourceSafeRoutine : IEnumerator
    {
        private readonly ISourceEngineContext engine;
        private readonly IEnumerator Inner;
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
                    new(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
                CoroutineEntity.Tags =
                    ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value |
                    ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
                CoroutineEntity.Add(Coroutine = new(engine, Inner));
                ((SourceSceneState)engine.Frame.Scenes.CurrentScene).AddEntity(CoroutineEntity);
            }

            var finished = Coroutine.Finished;
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
