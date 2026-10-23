using System.Numerics;
using Celeste.Core.Geometry.Intersections;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBoundingSphereReader : SourceContentTypeReader<BoundingSphere>
    {
        internal SourceBoundingSphereReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override BoundingSphere Read(SourceContentReader input, BoundingSphere existingInstance)
        {
            Vector3 center = input.ReadVector3();
            float radius = input.ReadSingle();
            return new BoundingSphere(center, radius);
        }
    }
}
