using System.Numerics;
using Celeste.Core.Geometry;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceRectangleReader : SourceContentTypeReader<IntRect>
    {
        internal SourceRectangleReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override IntRect Read(SourceContentReader input, IntRect existingInstance)
        {
            int x = input.ReadInt32();
            int y = input.ReadInt32();
            int width = input.ReadInt32();
            int height = input.ReadInt32();
            return new IntRect(x, y, width, height);
        }
    }
}
