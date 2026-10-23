using System.Numerics;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector2Reader : SourceContentTypeReader<Vector2>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceVector2Reader()
        {
        }

        protected internal override Vector2 Read(SourceContentReader input, Vector2 existingInstance)
        {
            return input.ReadVector2();
        }
    }
}
