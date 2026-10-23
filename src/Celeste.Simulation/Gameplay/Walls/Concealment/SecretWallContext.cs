using System;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public sealed class SecretWallContext
    {
        public Action<string, Vector2> PlaySound;
        public Func<char, int> TileToSurfaceSoundIndex;
    }
}
