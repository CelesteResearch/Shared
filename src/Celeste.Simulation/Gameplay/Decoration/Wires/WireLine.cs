using System.Numerics;

namespace Celeste.Simulation.Gameplay.Decoration.Wires
{
    public readonly struct WireLine
    {
        public readonly Vector2 From, To;
        public readonly Vector4 Color;

        public WireLine(Vector2 from, Vector2 to, Vector4 color)
        {
            From = from;
            To = to;
            Color = color;
        }
    }
}
