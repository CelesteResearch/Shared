using System;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

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
        global::Celeste.Simulation.Gameplay.Platforms.Movement.IMovingSolid FirstSolidAt(Vector2 offset);
        void NudgePosition(Vector2 amount);
        void Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump kind, int direction);
        void WallSlideParticles(int direction);
        bool OnInterval(float interval);
        bool ConveyorLoopActive { get; }
        string SweatAnimation { get; }
        void PlaySweat(string animation);
        void Emit(global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect effect);
    }
}
