using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
    [Serializable]
    public sealed class SourceInstancePlayLimitException : ExternalException
    {
        public SourceInstancePlayLimitException()
        {
        }

        public SourceInstancePlayLimitException(string message)
            : base(message)
        {
        }

        public SourceInstancePlayLimitException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
