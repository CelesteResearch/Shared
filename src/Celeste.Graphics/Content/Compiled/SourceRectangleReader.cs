using System.Runtime.CompilerServices;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceRectangleReader : SourceContentTypeReader<IntRect>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceRectangleReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override IntRect Read(SourceContentReader input, IntRect existingInstance)
        {
            var x = input.ReadInt32();
            var y = input.ReadInt32();
            var width = input.ReadInt32();
            var height = input.ReadInt32();
            return new(x, y, width, height);
        }
    }
}
