using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    // Offsets are relative to the player's current position, in original game pixels.
    public interface INormalWorld
    {
        Vector2 LiftSpeed { get; }
        float WindY { get; }
        bool Cold { get; }
        bool InSpace { get; }
        bool HoldingSlowRun { get; }
        bool HoldingSlowFall { get; }
        bool DashAttacking { get; }
        bool CanUnDuck { get; }
        bool PlayerOverTalk { get; }
        bool CanUnDuckAt(Vector2 offset);
        bool SolidAt(Vector2 offset);
        bool ClimbBoundsCheck(int direction);
        bool ClimbCheck(int direction, int yOffset = 0);
        bool ClimbEdgeBlocked(int xOffset);
        bool ClimbBlocked(int xOffset);
        bool WallJumpCheck(int direction);
        bool TryPickup();
        void Throw();
        void Drop();
        void MoveH(float amount);
        void MoveVExact(int amount);
        void WallSlideParticles(int direction);

        void Jump(PlayerJump kind, int direction);

        // Capture the water at offset (0, 2), perform a standard jump, then ripple that surface.
        bool JumpFromWater();
    }
}
