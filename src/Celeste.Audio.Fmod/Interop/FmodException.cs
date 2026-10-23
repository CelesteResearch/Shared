using System;

namespace Celeste.Audio.Fmod.Interop
{
    public sealed class FmodException : Exception
    {
        public global::Celeste.Audio.Fmod.Interop.FmodResult Result { get; }

        public FmodException(global::Celeste.Audio.Fmod.Interop.FmodResult result, string operation) : base(operation +
            ": " +
            result + " (" +
            (int)result + ")")
        {
            Result = result;
        }
    }
}
