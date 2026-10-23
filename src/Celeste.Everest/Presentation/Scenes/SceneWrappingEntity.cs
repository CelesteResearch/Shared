using System;
using Celeste.Core.Components;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Presentation.Scenes
{
    public class SceneWrappingEntity : SceneEntityState
    {
        public readonly SourceSceneState WrappedScene;
        public readonly NestedSceneRenderer Renderer;

        public bool Initialized { get; private set; }

        public event Action<SourceSceneState> OnBegin;
        public event Action<SourceSceneState> OnEnd;

        public SceneWrappingEntity(SourceSceneState scene)
            : base(((ISourceEntitySourceDataEnvironment)scene.EngineContext).EntitySourceDataRegistration)
        {
            WrappedScene = scene;
            Renderer = new NestedSceneRenderer(scene);
        }

        private void Initialize(object scene)
        {
            if (Initialized) return;
            Initialized = true;
            WrappedScene.Begin();
            ((SourceSceneState)scene).Renderers.Add(Renderer);
            Renderer.Alloc();
            OnBegin?.Invoke(WrappedScene);
        }

        private void Uninitialize(object scene)
        {
            if (!Initialized) return;
            Initialized = false;
            WrappedScene.End();
            ((SourceSceneState)scene).Renderers.Remove(Renderer);
            Renderer.Dispose();
            OnEnd?.Invoke(WrappedScene);
        }

        public override void SceneBegin(object scene)
        {
            base.SceneBegin(scene);
            Initialize(scene);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            Initialize(scene);
        }

        public override void HandleGraphicsCreate()
        {
            base.HandleGraphicsCreate();
            WrappedScene.HandleGraphicsCreate();
        }

        public override void HandleGraphicsReset()
        {
            base.HandleGraphicsReset();
            WrappedScene.HandleGraphicsReset();
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Uninitialize(scene);
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Uninitialize(scene);
        }
    }
}
