using Celeste.Simulation.Gameplay.Player.Movement;

namespace Celeste.Simulation.Gameplay.Player.Collision
{
    public interface IHitSquashWorld
    {
        bool WallJumpCheck(int direction);
        bool ClimbBlocked(int xOffset);
        bool ClimbCheck(int direction);
        void Jump(PlayerJump kind, int direction);
    }
}
