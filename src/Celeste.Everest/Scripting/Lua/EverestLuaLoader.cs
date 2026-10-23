using System;
using System.Collections.Generic;
using System.Reflection;
using KeraLua;
using NLua;

namespace Celeste.Everest.Scripting.Lua
{
    // Namespaces and member tables used by Everest 6580's Lua boot script.
    // Bound to one VM: cached LuaTable values must die with that VM.
    public sealed class EverestLuaLoader
    {
        private readonly NLua.Lua context;
        public CachedNamespace Global { get; }
        public Dictionary<string, CachedNamespace> AllNamespaces { get; } = new();
        public Dictionary<string, CachedType> AllTypes { get; } = new();

        public EverestLuaLoader(NLua.Lua context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            Global = new(null, null);
            AllNamespaces[""] = Global;
            foreach (var assembly in EverestLuaTypes.LoadedAssemblies())
                Precache(assembly);
            foreach (var alias in EverestLuaTypes.AliasPaths())
                RegisterAlias(alias.Key, alias.Value);
        }

        public void RegisterAlias(string fullName, Type type)
        {
            var lastDot = fullName.LastIndexOf('.');
            var name = lastDot < 0 ? fullName : fullName.Substring(lastDot + 1);
            var ns = lastDot < 0 ? "" : fullName.Substring(0, lastDot);
            var parent = Global;
            var from = 0;
            while (from < ns.Length)
            {
                var dot = ns.IndexOf('.', from);
                var part = dot < 0 ? ns.Substring(from) : ns.Substring(from, dot - from);
                if (!parent.NamespaceMap.TryGetValue(part, out var next))
                {
                    next = new(parent, part);
                    parent.NamespaceMap.Add(part, next);
                    AllNamespaces[next.FullName] = next;
                }

                parent = next;
                if (dot < 0) break;
                from = dot + 1;
            }

            parent.TypeMap[name] = new(this, parent, type, name);
        }

        public void Precache(Assembly assembly)
        {
            if (assembly == null) return;
            Type[] declared;
            try
            {
                declared = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException error)
            {
                declared = error.Types;
            }
            catch
            {
                return;
            }

            foreach (var type in declared)
                if (type != null && type.FullName != null)
                    PrecacheType(type);
        }

        private CachedType PrecacheType(Type type)
        {
            if (type.IsNested)
            {
                if (!type.IsNestedPublic) return null;
                if (AllTypes.TryGetValue(type.FullName, out var existingNested)) return existingNested;
                var parent = AllTypes.TryGetValue(type.DeclaringType.FullName, out var cachedParent)
                    ? cachedParent
                    : PrecacheType(type.DeclaringType);
                if (parent == null) return null;
                var nested = new CachedType(this, parent, type);
                parent.NestedTypeMap[type.Name] = nested;
                AllTypes[nested.FullName] = nested;
                return nested;
            }

            var ns = type.Namespace ?? "";
            if (!AllNamespaces.TryGetValue(ns, out var cached))
            {
                cached = Global;
                var from = 0;
                while (from < ns.Length)
                {
                    var dot = ns.IndexOf('.', from);
                    var part = dot < 0 ? ns.Substring(from) : ns.Substring(from, dot - from);
                    if (!cached.NamespaceMap.TryGetValue(part, out var next))
                    {
                        next = new(cached, part);
                        cached.NamespaceMap.Add(part, next);
                        AllNamespaces[next.FullName] = next;
                    }

                    cached = next;
                    if (dot < 0) break;
                    from = dot + 1;
                }
            }

            if (AllTypes.TryGetValue(type.FullName, out var existing)) return existing;
            var entry = new CachedType(this, cached, type);
            cached.TypeMap[type.Name] = entry;
            AllTypes[entry.FullName] = entry;
            return entry;
        }

        public sealed class CachedNamespace
        {
            public readonly string Name;
            public readonly CachedNamespace Parent;
            public readonly string FullName;

            public readonly Dictionary<string, CachedNamespace>
                NamespaceMap = new();

            public readonly Dictionary<string, CachedType> TypeMap = new();
            public CachedNamespace[] Namespaces => [.. NamespaceMap.Values];
            public CachedType[] Types => [.. TypeMap.Values];
            public int Count => NamespaceMap.Count + TypeMap.Count;

            public CachedNamespace(CachedNamespace parent, string name)
            {
                Name = name;
                Parent = parent;
                FullName = parent?.Name == null ? name : parent.FullName + "." + name;
            }

            public CachedNamespace GetNamespace(string name)
            {
                return NamespaceMap.TryGetValue(name, out var value) ? value : null;
            }

            public CachedType GetType(string name)
            {
                return TypeMap.TryGetValue(name, out var value) ? value : null;
            }
        }

        public sealed class CachedType
        {
            private readonly EverestLuaLoader loader;
            public readonly string Name;
            public readonly CachedNamespace Namespace;
            public readonly CachedType Parent;
            public readonly string FullName;
            public readonly Type Type;
            public readonly Dictionary<string, CachedType> NestedTypeMap = new();
            public CachedType[] NestedTypes => [.. NestedTypeMap.Values];
            private LuaTable nilMemberTable;
            private Dictionary<string, LuaTable> membersCache;

            public CachedType(EverestLuaLoader loader, CachedNamespace ns,
                Type type)
                : this(loader, ns, type, type.Name)
            {
            }

            public CachedType(EverestLuaLoader loader, CachedNamespace ns,
                Type type, string name)
            {
                this.loader = loader;
                Namespace = ns;
                Name = name;
                Type = type;
                FullName = type.FullName;
            }

            internal CachedType(EverestLuaLoader loader, CachedType parent,
                Type type)
            {
                this.loader = loader;
                Parent = parent;
                Name = type.Name;
                Type = type;
                FullName = type.FullName;
            }

            public LuaTable GetMembers(string key)
            {
                if (membersCache == null)
                {
                    membersCache = new();
                    foreach (var info in Type.GetMembers(BindingFlags.Public | BindingFlags.Static |
                                                         BindingFlags.Instance))
                    {
                        var memberType = (info as PropertyInfo)?.PropertyType ?? (info as FieldInfo)?.FieldType;
                        InsertMember(info.Name, info, memberType);
                        var luaName = "";
                        for (var i = 0; i < info.Name.Length; i++)
                        {
                            if (char.IsLower(info.Name[i])) break;
                            luaName += char.ToLower(info.Name[i]);
                        }

                        luaName += info.Name.Substring(luaName.Length);
                        if (luaName != info.Name) InsertMember(luaName, info, memberType);
                    }
                }

                if (membersCache.TryGetValue(key, out var found)) return found;
                if (nilMemberTable == null)
                {
                    nilMemberTable = NewTable();
                    nilMemberTable[1] = nilMemberTable[2] = null;
                }

                return nilMemberTable;
            }

            private void InsertMember(string name, MemberInfo info, Type type)
            {
                if (!membersCache.TryGetValue(name, out var entry))
                {
                    entry = NewTable();
                    entry[1] = NewTable();
                    entry[2] = type;
                    membersCache.Add(name, entry);
                }

                var values = (LuaTable)entry[1];
                values[values.Keys.Count + 1] = info;
            }

            private LuaTable NewTable()
            {
                loader.context.State.NewTable();
                return new(loader.context.State.Ref(LuaRegistry.Index), loader.context);
            }
        }
    }
}
