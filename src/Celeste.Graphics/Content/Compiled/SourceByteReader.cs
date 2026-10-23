using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceByteReader : SourceContentTypeReader<byte>
    {
        internal SourceByteReader()
        {
        }

        protected internal override byte Read(SourceContentReader input, byte existingInstance)
        {
            return input.ReadByte();
        }
    }
}
