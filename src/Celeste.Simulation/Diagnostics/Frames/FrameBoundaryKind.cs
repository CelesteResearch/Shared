using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Simulation.Diagnostics.Frames
{
    public enum FrameBoundaryKind : byte
    {
        SceneHandoffWithoutRoomTick = 1,
        SceneExitAfterRoomTick = 2
    }
}
