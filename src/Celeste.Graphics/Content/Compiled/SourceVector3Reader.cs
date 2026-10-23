using System.Numerics;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVector3Reader : SourceContentTypeReader<Vector3>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceVector3Reader()
        {
        }

        protected internal override Vector3 Read(SourceContentReader input, Vector3 existingInstance)
        {
            return input.ReadVector3();
        }
    }
}
