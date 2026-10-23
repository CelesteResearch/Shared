using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Force.DeepCloner;
using Force.DeepCloner.Helpers;

namespace Celeste.Savestates
{
    // One shared reference map across the world, save data, input and random state.
    // Speedrun Tool uses the same map to preserve aliases and coroutine captures.
    public sealed class StateClone
    {
        [ThreadStatic] private static StateClone current;
        private readonly DeepCloneState references = new();
        private readonly Func<object, object> external;

        static StateClone()
        {
            DeepCloner.SetPreCloneProcessor((value, state) => current?.BeforeClone(value, state));
            DeepCloner.SetPostCloneProcessor((value, copy, state) => RepairCollections(copy));
        }

        public StateClone(Func<object, object> external = null)
        {
            this.external = external;
        }

        public void Map(object source, object destination)
        {
            if (source == null || destination == null) throw new ArgumentNullException();
            references.AddKnownRef(source, destination);
        }

        public T Clone<T>(T value)
        {
            var previous = current;
            current = this;
            try
            {
                return value.DeepClone(references);
            }
            finally
            {
                current = previous;
            }
        }

        private object BeforeClone(object value, DeepCloneState state)
        {
            object adapted = external?.Invoke(value);
            if (adapted != null) return adapted;
            if (value is WeakReference weak)
            {
                var copy = new WeakReference(null, weak.TrackResurrection);
                state.AddKnownRef(value, copy);
                copy.Target = Clone(weak.Target);
                return copy;
            }

            Type type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ConditionalWeakTable<,>))
            {
                // Rebuild actual ephemeron pairs through public netstandard2.1 APIs.
                // Native dependent handles cannot be copied as ordinary field data.
                var copy = Activator.CreateInstance(type);
                state.AddKnownRef(value, copy);
                Type pairType = typeof(KeyValuePair<,>).MakeGenericType(type.GetGenericArguments());
                PropertyInfo key = pairType.GetProperty("Key"), item = pairType.GetProperty("Value");
                MethodInfo add = type.GetMethod("Add");
                foreach (object pair in (IEnumerable)value)
                    add.Invoke(copy, new[] { Clone(key.GetValue(pair)), Clone(item.GetValue(pair)) });
                return copy;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(WeakReference<>))
            {
                object[] arguments = { null };
                type.GetMethod("TryGetTarget").Invoke(value, arguments);
                var copy = Activator.CreateInstance(type, new object[] { null });
                state.AddKnownRef(value, copy);
                type.GetMethod("SetTarget").Invoke(copy, new[] { Clone(arguments[0]) });
                return copy;
            }

            return null;
        }

        private static object RepairCollections(object copy)
        {
            // Cloned reference keys have different identity hashes. Reinsert them, as
            // Speedrun Tool's post-clone processor does, without duplicating values.
            if (copy is IDictionary dictionary && !dictionary.IsReadOnly && dictionary.Count != 0)
            {
                var entries = new DictionaryEntry[dictionary.Count];
                dictionary.CopyTo(entries, 0);
                dictionary.Clear();
                foreach (var entry in entries) dictionary.Add(entry.Key, entry.Value);
            }
            else
            {
                Type type = copy.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(HashSet<>))
                {
                    var entries = new List<object>();
                    foreach (object item in (IEnumerable)copy) entries.Add(item);
                    type.GetMethod("Clear").Invoke(copy, null);
                    MethodInfo add = type.GetMethod("Add");
                    foreach (object entry in entries) add.Invoke(copy, new[] { entry });
                }
            }

            return copy;
        }
    }
}
