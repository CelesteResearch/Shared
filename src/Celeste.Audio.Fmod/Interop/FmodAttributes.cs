using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FmodAttributes
    {
        public FmodVector Position, Velocity, Forward, Up;

        public static FmodAttributes At(float x, float y, float z = 0)
        {
            return new()
            {
                Position = new(x, y, z),
                Forward = new(0, 0, 1),
                Up = new(0, 1, 0),
            };
        }
    }
}
