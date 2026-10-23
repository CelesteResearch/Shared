using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Tiles.Entities
{
    public enum TileEntityKind
    {
        FakeWall,
        FakeBlock,
        ExitBlock,
        FallingBlock,
        DashBlock
    }
}
