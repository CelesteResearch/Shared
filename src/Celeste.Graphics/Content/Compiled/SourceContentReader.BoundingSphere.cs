using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        internal BoundingSphere ReadBoundingSphere()
        {
            var center = ReadVector3();
            var radius = ReadSingle();
            return new(center, radius);
        }
    }
}
