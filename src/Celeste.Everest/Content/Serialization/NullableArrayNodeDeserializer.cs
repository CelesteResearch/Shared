using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.Utilities;

namespace Celeste.Everest.Content.Serialization
{
    internal sealed class NullableArrayNodeDeserializer : INodeDeserializer
    {
        private readonly INodeDeserializer original;
        private readonly ITypeInspector typeInspector;

        public NullableArrayNodeDeserializer(INodeDeserializer original, ITypeInspector typeInspector)
        {
            this.original = original;
            this.typeInspector = typeInspector;
        }

        public bool Deserialize(IParser parser, Type expectedType,
            Func<IParser, Type, object> nestedObjectDeserializer, out object value,
            ObjectDeserializer rootDeserializer)
        {
            var itemType = expectedType.IsArray ? expectedType.GetElementType() : null;
            if (itemType == null || Nullable.GetUnderlyingType(itemType) == null)
                return original.Deserialize(parser, expectedType, nestedObjectDeserializer, out value,
                    rootDeserializer);

            var items = new List<object>();
            Array array = null;
            parser.Consume<SequenceStart>();
            while (!parser.TryConsume<SequenceEnd>(out _))
            {
                var item = nestedObjectDeserializer(parser, itemType);
                if (item is IValuePromise promise)
                {
                    int index = items.Count;
                    items.Add(Activator.CreateInstance(itemType));
                    promise.ValueAvailable += resolved =>
                    {
                        if (array == null)
                            throw new InvalidOperationException("Destination array is still null");
                        array.SetValue(TypeConverter.ChangeType(resolved, itemType, NullNamingConvention.Instance,
                            typeInspector), index);
                    };
                }
                else
                {
                    items.Add(TypeConverter.ChangeType(item, itemType, NullNamingConvention.Instance, typeInspector));
                }
            }

            array = Array.CreateInstance(itemType, items.Count);
            // Unity Mono cannot unbox object[] into Nullable<T>[] through Array.Copy.
            // SetValue keeps nullable values and the original deferred alias update semantics.
            for (int i = 0; i < items.Count; i++) array.SetValue(items[i], i);
            value = array;
            return true;
        }
    }
}
