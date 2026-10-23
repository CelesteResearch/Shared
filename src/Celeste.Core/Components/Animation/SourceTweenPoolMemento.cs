namespace Celeste.Core.Components.Animation
{
    public sealed class SourceTweenPoolMemento
    {
        public SourceTweenState[] CachedTweens;

        public SourceTweenPoolMemento()
        {
            CachedTweens = [];
        }

        internal SourceTweenPoolMemento(SourceTweenState[] cachedTweens)
        {
            CachedTweens = cachedTweens;
        }
    }
}
