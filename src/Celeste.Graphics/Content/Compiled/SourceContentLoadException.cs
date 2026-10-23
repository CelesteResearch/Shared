using System;

namespace Celeste.Graphics.Content.Compiled
{
    public class SourceContentLoadException : Exception
    {
        public SourceContentLoadException()
        {
        }

        public SourceContentLoadException(string message) : base(message)
        {
        }

        public SourceContentLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
