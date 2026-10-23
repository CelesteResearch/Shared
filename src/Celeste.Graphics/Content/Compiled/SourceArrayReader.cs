using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceArrayReader<T> : SourceContentTypeReader<T[]>
    {
        private SourceContentTypeReader elementReader;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void Initialize(SourceContentTypeReaderManager manager)
        {
            var typeFromHandle = typeof(T);
            elementReader = manager.GetTypeReader(typeFromHandle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override T[] Read(SourceContentReader input, T[] existingInstance)
        {
            var num = input.ReadUInt32();
            var array = existingInstance;
            if (array == null) array = new T[num];

            if (typeof(T).IsValueType)
                for (var num2 = 0u; num2 < num; num2++)
                    array[num2] = input.ReadObject<T>(elementReader);
            else
                for (var num3 = 0u; num3 < num; num3++)
                {
                    var num4 = input.Read7BitEncodedInt();
                    if (num4 > 0)
                        array[num3] = input.ReadObject<T>(input.TypeReaders[num4 - 1]);
                    else
                        array[num3] = default;
                }

            return array;
        }
    }
}
