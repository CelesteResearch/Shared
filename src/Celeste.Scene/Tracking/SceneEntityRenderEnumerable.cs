using System.Collections.Generic;

namespace Celeste.Scene.Tracking
{
    internal readonly struct SceneEntityRenderEnumerable
    {
        private readonly List<object> entities;

        internal SceneEntityRenderEnumerable(List<object> entities)
        {
            this.entities = entities;
        }

        public List<object>.Enumerator GetEnumerator() => entities.GetEnumerator();
    }
}
