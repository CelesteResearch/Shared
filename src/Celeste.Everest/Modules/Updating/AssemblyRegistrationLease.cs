using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Everest.Modules.Updating
{
    internal sealed class AssemblyRegistrationLease : IDisposable
    {
        private readonly List<IDisposable> registrations = new();

        public void Add(IDisposable registration) => registrations.Add(registration);

        public void Add(Action unregister) => Add(new RegistrationUndo(unregister));

        public void Set<T>(IDictionary<string, T> dictionary, string key, T value) where T : class
        {
            Dictionary<string, DictionaryRegistration<T>> slots =
                DictionaryRegistrations<T>.Owners.GetOrCreateValue(dictionary);
            if (!slots.TryGetValue(key, out var previous) ||
                !dictionary.TryGetValue(key, out var current) || !ReferenceEquals(current, previous.Value))
                previous = dictionary.TryGetValue(key, out var baseline)
                    ? new DictionaryRegistration<T>(baseline, null)
                    : null;
            var registration = new DictionaryRegistration<T>(value, previous);
            slots[key] = registration;
            dictionary[key] = value;
            Add(() =>
            {
                registration.Active = false;
                registration.Value = null;
                if (!slots.TryGetValue(key, out var owner) || !ReferenceEquals(owner, registration)) return;
                slots.Remove(key);
                if (!dictionary.TryGetValue(key, out var existing) || !ReferenceEquals(existing, value)) return;
                DictionaryRegistration<T> restore = registration.Previous;
                while (restore != null && !restore.Active) restore = restore.Previous;
                if (restore == null) dictionary.Remove(key);
                else
                {
                    dictionary[key] = restore.Value;
                    slots[key] = restore;
                }
            });
        }

        private static class DictionaryRegistrations<T> where T : class
        {
            public static readonly
                ConditionalWeakTable<IDictionary<string, T>, Dictionary<string, DictionaryRegistration<T>>> Owners =
                    new();
        }

        private sealed class DictionaryRegistration<T> where T : class
        {
            public T Value;
            public readonly DictionaryRegistration<T> Previous;
            public bool Active = true;

            public DictionaryRegistration(T value, DictionaryRegistration<T> previous)
            {
                Value = value;
                Previous = previous;
            }
        }

        public void Dispose()
        {
            // Release every registration, even if an individual scene removal fails.
            List<Exception> failures = null;
            for (int i = registrations.Count - 1; i >= 0; i--)
            {
                try
                {
                    registrations[i].Dispose();
                }
                catch (Exception exception)
                {
                    (failures ??= new List<Exception>()).Add(exception);
                }
            }

            registrations.Clear();
            if (failures != null)
                throw new AggregateException("Everest assembly registration release failed.", failures);
        }
    }
}
