using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceNullableReader<T> : SourceContentTypeReader<T?> where T : struct
    {
        // ReSharper disable once EmptyConstructor
        internal SourceNullableReader()
        {
        }

        private SourceContentTypeReader elementReader;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void Initialize(SourceContentTypeReaderManager manager)
        {
            var typeFromHandle = typeof(T);
            elementReader = manager.GetTypeReader(typeFromHandle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override T? Read(SourceContentReader input, T? existingInstance)
        {
            if (input.ReadBoolean()) return input.ReadObject<T>(elementReader);

            return null;
        }
    }
}
