using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Particles
{
    public readonly struct PlayerDustEmission
    {
        public readonly Vector2 Position;
        public readonly float Angle, Range;
        public readonly int Count, SurfaceIndex;
        public readonly bool Foreground;

        public PlayerDustEmission(Vector2 position, float angle, int count, int surfaceIndex = -1, float range = 4,
            bool foreground = false)
        {
            Position = position;
            Angle = angle;
            Count = count;
            SurfaceIndex = surfaceIndex;
            Range = range;
            Foreground = foreground;
        }
    }
}
