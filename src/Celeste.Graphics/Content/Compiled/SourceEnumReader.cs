using System.Numerics;
using Celeste.Core.Geometry;
using System;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceEnumReader<T> : SourceContentTypeReader<T>
    {
        private SourceContentTypeReader elementReader;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void Initialize(SourceContentTypeReaderManager manager)
        {
            Type underlyingType = Enum.GetUnderlyingType(typeof(T));
            elementReader = manager.GetTypeReader(underlyingType);
        }

        protected internal override T Read(SourceContentReader input, T existingInstance)
        {
            return input.ReadRawObject<T>(elementReader);
        }
    }
}
