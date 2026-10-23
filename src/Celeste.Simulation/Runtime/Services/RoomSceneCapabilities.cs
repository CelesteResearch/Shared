using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Runtime.Services
{
    // Scene-scoped ports are looked up by contract. Entity modules never request
    // a host constructor callback for a particular map source.
    public sealed class RoomSceneCapabilities
    {
        private readonly Dictionary<Type, object> values = new();

        public void Provide<T>(T value) where T : class
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (values.TryGetValue(typeof(T), out var existing) && !ReferenceEquals(existing, value))
                throw new InvalidOperationException("A different scene capability is already registered for " +
                                                    typeof(T).FullName);
            values[typeof(T)] = value;
        }

        public bool TryGet<T>(out T value) where T : class
        {
            if (values.TryGetValue(typeof(T), out var found))
            {
                value = (T)found;
                return true;
            }

            value = null;
            return false;
        }

        public T Require<T>() where T : class
        {
            return values.TryGetValue(typeof(T), out var value)
                ? (T)value
                : throw new InvalidOperationException("Missing scene capability: " + typeof(T).FullName);
        }
    }
}
