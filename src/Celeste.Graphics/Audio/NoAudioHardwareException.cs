using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Audio
{
    [Serializable]
    public sealed class NoAudioHardwareException : ExternalException
    {
        public NoAudioHardwareException()
        {
        }

        public NoAudioHardwareException(string message) : base(message)
        {
        }

        public NoAudioHardwareException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
