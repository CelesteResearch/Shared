using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public interface IPlayerMovementWorld
    {
        bool DashAttacking { get; }
        bool CanUnDuck { get; }
        bool UsesFeatherCollider { get; }
        float PlayerCenterY { get; }
        bool JumpThruAt(Vector2 offset);
        bool JumpThruOutsideAt(Vector2 offset);
        bool JumpThruBoostBlocked();
        bool SolidAt(Vector2 offset);
        bool DashCorrectBlocked(Vector2 offset);
        bool SwimCheck();
        global::Celeste.Simulation.Gameplay.Environment.Water.ISourceWater FirstWaterAt(Vector2 offset);
        void MoveH(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide);
        void MoveV(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide);
        bool MoveVExact(int amount);

        global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState CollisionSurface(
            PixelCollision collision);
    }
}
