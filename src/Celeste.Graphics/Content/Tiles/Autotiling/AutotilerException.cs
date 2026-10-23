using System;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public class AutotilerException : Exception
    {
        public char ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public AutotilerException()
        {
        }

        public AutotilerException(string message) : base(message)
        {
        }

        public AutotilerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
