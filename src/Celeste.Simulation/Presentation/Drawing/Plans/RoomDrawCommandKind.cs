using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    public enum RoomDrawCommandKind
    {
        Image,
        ColoredGeometry,
        EndGameplayBatch,
        ImmediateGeometry,
        BeginGameplayBatch,
        TexturedVertices,
        DeferredTexturedVertices
    }
}
