using System;

namespace Celeste.Audio.Fmod.Interop
{
    public sealed class FmodException : Exception
    {
        public FmodResult Result { get; }

        public FmodException(FmodResult result, string operation) : base(operation +
                                                                         ": " +
                                                                         result + " (" +
                                                                         (int)result + ")")
        {
            Result = result;
        }
    }
}
