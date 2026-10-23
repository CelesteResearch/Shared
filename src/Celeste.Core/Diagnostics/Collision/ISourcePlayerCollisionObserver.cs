namespace Celeste.Core.Diagnostics.Collision
{
    public interface ISourcePlayerCollisionObserver
    {
        void RecordCollider(object entity);
        void RecordOtherPlayerColliders(object player);
    }
}
