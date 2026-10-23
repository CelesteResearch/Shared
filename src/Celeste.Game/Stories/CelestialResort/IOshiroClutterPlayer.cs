using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Game.Stories.CelestialResort
{
    public interface IOshiroClutterPlayer : INpcPlayer
    {
        bool Dead { get; }
        Vector2 Center { get; }
    }
}
