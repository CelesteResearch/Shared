using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceDecimalReader : SourceContentTypeReader<decimal>
    {
        internal SourceDecimalReader()
        {
        }

        protected internal override decimal Read(SourceContentReader input, decimal existingInstance)
        {
            return input.ReadDecimal();
        }
    }
}
