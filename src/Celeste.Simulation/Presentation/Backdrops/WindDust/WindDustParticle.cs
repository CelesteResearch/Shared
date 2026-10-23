using System.Numerics;

namespace Celeste.Simulation.Presentation.Backdrops.WindDust
{
    public struct WindDustParticle<TColor> where TColor : struct
    {
        public Vector2 Position;
        public Vector2 Direction;
        public float Percent;
        public float Duration;
        public float Speed;
        public float Spin;
        public TColor Color;
    }
}
