using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Props
{
    public interface IFarewellPropCollision
    {
        bool BillboardAt(global::Celeste.Core.Geometry.IntRect bounds);
    }
}
