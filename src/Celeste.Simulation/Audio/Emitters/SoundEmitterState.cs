using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Scene.Lifecycle;

namespace Celeste.Simulation.Audio.Emitters
{
    public class SoundEmitterState : SceneEntityState
    {
        public SoundSourceComponentState Source { get; private set; }

        private SoundEmitterState(string sfx, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Source = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            OwnedComponents.Add(Source);
            Source.Play(sfx);
            Source.DisposeOnTransition = false;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .Persistent.Value |
                   ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .TransitionUpdate.Value;
            OwnedComponents.Add(new LevelEndingHookState(OnLevelEnding));
        }

        private SoundEmitterState(string sfx, ISourceEntityPosition follow, Vector2 offset,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Source = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            OwnedComponents.Add(Source);
            Position = follow.Position + offset;
            Source.Play(sfx);
            Source.DisposeOnTransition = false;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .Persistent.Value |
                   ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .TransitionUpdate.Value;
            OwnedComponents.Add(new LevelEndingHookState(OnLevelEnding));
        }

        public static SoundEmitterState Play(string sfx, ISourceEngineContext engine)
        {
            var emitter = new SoundEmitterState(sfx, engine);
            ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(emitter);
            return emitter;
        }

        public static SoundEmitterState Play(string sfx, ISourceEntityPosition follow,
            ISourceEngineContext engine, Vector2? offset = null)
        {
            var emitter = new SoundEmitterState(sfx, follow, offset.HasValue ? offset.Value : Vector2.Zero, engine);
            ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(emitter);
            return emitter;
        }

        public override void Update()
        {
            base.Update();
            if (!Source.Playing) RemoveSelf();
        }

        private void OnLevelEnding() => Source.Stop();
    }
}
