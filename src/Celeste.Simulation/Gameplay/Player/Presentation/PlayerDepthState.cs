using System;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Player.Presentation
{
    // One entity property shared by the standalone state modules and their owning Player.
    public sealed class PlayerDepthState
    {
        public readonly SceneEntityDepthState Fields = new();

        private object owner;
        private Func<object> scene;

        public void BindOwner(object identity, Func<object> sceneSource)
        {
            owner = identity;
            scene = sceneSource;
        }

        public event Action<int> Changed;

        public int Value
        {
            get => Fields.RawDepth;
            set
            {
                if (Fields.RawDepth == value) return;
                Fields.SetDepth(value, scene?.Invoke(), owner);
                Changed?.Invoke(value);
            }
        }
    }
}
