using System;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        public event Action<SceneEntityState> PreUpdate;
        public event Action<SceneEntityState> PostUpdate;
        public void BeforeEntityUpdate() => PreUpdate?.Invoke(this);
        public void AfterEntityUpdate() => PostUpdate?.Invoke(this);
    }
}
