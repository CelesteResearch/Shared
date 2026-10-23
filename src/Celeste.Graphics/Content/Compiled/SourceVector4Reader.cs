using System.Numerics;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector4Reader : SourceContentTypeReader<Vector4>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceVector4Reader()
        {
        }

        protected internal override Vector4 Read(SourceContentReader input, Vector4 existingInstance)
        {
            return input.ReadVector4();
        }
    }
}
