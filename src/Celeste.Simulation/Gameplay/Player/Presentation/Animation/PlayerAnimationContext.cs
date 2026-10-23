using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Animation
{
    public struct PlayerAnimationContext
    {
        public int InputMoveX, InputMoveY;
        public bool InSpace;
        public Vector2 WindDirection;
        public float WindTimeout;
    }
}
