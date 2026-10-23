using System.Numerics;
using Celeste.Simulation.Gameplay.Platforms.Movement;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public interface IClimbWorld
    {
        bool CanUnDuck { get; }
        Vector2 LiftSpeed { get; set; }
        bool SolidAt(Vector2 offset);
        bool ClimbBlocked(int xOffset);
        bool WallBoosterCheck();
        bool SlipCheck(float addY = 0f);
        bool ClimbHopBlockedCheck();
        IMovingSolid FirstSolidAt(Vector2 offset);
        void NudgePosition(Vector2 amount);
        void Jump(PlayerJump kind, int direction);
        void WallSlideParticles(int direction);
        bool OnInterval(float interval);
        bool ConveyorLoopActive { get; }
        string SweatAnimation { get; }
        void PlaySweat(string animation);
        void Emit(ClimbEffect effect);
    }
}
