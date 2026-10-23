using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Runtime.Services
{
    // One scene-owned identity list shared by map modules and detached entities.
    // The same typed list remains stable across room transitions and runtime rebinds.
    public sealed class RoomSceneRoster
    {
        private readonly Dictionary<Type, object> lists = new Dictionary<Type, object>();

        public void Use<T>(List<T> list) where T : class
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (lists.TryGetValue(typeof(T), out var existing) && !ReferenceEquals(existing, list))
                throw new InvalidOperationException("A different scene roster is already registered for " +
                                                    typeof(T).FullName);
            lists[typeof(T)] = list;
        }

        public List<T> List<T>() where T : class
        {
            if (!lists.TryGetValue(typeof(T), out var value))
            {
                value = new List<T>();
                lists.Add(typeof(T), value);
            }

            return (List<T>)value;
        }
    }
}
