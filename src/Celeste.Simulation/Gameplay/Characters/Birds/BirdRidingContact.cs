using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Platforms.Collision;

namespace Celeste.Simulation.Gameplay.Characters.Birds
{
    // BirdNPC.IsRiding(Solid) queries a Scene rectangle built from truncated
    // Bird position. Scene tracker membership is checked by the caller; a
    // pending RemoveSelf does not change this geometry or suppress the query.
    public static class BirdRidingContact
    {
        public static bool IsRiding(CollisionPlatform platform,
            IntRect ridingBounds)
        {
            return !platform.IsJumpThru && platform.Intersects(new(
                ridingBounds.X, ridingBounds.Y, ridingBounds.Width, ridingBounds.Height));
        }
    }
}
