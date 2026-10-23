using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector4Reader : SourceContentTypeReader<Vector4>
    {
        internal SourceVector4Reader()
        {
        }

        protected internal override Vector4 Read(SourceContentReader input, Vector4 existingInstance)
        {
            return input.ReadVector4();
        }
    }
}
