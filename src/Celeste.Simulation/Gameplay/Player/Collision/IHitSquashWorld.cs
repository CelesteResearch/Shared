using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision
{
    public interface IHitSquashWorld
    {
        bool WallJumpCheck(int direction);
        bool ClimbBlocked(int xOffset);
        bool ClimbCheck(int direction);
        void Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump kind, int direction);
    }
}
