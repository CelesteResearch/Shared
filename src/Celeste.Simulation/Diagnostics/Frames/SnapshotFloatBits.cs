using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Frames
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct SnapshotFloatBits
    {
        [FieldOffset(0)] public float Float;
        [FieldOffset(0)] public int Bits;

        public static int Of(float value)
        {
            var raw = new global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits { Float = value };
            return raw.Bits;
        }
    }
}
