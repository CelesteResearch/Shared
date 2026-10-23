using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Runtime;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Reflection;
using Celeste.Everest.Reflection.Runtime;
using Celeste.Everest.Scripting.Lua;
using NLua;
using LuaFunction = KeraLua.LuaFunction;

namespace Celeste.Everest.Scripting.Scopes
{
    public sealed class EverestLuaEngineScope : IDisposable
    {
        public ISourceEngineContext Engine { get; }
        public EverestLuaContext Context { get; }

        private readonly Dictionary<string, object> symbols = new(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, Type>
            types = new(StringComparer.OrdinalIgnoreCase);

        private readonly EverestLuaBridge bridge;

        private readonly HashSet<Assembly>
            precachedAssemblies = new(EverestLuaActualAssemblyRegistry.ReferenceComparer);

        private readonly LuaFunction importActualType;
        private long sourceTypeBindingsRevision;
        private long runtimeTypeDiscoveryRevision;

        public EverestLuaEngineScope(ISourceEngineContext engine)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            var content = ((IEverestContentRegistryEnvironment)engine)
                .SourceContentRegistry;
            Context = new(content);
            bridge = new(content);
            importActualType = ImportActualType;
            try
            {
                InitializeState();
            }
            catch
            {
                Context.Dispose();
                throw;
            }
        }

        private void InitializeState()
        {
            PrecacheSourceTypes();
            Context.WithState(lua =>
            {
                lua["__engine_scope"] = this;
                lua.State.PushCFunction(importActualType);
                lua.State.SetGlobal("__engine_scope_import");
                return 0;
            });
            Context.Evaluate(@"
local ordinaryRequire = require
local ordinaryImport = luanet.import_type
local namespaceViews = {}
local function scopedNamespace(actual)
    local meta = type(actual) == 'table' and getmetatable(actual)
    if not meta or meta.__name ~= 'csCachedNamespace' then return actual end
    local cached = namespaceViews[actual]
    if cached then return cached end
    if not meta.__scoped_original_index then
        meta.__scoped_original_index = meta.__index
        meta.__index = function(self, key)
            local original = rawget(self, '__scoped_original_namespace')
            if not original then return meta.__scoped_original_index(self, key) end
            local value
            if type(key) == 'string' then
                local prefix = rawget(self, '__scoped_namespace_path')
                local path = prefix == '' and key or prefix .. '.' .. key
                value = __engine_scope:Resolve('#' .. path)
                if value == nil then value = __engine_scope:Resolve(path) end
            end
            if value == nil then value = meta.__scoped_original_index(original, key) end
            value = scopedNamespace(value)
            if value ~= nil then rawset(self, key, value) end
            return value
        end
    end
    local view = { __scoped_original_namespace = actual }
    for key, node in next, actual do
        if type(key) == 'table' and key._id == 'node' then
            view[key] = node
            view.__scoped_namespace_path = node.FullName or ''
            break
        end
    end
    setmetatable(view, meta)
    namespaceViews[actual] = view
    return view
end
function __engine_scope_symbol_registered(name)
    if name:sub(1,1) == '#' then name = name:sub(2) end
    local parent, member = name:match('^(.*)%.([^.]*)$')
    if not parent then return end
    for _, view in pairs(namespaceViews) do
        if __engine_scope:SymbolNamesMatch(rawget(view, '__scoped_namespace_path'), parent) then
            for key in next, view do
                if type(key) == 'string' and __engine_scope:SymbolNamesMatch(key, member) then
                    rawset(view, key, nil)
                end
            end
        end
    end
end
luanet.import_type = function(name)
    local succeeded, actual = __engine_scope_import(name)
    if not succeeded then error(actual, 2) end
    if actual ~= nil then return actual end
    return ordinaryImport(name)
end
function require(name)
    local scoped = __engine_scope:Resolve(name)
    if scoped ~= nil then return scoped end
    if string.sub(name,1,1) == '#' then
        local succeeded, actual = __engine_scope_import(string.sub(name,2))
        if not succeeded then error(actual, 2) end
        if actual ~= nil then return actual end
    end
    if string.sub(name,1,1) == '#' then
        return scopedNamespace(__engine_scope:RequireClr(name))
    end
    return ordinaryRequire(name)
end", "engine scope require");
        }

        private void PrecacheSourceTypes()
        {
            var members = (Engine as ISourceEverestReflectionEnvironment)?.Reflection
                .SourceMembers;
            if (members != null)
                foreach (var assembly in Enumerable.Distinct(
                             Enumerable.Select(members.OriginalTypeDefinitions,
                                 definition => definition.AssemblyIdentity)))
                foreach (var type in members.GetRuntimeAssemblyTypes(assembly))
                {
                    Precache(type);
                    Context.RegisterTypeAlias(members.GetOriginalTypeFullName(type).Replace('+', '.'), type);
                }

            var discovery = (Engine as ISourceRuntimeTypeDiscoveryEnvironment)?.RuntimeTypeDiscovery;
            if (discovery != null)
                foreach (var metadata in discovery.GetTypes())
                {
                    var type = metadata.RequireActualType();
                    foreach (var alias in type
                                 .GetCustomAttributes<RuntimeTypeAliasAttribute>(false))
                    {
                        Precache(type);
                        Context.RegisterTypeAlias(alias.Name.Replace('+', '.'), type);
                    }
                }

            sourceTypeBindingsRevision = members?.ActualTypeBindingsRevision ?? 0;
            runtimeTypeDiscoveryRevision = discovery?.Revision ?? 0;
        }

        public object RequireClr(string name)
        {
            var members = (Engine as ISourceEverestReflectionEnvironment)?.Reflection
                .SourceMembers;
            var discovery = (Engine as ISourceRuntimeTypeDiscoveryEnvironment)?.RuntimeTypeDiscovery;
            if (sourceTypeBindingsRevision != (members?.ActualTypeBindingsRevision ?? 0) ||
                runtimeTypeDiscoveryRevision != (discovery?.Revision ?? 0))
                PrecacheSourceTypes();
            return Context.RequireClr(name);
        }

        public object Resolve(string name)
        {
            return symbols.TryGetValue(name, out var value) ? value : null;
        }

        public bool HasSymbol(string path)
        {
            return ResolveActualType(path) != null || bridge.SymbolKind(path) != 0;
        }

        public string ResolveTypeName(string path)
        {
            return ResolveActualType(path)?.FullName;
        }

        private Type ResolveActualType(string path)
        {
            return types.TryGetValue(path, out var type)
                ? type
                : (Engine as ISourceRuntimeTypeDiscoveryEnvironment)?.RuntimeTypeDiscovery
                .ResolveRuntimeTypeAlias(path);
        }

        private void Precache(Type type)
        {
            if (precachedAssemblies.Contains(type.Assembly)) return;
            Context.Precache(type.Assembly);
            precachedAssemblies.Add(type.Assembly);
        }

        private int ImportActualType(IntPtr state)
        {
            var lua = KeraLua.Lua.FromIntPtr(state);
            try
            {
                var type = ResolveActualType(lua.ToString(1, false));
                if (type == null)
                {
                    lua.PushBoolean(true);
                    lua.PushNil();
                }
                else
                {
                    Precache(type);
                    Context.WithState(context =>
                    {
                        lua.PushBoolean(true);
                        EverestLuaActualAssemblyRegistry.PushType(context, lua, type);
                        return 0;
                    });
                }

                return 2;
            }
            catch (Exception error)
            {
                lua.SetTop(1);
                lua.PushBoolean(false);
                lua.PushString(error.Message);
                return 2;
            }
        }

        public void RegisterType(string path, Type actualType)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("A Lua type path is required.", nameof(path));
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (types.ContainsKey(path))
                throw new ArgumentException("The Lua type path is already registered.", nameof(path));
            Precache(actualType);
            types.Add(path, actualType);
        }

        public bool SymbolNamesMatch(string first, string second)
        {
            return string.Equals(first, second, StringComparison.OrdinalIgnoreCase);
        }

        public void Register(string name, object value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A Lua symbol path is required.", nameof(name));
            symbols.Add(name, value ?? throw new ArgumentNullException(nameof(value)));
            Context.WithState(lua =>
            {
                using var invalidate = lua.GetFunction("__engine_scope_symbol_registered");
                invalidate.Call(name);
                return 0;
            });
        }

        public LuaTable CreateTable()
        {
            return (LuaTable)Context.Evaluate("return {}")[0];
        }

        public void Reset()
        {
            symbols.Clear();
            types.Clear();
            precachedAssemblies.Clear();
            Context.ResetModules();
            try
            {
                InitializeState();
            }
            catch
            {
                Context.ResetModules();
                throw;
            }
        }

        public void Dispose()
        {
            symbols.Clear();
            types.Clear();
            precachedAssemblies.Clear();
            Context.Dispose();
        }
    }
}
