using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceCharReader : SourceContentTypeReader<char>
    {
        internal SourceCharReader()
        {
        }

        protected internal override char Read(SourceContentReader input, char existingInstance)
        {
            return input.ReadChar();
        }
    }
}
