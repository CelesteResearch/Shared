using System;

namespace Celeste.Scene.Components
{
    public sealed class SceneComponentUpdate
    {
        public Func<bool> EntityActive, ComponentActive;
        public Action<float> Update;
    }
}
