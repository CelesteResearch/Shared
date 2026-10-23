using System.Numerics;
using Celeste.Core.Geometry;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceListReader<T> : SourceContentTypeReader<List<T>>
    {
        private SourceContentTypeReader elementReader;

        public override bool CanDeserializeIntoExistingObject => true;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void Initialize(SourceContentTypeReaderManager manager)
        {
            Type typeFromHandle = typeof(T);
            elementReader = manager.GetTypeReader(typeFromHandle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override List<T> Read(SourceContentReader input, List<T> existingInstance)
        {
            int num = input.ReadInt32();
            List<T> list = existingInstance;
            if (list == null)
            {
                list = new List<T>(num);
            }

            for (int i = 0; i < num; i++)
            {
                if (typeof(T).IsValueType)
                {
                    list.Add(input.ReadObject<T>(elementReader));
                    continue;
                }

                int num2 = input.Read7BitEncodedInt();
                list.Add((num2 > 0) ? input.ReadObject<T>(input.TypeReaders[num2 - 1]) : default(T));
            }

            return list;
        }
    }
}
