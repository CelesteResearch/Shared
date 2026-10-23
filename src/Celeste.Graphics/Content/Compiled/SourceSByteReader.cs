using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSByteReader : SourceContentTypeReader<sbyte>
    {
        internal SourceSByteReader()
        {
        }

        protected internal override sbyte Read(SourceContentReader input, sbyte existingInstance)
        {
            return input.ReadSByte();
        }
    }
}
