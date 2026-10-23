using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
    using Celeste.Audio.Framework;
    using Celeste.Audio.Interop;

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
