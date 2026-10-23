using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector2Reader : SourceContentTypeReader<Vector2>
    {
        internal SourceVector2Reader()
        {
        }

        protected internal override Vector2 Read(SourceContentReader input, Vector2 existingInstance)
        {
            return input.ReadVector2();
        }
    }
}
