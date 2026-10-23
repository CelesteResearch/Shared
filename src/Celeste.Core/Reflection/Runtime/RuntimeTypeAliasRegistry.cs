using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Core.Reflection.Runtime
{
    public sealed class RuntimeTypeAliasRegistry : ISourceRuntimeTypeAliasResolver
    {
        private readonly Dictionary<string, List<Entry>> _aliases = new(StringComparer.Ordinal);
        private readonly Dictionary<string, List<string>> _shortAliases = new(StringComparer.Ordinal);
        private readonly Dictionary<object, List<string>> _owners = new(new OwnerComparer());
        private readonly Dictionary<Type, string> _activeFullNames = new();
        private readonly Dictionary<Type, string> _activeShortNames = new();
        private readonly HashSet<Type> _ambiguousNames = [];

        public IDisposable Register(object owner, IEnumerable<Type> types)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            if (types == null)
                throw new ArgumentNullException(nameof(types));
            if (_owners.ContainsKey(owner))
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
                if (!_aliases.TryGetValue(pair.Key, out var entries))
                {
                    entries = [];
                    _aliases.Add(pair.Key, entries);
                    var shortName = ShortName(pair.Key);
                    if (!_shortAliases.TryGetValue(shortName, out var fullNames))
                    {
                        fullNames = [];
                        _shortAliases.Add(shortName, fullNames);
                    }

                    fullNames.Add(pair.Key);
                }

                entries.Add(new(owner, pair.Value));
                names.Add(pair.Key);
            }

            _owners.Add(owner, names);
            RefreshActiveNames();
            return new Registration(this, owner);
        }

        public string GetActiveRuntimeTypeAlias(Type type, bool shortName = false)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (shortName ? _activeShortNames : _activeFullNames).TryGetValue(type, out var name) ? name : null;
        }

        private void RefreshActiveNames()
        {
            _activeFullNames.Clear();
            _activeShortNames.Clear();
            _ambiguousNames.Clear();
            foreach (var pair in _aliases)
            {
                var type = pair.Value[pair.Value.Count - 1].Type;
                if (_ambiguousNames.Contains(type))
                    continue;
                if (_activeFullNames.TryGetValue(type, out var previous) && previous != pair.Key)
                {
                    _activeFullNames.Remove(type);
                    _activeShortNames.Remove(type);
                    _ambiguousNames.Add(type);
                    continue;
                }

                _activeFullNames[type] = pair.Key;
                _activeShortNames[type] = ShortName(pair.Key);
            }
        }

        public Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!ignoreCase)
                return _aliases.TryGetValue(name, out var entries) ? entries[entries.Count - 1].Type : null;
            foreach (var pair in _aliases)
                if (string.Equals(pair.Key, name, StringComparison.OrdinalIgnoreCase))
                    return pair.Value[pair.Value.Count - 1].Type;
            return null;
        }

        public bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false, bool ignoreCase = false)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (name == null)
                return false;
            if (ResolveRuntimeTypeAlias(name, ignoreCase) == type)
                return true;
            if (!allowShortName)
                return false;
            if (!ignoreCase)
                return _shortAliases.TryGetValue(name, out var fullNames) && AnyAliasMatches(type, fullNames);
            foreach (var pair in _shortAliases)
                if (string.Equals(pair.Key, name, StringComparison.OrdinalIgnoreCase) &&
                    AnyAliasMatches(type, pair.Value))
                    return true;
            return false;
        }

        private bool AnyAliasMatches(Type type, List<string> fullNames)
        {
            foreach (var fullName in fullNames)
            {
                var entries = _aliases[fullName];
                if (entries[entries.Count - 1].Type == type)
                    return true;
            }

            return false;
        }

        private static string ShortName(string name)
        {
            return name.Substring(Math.Max(name.LastIndexOf('.'), name.LastIndexOf('+')) + 1);
        }

        private void Unregister(object owner)
        {
            if (!_owners.TryGetValue(owner, out var names))
                return;
            foreach (var name in names)
            {
                var entries = _aliases[name];
                entries.RemoveAll(entry => ReferenceEquals(entry.Owner, owner));
                if (entries.Count == 0)
                {
                    _aliases.Remove(name);
                    var shortName = ShortName(name);
                    var fullNames = _shortAliases[shortName];
                    fullNames.Remove(name);
                    if (fullNames.Count == 0)
                        _shortAliases.Remove(shortName);
                }
            }

            _owners.Remove(owner);
            RefreshActiveNames();
        }

        private sealed class Entry(object owner, Type type)
        {
            public object Owner { get; } = owner;
            public Type Type { get; } = type;
        }

        private sealed class Registration(RuntimeTypeAliasRegistry registry, object owner) : IDisposable
        {
            private RuntimeTypeAliasRegistry _registry = registry;
            private object _owner = owner;

            public void Dispose()
            {
                _registry?.Unregister(_owner);
                _registry = null;
                _owner = null;
            }
        }

        private sealed class OwnerComparer : IEqualityComparer<object>
        {
            public new bool Equals(object left, object right)
            {
                return ReferenceEquals(left, right);
            }

            public int GetHashCode(object value)
            {
                return RuntimeHelpers.GetHashCode(value);
            }
        }
    }
}
