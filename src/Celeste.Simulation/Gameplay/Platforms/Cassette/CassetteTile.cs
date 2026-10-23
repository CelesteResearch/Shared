using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public readonly struct CassetteTile
    {
        public readonly Vector2 Position;
        public readonly int X, Y;

        public CassetteTile(Vector2 position, int x, int y)
        {
            Position = position;
            X = x;
            Y = y;
        }
    }
}
