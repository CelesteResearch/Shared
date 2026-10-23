namespace Celeste.Core.Framework.GarbageCollection
{
    public interface ISourceGarbageCollectionPolicy
    {
        bool ShouldSkipCollection { get; }
        void CollectOnTransition();
        void CollectOnReload();
        void CollectOnSceneTransition();
    }
}
