using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Collision
{
    [Flags]
    public enum CollisionProbeBits : ushort
    {
        SolidHere = 1 << 0,
        SolidLeft = 1 << 1,
        SolidRight = 1 << 2,
        SolidAbove = 1 << 3,
        SolidBelow = 1 << 4,
        JumpThruBelow = 1 << 5,
        IgnoreJumpThrus = 1 << 6,
        PlayerDead = 1 << 7,
        PlayerActive = 1 << 8
    }
}
