using System.Numerics;
using Celeste.Core.Geometry;
using System;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceArrayReader<T> : SourceContentTypeReader<T[]>
    {
        private SourceContentTypeReader elementReader;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void Initialize(SourceContentTypeReaderManager manager)
        {
            Type typeFromHandle = typeof(T);
            elementReader = manager.GetTypeReader(typeFromHandle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override T[] Read(SourceContentReader input, T[] existingInstance)
        {
            uint num = input.ReadUInt32();
            T[] array = existingInstance;
            if (array == null)
            {
                array = new T[num];
            }

            if (typeof(T).IsValueType)
            {
                for (uint num2 = 0u; num2 < num; num2++)
                {
                    array[num2] = input.ReadObject<T>(elementReader);
                }
            }
            else
            {
                for (uint num3 = 0u; num3 < num; num3++)
                {
                    int num4 = input.Read7BitEncodedInt();
                    if (num4 > 0)
                    {
                        array[num3] = input.ReadObject<T>(input.TypeReaders[num4 - 1]);
                    }
                    else
                    {
                        array[num3] = default(T);
                    }
                }
            }

            return array;
        }
    }
}
