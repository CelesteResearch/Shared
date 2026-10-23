using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourcePlatformActor
    {
        public override bool IsRiding(ISourceEntityCollider solid)
        {
            if (Machine.State == 23) return false;
            if (Machine.State == 9) return SourceEntityCollision.Check(this, solid);
            if (Machine.State == 1 || Machine.State == 6)
                return CheckPlatformAt(solid, Position + Vector2.UnitX * Data.Facing);
            if (Data.ClimbTriggerDirection != 0)
                return CheckPlatformAt(solid, Position + Vector2.UnitX * Data.ClimbTriggerDirection);
            return base.IsRiding(solid);
        }

        public override bool IsRiding(ISourceJumpThruCollider jumpThru)
        {
            if (Machine.State == 9) return false;
            if (Machine.State != 1 && Data.Motion.Normal.Speed.Y >= 0f)
                return base.IsRiding(jumpThru);

            return false;
        }

        private bool CheckPlatformAt(ISourceEntityCollider platform, Vector2 at)
        {
            var from = Position;
            Position = at;
            var result = SourceEntityCollision.Check(this, platform);
            Position = from;
            return result;
        }
    }
}
