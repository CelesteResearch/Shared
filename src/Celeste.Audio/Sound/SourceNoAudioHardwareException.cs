using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
    using Celeste.Audio.Framework;
    using Celeste.Audio.Interop;

    [Serializable]
    public sealed class SourceNoAudioHardwareException : ExternalException
    {
        public SourceNoAudioHardwareException()
        {
        }

        public SourceNoAudioHardwareException(string message)
            : base(message)
        {
        }

        public SourceNoAudioHardwareException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
