using System;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public interface ISwimWorld
    {
        bool CanUnDuck { get; }
        bool SwimCheck();
        bool SwimUnderwaterCheck();
        bool SwimJumpCheck();
        bool SwimRiseCheck();
        bool ClimbCheck(int direction);
        bool SolidAt(Vector2 offset);
        bool MoveVExact(int amount);
        void ClimbHop();
        void Jump();
    }
}
