using System.Runtime.InteropServices;

namespace Celeste.Simulation.Diagnostics.Frames
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct SnapshotFloatBits
    {
        [FieldOffset(0)] public float Float;
        [FieldOffset(0)] public int Bits;

        public static int Of(float value)
        {
            var raw = new SnapshotFloatBits { Float = value };
            return raw.Bits;
        }
    }
}
