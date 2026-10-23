using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceStringReader : SourceContentTypeReader<string>
    {
        internal SourceStringReader()
        {
        }

        protected internal override string Read(SourceContentReader input, string existingInstance)
        {
            return input.ReadString();
        }
    }
}
