using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool StrawberriesBlocked;
        public int StrawberryCollectIndex;
        public float StrawberryCollectResetTimer;
        public bool LoseShards => Data.OnGround;
        public bool OnSafeGround => Data.OnSafeGround;

        private bool CollideBlockField()
        {
            foreach (var entry in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.BlockField"))
            {
                var actual = (ISourceEntityCollider)entry;
                if (((ISourceMutableEntityState)actual).Collidable && SourceEntityCollision.Check(this, actual))
                    return true;
            }

            return false;
        }
    }
}
