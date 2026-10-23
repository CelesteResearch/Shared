using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FmodVector
    {
        public float X, Y, Z;

        public FmodVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
