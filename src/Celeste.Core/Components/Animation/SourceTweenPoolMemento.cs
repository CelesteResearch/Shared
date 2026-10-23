using System;

namespace Celeste.Core.Components.Animation
{
    public sealed class SourceTweenPoolMemento
    {
        public SourceTweenState[] CachedTweens;

        public SourceTweenPoolMemento()
        {
            CachedTweens = Array.Empty<SourceTweenState>();
        }

        internal SourceTweenPoolMemento(SourceTweenState[] cachedTweens)
        {
            CachedTweens = cachedTweens;
        }
    }
}
