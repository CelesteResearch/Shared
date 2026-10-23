using System.Runtime.CompilerServices;
using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBoundingSphereReader : SourceContentTypeReader<BoundingSphere>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceBoundingSphereReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override BoundingSphere Read(SourceContentReader input, BoundingSphere existingInstance)
        {
            var center = input.ReadVector3();
            var radius = input.ReadSingle();
            return new(center, radius);
        }
    }
}
