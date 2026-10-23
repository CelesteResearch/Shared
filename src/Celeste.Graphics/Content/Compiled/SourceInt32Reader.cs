using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceInt32Reader : SourceContentTypeReader<int>
    {
        internal SourceInt32Reader()
        {
        }

        protected internal override int Read(SourceContentReader input, int existingInstance)
        {
            return input.ReadInt32();
        }
    }
}
