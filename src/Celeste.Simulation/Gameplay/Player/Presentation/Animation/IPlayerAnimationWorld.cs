using System;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Animation
{
    public interface IPlayerAnimationWorld
    {
        bool DashAttacking { get; }
        bool SolidAt(Vector2 offset);
        bool SolidPointAt(Vector2 offset);
        bool JumpThruAt(Vector2 offset);
        bool ClimbEdgeBlocked(int xOffset);
        bool OnInterval(float interval);
        void SkidDust();
    }
}
