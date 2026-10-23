using System.Runtime.CompilerServices;
using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceRayReader : SourceContentTypeReader<Ray>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceRayReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override Ray Read(SourceContentReader input, Ray existingInstance)
        {
            var position = input.ReadVector3();
            var direction = input.ReadVector3();
            return new(position, direction);
        }
    }
}
