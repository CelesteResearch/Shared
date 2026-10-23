using System.Numerics;
using Celeste.Core.Geometry.Intersections;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceRayReader : SourceContentTypeReader<Ray>
    {
        internal SourceRayReader()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override Ray Read(SourceContentReader input, Ray existingInstance)
        {
            Vector3 position = input.ReadVector3();
            Vector3 direction = input.ReadVector3();
            return new Ray(position, direction);
        }
    }
}
