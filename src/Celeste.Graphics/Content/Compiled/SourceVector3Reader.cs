using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector3Reader : SourceContentTypeReader<Vector3>
    {
        internal SourceVector3Reader()
        {
        }

        protected internal override Vector3 Read(SourceContentReader input, Vector3 existingInstance)
        {
            return input.ReadVector3();
        }
    }
}
