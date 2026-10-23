using System.Numerics;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceMatrixReader : SourceContentTypeReader<Matrix4x4>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override Matrix4x4 Read(SourceContentReader input, Matrix4x4 existingInstance)
        {
            return new(input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle());
        }
    }
}
