using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Walls.Breakable
{
    public readonly struct DashBlockTileRequest
    {
        public readonly char TileType;
        public readonly bool Overlay;
        public readonly int X, Y, Columns, Rows;

        public DashBlockTileRequest(char tileType, bool overlay, int x, int y, int columns, int rows)
        {
            TileType = tileType;
            Overlay = overlay;
            X = x;
            Y = y;
            Columns = columns;
            Rows = rows;
        }
    }
}
