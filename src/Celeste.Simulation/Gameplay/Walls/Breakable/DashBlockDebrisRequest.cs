using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Walls.Breakable
{
    public readonly struct DashBlockDebrisRequest
    {
        public readonly Vector2 Position, BlastFrom;
        public readonly char TileType;
        public readonly bool PlaySound;

        public DashBlockDebrisRequest(Vector2 position, char tileType, bool playSound, Vector2 blastFrom)
        {
            Position = position;
            TileType = tileType;
            PlaySound = playSound;
            BlastFrom = blastFrom;
        }
    }
}
