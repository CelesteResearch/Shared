using System;
using System.Collections;
using System.Numerics;
using Celeste.Scene.Entities;

namespace Celeste.Game.Execution.Levels.Cutscenes
{
    public abstract class OriginalCutsceneEntityState : SceneEntityState
    {
        public bool WasSkipped;
        public bool RemoveOnSkipped = true;
        public bool EndingChapterAfter;
        public OriginalLevelSceneRoot Level;
        public bool Running { get; private set; }
        public bool FadeInOnSkip { get; private set; }

        protected OriginalCutsceneEntityState(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            bool fadeInOnSkip = true, bool endingChapterAfter = false)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            FadeInOnSkip = fadeInOnSkip;
            EndingChapterAfter = endingChapterAfter;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Level = scene as OriginalLevelSceneRoot;
            Start();
        }

        public void Start()
        {
            Running = true;
            Level.StartCutscene(SkipCutscene, FadeInOnSkip, EndingChapterAfter);
            OnBegin(Level);
        }

        public override void Update()
        {
            if (Level.RetryPlayerCorpse != null) Active = false;
            else base.Update();
        }

        private void SkipCutscene(OriginalLevelSceneRoot level)
        {
            WasSkipped = true;
            EndCutscene(level, RemoveOnSkipped);
        }

        public void EndCutscene(OriginalLevelSceneRoot level, bool removeSelf = true)
        {
            Running = false;
            OnEnd(level);
            level.EndCutscene();
            if (removeSelf) RemoveSelf();
        }

        public abstract void OnBegin(OriginalLevelSceneRoot level);
        public abstract void OnEnd(OriginalLevelSceneRoot level);

        public static IEnumerator CameraTo(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            Vector2 target, float duration, Func<float, float> ease = null, float delay = 0f)
        {
            if (ease == null)
                ease = ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic
                    .CubeInOut;
            if (delay > 0f) yield return delay;
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
            Vector2 from = level.Camera.Position;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                level.Camera.Position = global::Celeste.Core.Mathematics.Vector2Interpolation.Lerp(from, target,
                    ease(p), ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            level.Camera.Position = target;
        }
    }
}
