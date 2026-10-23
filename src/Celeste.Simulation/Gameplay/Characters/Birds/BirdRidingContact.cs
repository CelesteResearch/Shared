using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Characters.Birds
{
    // BirdNPC.IsRiding(Solid) queries a Scene rectangle built from truncated
    // Bird position. Scene tracker membership is checked by the caller; a
    // pending RemoveSelf does not change this geometry or suppress the query.
    public static class BirdRidingContact
    {
        public static bool IsRiding(global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform,
            global::Celeste.Core.Geometry.IntRect ridingBounds)
            => !platform.IsJumpThru && platform.Intersects(new global::Celeste.Core.Geometry.Bounds(
                ridingBounds.X, ridingBounds.Y, ridingBounds.Width, ridingBounds.Height));
    }
}
