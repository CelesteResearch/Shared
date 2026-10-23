namespace Celeste.Core.Framework.GarbageCollection
{
    public interface ISourceGarbageCollectionDevice
    {
        void CollectBackground();
        void CollectOnRoomTransition();
        void CollectOnReload();
        void CollectOnSceneTransition();
    }
}
