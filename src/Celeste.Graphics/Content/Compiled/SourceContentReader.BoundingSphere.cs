using Celeste.Core.Geometry.Intersections;
using System.Numerics;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        internal BoundingSphere ReadBoundingSphere()
        {
            Vector3 center = ReadVector3();
            float radius = ReadSingle();
            return new BoundingSphere(center, radius);
        }
    }
}
