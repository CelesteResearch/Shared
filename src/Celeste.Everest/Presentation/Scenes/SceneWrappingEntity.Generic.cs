using System;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Presentation.Scenes
{
    public class SceneWrappingEntity<T> : SceneWrappingEntity where T : SourceSceneState
    {
        public readonly new T WrappedScene;

        public new event Action<T> OnBegin;
        public new event Action<T> OnEnd;

        public SceneWrappingEntity(T scene) : base(scene)
        {
            WrappedScene = scene;
            base.OnBegin += _ => OnBegin?.Invoke(WrappedScene);
            base.OnEnd += _ => OnEnd?.Invoke(WrappedScene);
        }
    }
}
