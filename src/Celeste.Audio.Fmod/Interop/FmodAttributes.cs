using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FmodAttributes
    {
        public global::Celeste.Audio.Fmod.Interop.FmodVector Position, Velocity, Forward, Up;

        public static global::Celeste.Audio.Fmod.Interop.FmodAttributes At(float x, float y, float z = 0) =>
            new global::Celeste.Audio.Fmod.Interop.FmodAttributes
            {
                Position = new global::Celeste.Audio.Fmod.Interop.FmodVector(x, y, z),
                Forward = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 0, 1),
                Up = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 1, 0)
            };
    }
}
