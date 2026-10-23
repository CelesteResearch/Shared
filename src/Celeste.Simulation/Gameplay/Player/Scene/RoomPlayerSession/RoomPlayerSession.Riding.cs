using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Physics.Collision.Riding.ISourcePlatformActor
    {
        public override bool IsRiding(ISourceEntityCollider solid)
        {
            if (Machine.State == 23) return false;
            if (Machine.State == 9) return SourceEntityCollision.Check(this, solid);
            if (Machine.State == 1 || Machine.State == 6)
                return CheckPlatformAt(solid, Position + Vector2.UnitX * (float)Data.Facing);
            if (Data.ClimbTriggerDirection != 0)
                return CheckPlatformAt(solid, Position + Vector2.UnitX * Data.ClimbTriggerDirection);
            return base.IsRiding(solid);
        }

        public override bool IsRiding(global::Celeste.Physics.Collision.Riding.ISourceJumpThruCollider jumpThru)
        {
            if (Machine.State == 9) return false;
            if (Machine.State != 1 && Data.Motion.Normal.Speed.Y >= 0f)
                return base.IsRiding(jumpThru);

            return false;
        }

        private bool CheckPlatformAt(ISourceEntityCollider platform, Vector2 at)
        {
            Vector2 from = Position;
            Position = at;
            bool result = SourceEntityCollision.Check(this, platform);
            Position = from;
            return result;
        }
    }
}
