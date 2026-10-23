using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
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
