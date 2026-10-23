using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Core.Reflection.Runtime
{
    public sealed class RuntimeTypeAliasRegistry : ISourceRuntimeTypeAliasResolver
    {
        private readonly Dictionary<string, List<Entry>> aliases = new(StringComparer.Ordinal);
        private readonly Dictionary<string, List<string>> shortAliases = new(StringComparer.Ordinal);
        private readonly Dictionary<object, List<string>> owners = new(new OwnerComparer());
        private readonly Dictionary<Type, string> activeFullNames = new();
        private readonly Dictionary<Type, string> activeShortNames = new();
        private readonly HashSet<Type> ambiguousNames = new();

        public IDisposable Register(object owner, IEnumerable<Type> types)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (types == null) throw new ArgumentNullException(nameof(types));
            if (owners.ContainsKey(owner))
                throw new InvalidOperationException("The type alias owner is already registered.");
            var pending = new Dictionary<string, Type>(StringComparer.Ordinal);
            foreach (var type in types)
            {
                if (type == null || type.ContainsGenericParameters)
                    throw new ArgumentException("Type aliases require closed actual CLR types.", nameof(types));
                foreach (var attribute in type.GetCustomAttributes<RuntimeTypeAliasAttribute>(false))
                {
                    if (pending.TryGetValue(attribute.Name, out var previous) && previous != type)
                        throw new InvalidOperationException("An owner declares the same alias for different types: " +
                                                            attribute.Name);
                    pending[attribute.Name] = type;
                }
            }

            var names = new List<string>(pending.Count);
            foreach (var pair in pending)
            {
                if (!aliases.TryGetValue(pair.Key, out var entries))
                {
                    entries = new List<Entry>();
                    aliases.Add(pair.Key, entries);
                    string shortName = ShortName(pair.Key);
                    if (!shortAliases.TryGetValue(shortName, out var fullNames))
                    {
                        fullNames = new List<string>();
                        shortAliases.Add(shortName, fullNames);
                    }

                    fullNames.Add(pair.Key);
                }

                entries.Add(new Entry(owner, pair.Value));
                names.Add(pair.Key);
            }

            owners.Add(owner, names);
            RefreshActiveNames();
            return new Registration(this, owner);
        }

        public string GetActiveRuntimeTypeAlias(Type type, bool shortName = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return (shortName ? activeShortNames : activeFullNames).TryGetValue(type, out var name) ? name : null;
        }

        private void RefreshActiveNames()
        {
            activeFullNames.Clear();
            activeShortNames.Clear();
            ambiguousNames.Clear();
            foreach (var pair in aliases)
            {
                Type type = pair.Value[pair.Value.Count - 1].Type;
                if (ambiguousNames.Contains(type)) continue;
                if (activeFullNames.TryGetValue(type, out var previous) && previous != pair.Key)
                {
                    activeFullNames.Remove(type);
                    activeShortNames.Remove(type);
                    ambiguousNames.Add(type);
                    continue;
                }

                activeFullNames[type] = pair.Key;
                activeShortNames[type] = ShortName(pair.Key);
            }
        }

        public Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (!ignoreCase)
                return aliases.TryGetValue(name, out var entries) ? entries[entries.Count - 1].Type : null;
            foreach (var pair in aliases)
                if (string.Equals(pair.Key, name, StringComparison.OrdinalIgnoreCase))
                    return pair.Value[pair.Value.Count - 1].Type;
            return null;
        }

        public bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false, bool ignoreCase = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (name == null) return false;
            if (ResolveRuntimeTypeAlias(name, ignoreCase) == type) return true;
            if (!allowShortName) return false;
            if (!ignoreCase)
                return shortAliases.TryGetValue(name, out var fullNames) && AnyAliasMatches(type, fullNames);
            foreach (var pair in shortAliases)
                if (string.Equals(pair.Key, name, StringComparison.OrdinalIgnoreCase) &&
                    AnyAliasMatches(type, pair.Value))
                    return true;
            return false;
        }

        private bool AnyAliasMatches(Type type, List<string> fullNames)
        {
            foreach (var fullName in fullNames)
            {
                var entries = aliases[fullName];
                if (entries[entries.Count - 1].Type == type) return true;
            }

            return false;
        }

        private static string ShortName(string name) =>
            name.Substring(Math.Max(name.LastIndexOf('.'), name.LastIndexOf('+')) + 1);

        private void Unregister(object owner)
        {
            if (!owners.TryGetValue(owner, out var names)) return;
            foreach (var name in names)
            {
                var entries = aliases[name];
                entries.RemoveAll(entry => ReferenceEquals(entry.Owner, owner));
                if (entries.Count == 0)
                {
                    aliases.Remove(name);
                    string shortName = ShortName(name);
                    var fullNames = shortAliases[shortName];
                    fullNames.Remove(name);
                    if (fullNames.Count == 0) shortAliases.Remove(shortName);
                }
            }

            owners.Remove(owner);
            RefreshActiveNames();
        }

        private sealed class Entry
        {
            public object Owner { get; }
            public Type Type { get; }

            public Entry(object owner, Type type)
            {
                Owner = owner;
                Type = type;
            }
        }

        private sealed class Registration : IDisposable
        {
            private RuntimeTypeAliasRegistry registry;
            private object owner;

            public Registration(RuntimeTypeAliasRegistry registry, object owner)
            {
                this.registry = registry;
                this.owner = owner;
            }

            public void Dispose()
            {
                registry?.Unregister(owner);
                registry = null;
                owner = null;
            }
        }

        private sealed class OwnerComparer : IEqualityComparer<object>
        {
            public new bool Equals(object left, object right) => ReferenceEquals(left, right);
            public int GetHashCode(object value) => RuntimeHelpers.GetHashCode(value);
        }
    }
}
