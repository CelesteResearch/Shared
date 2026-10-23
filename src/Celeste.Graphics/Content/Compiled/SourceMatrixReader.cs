using System.Numerics;
using Celeste.Core.Geometry;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceMatrixReader : SourceContentTypeReader<Matrix4x4>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override Matrix4x4 Read(SourceContentReader input, Matrix4x4 existingInstance)
        {
            return new Matrix4x4(input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle(),
                input.ReadSingle(), input.ReadSingle());
        }
    }
}
