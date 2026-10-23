using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

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
        ISourceWater FirstWaterAt(Vector2 offset);
        void MoveH(float amount, SourceCollisionHandler onCollide);
        void MoveV(float amount, SourceCollisionHandler onCollide);
        bool MoveVExact(int amount);

        SourcePlatformEntityState CollisionSurface(
            PixelCollision collision);
    }
}
