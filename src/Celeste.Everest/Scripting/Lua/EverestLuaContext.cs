using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Everest.Content.Packages;
using Celeste.Everest.Content.Registry;
using NLua;

namespace Celeste.Everest.Scripting.Lua
{
    // Shared application VM, independent from any TAS or scene host. Modules install their own
    // local environment and helpers; ordinary Everest scripts need no TAS package to execute.
    public sealed class EverestLuaContext : IDisposable
    {
        public static EverestLuaContext Shared { get; } = new();

        private readonly EverestContentRegistry content;

        public EverestLuaContext()
        {
        }

        public EverestLuaContext(EverestContentRegistry content)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
        }

        private readonly object sync = new();
        private readonly HashSet<string> modules = new(StringComparer.Ordinal);
        private readonly List<TrackedHook> hooks = [];
        private NLua.Lua state;
        private LuaFunction symbolFunction;
        private LuaFunction nativeRequireFunction;
        private EverestLuaLoader loader;
        private EverestLuaBridge bridge;

        private bool disposed;

        // A runtime can install MonoMod-style method detours without adding an
        // engine reference to this shared package. The returned handle owns the hook.
        public static Func<MethodBase, LuaFunction, IDisposable> HookAdapter { get; set; }

        private NLua.Lua State
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(EverestLuaContext));
                if (state != null) return state;
                try
                {
                    state = new() { UseTraceback = true };
                    state.State.Encoding = Encoding.UTF8;
                    state["__everest_types"] = new EverestLuaTypes();
                    bridge = content == null
                        ? new(EverestManifestCatalog.Shared)
                        : new EverestLuaBridge(content);
                    state["__everest_bridge"] = bridge;
                    loader = new(state);
                    state["__everest_loader"] = loader;
                    var boot = state.DoString(EverestLuaBoot.Source,
                        "boot.lua");
                    symbolFunction = (LuaFunction)boot[3];
                    nativeRequireFunction = (LuaFunction)boot[2];
                    bridge.PrecacheAssembly = assembly =>
                    {
                        EverestLuaActualAssemblyRegistry.Register(state, assembly);
                        loader.Precache(assembly);
                    };
                    foreach (var assembly in EverestLuaTypes
                                 .LoadedAssemblies())
                        EverestLuaActualAssemblyRegistry.Register(state, assembly);

                    ((LuaFunction)boot[0]).Call(new Func<string, bool>(bridge.Preload),
                        new Func<string, string, string[]>(bridge.VirtualFile),
                        new Func<MethodBase, LuaFunction, object>((method, callback) =>
                        {
                            var adapter = HookAdapter;
                            if (adapter == null)
                                throw new NotSupportedException(
                                    "Everest Lua method hooks need a runtime hook adapter.");
                            var hook = new TrackedHook(this, adapter(method, callback));
                            hooks.Add(hook);
                            return hook;
                        }));
                    state.DoString(CompatibilityBootstrap, "Everest port Lua compatibility");
                }
                catch (Exception initializationFailure)
                {
                    try
                    {
                        ReleaseState();
                    }
                    catch (Exception cleanupFailure)
                    {
                        initializationFailure.Data["LuaInitializationCleanupFailure"] = cleanupFailure;
                    }

                    throw;
                }

                return state;
            }
        }

        public object[] Evaluate(string code, string chunkName = null)
        {
            return WithState(lua => lua.DoString(code ?? string.Empty, chunkName));
        }

        public void Initialize()
        {
            lock (sync)
            {
                _ = State;
            }
        }

        public void Precache(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            lock (sync)
            {
                _ = State;
                bridge.PrecacheAssembly(assembly);
            }
        }

        public object Require(string name)
        {
            return WithState(lua =>
            {
                using var require = lua.GetFunction("require");
                return require.Call(name)?.FirstOrDefault();
            });
        }

        public object RequireClr(string name)
        {
            return WithState(lua => nativeRequireFunction.Call(name)?.FirstOrDefault());
        }

        public void RegisterTypeAlias(string name, Type actualType)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A type alias is required.", nameof(name));
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            lock (sync)
            {
                _ = State;
                loader.RegisterAlias(name, actualType);
            }
        }

        public LuaTable Symbol(string name)
        {
            return WithState(lua => symbolFunction.Call(name)?.FirstOrDefault() as LuaTable);
        }

        public T WithState<T>(Func<NLua.Lua, T> operation)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            lock (sync)
            {
                return operation(State);
            }
        }

        public void InitializeModule(string name, Action<NLua.Lua> initialize)
        {
            lock (sync)
            {
                if (modules.Contains(name)) return;
                initialize(State);
                modules.Add(name);
            }
        }

        // Editor domain-reload-disabled Play ends the previous process-equivalent
        // module lifetime. Keep the shared wrapper identity, but discard its VM,
        // package.loaded table and ordered symbol resolvers before the next boot.
        public void ResetModules()
        {
            lock (sync)
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(EverestLuaContext));
                ReleaseState();
            }
        }

        public void Dispose()
        {
            lock (sync)
            {
                if (disposed) return;
                disposed = true;
                ReleaseState();
            }
        }

        private void ReleaseState()
        {
            List<Exception> failures = null;
            for (var i = hooks.Count - 1; i >= 0; i--)
                try
                {
                    hooks[i].Dispose();
                }
                catch (Exception error)
                {
                    (failures ??= []).Add(error);
                }

            hooks.Clear();
            try
            {
                symbolFunction?.Dispose();
            }
            catch (Exception error)
            {
                (failures ??= []).Add(error);
            }

            try
            {
                nativeRequireFunction?.Dispose();
            }
            catch (Exception error)
            {
                (failures ??= []).Add(error);
            }

            try
            {
                state?.Dispose();
            }
            catch (Exception error)
            {
                (failures ??= []).Add(error);
            }

            state = null;
            symbolFunction = null;
            nativeRequireFunction = null;
            loader = null;
            bridge = null;
            modules.Clear();
            if (failures != null) throw new AggregateException("Lua VM cleanup failed.", failures);
        }

        private sealed class TrackedHook : IDisposable
        {
            private readonly EverestLuaContext owner;
            private IDisposable hook;

            public TrackedHook(EverestLuaContext owner, IDisposable hook)
            {
                this.owner = owner;
                this.hook = hook ?? throw new InvalidOperationException("Lua hook adapter returned no handle.");
            }

            public void Dispose()
            {
                lock (owner.sync)
                {
                    var current = hook;
                    if (current == null) return;
                    hook = null;
                    owner.hooks.Remove(this);
                    current.Dispose();
                }
            }
        }

        private const string CompatibilityBootstrap = @"
local originalRequire = require
local resolvers = {}
everest = {}
function everest.register_symbol_resolver(name, callback)
    for i, pair in ipairs(resolvers) do
        if pair[1] == name then pair[2] = callback; return end
    end
    table.insert(resolvers, {name, callback})
end
local function unresolved(path)
    return setmetatable({}, {
        __index = function(_, key) return unresolved(path .. '.' .. tostring(key)) end,
        __call = function() error('No such type: ' .. path, 2) end
    })
end
require = function(name)
    if string.sub(name, 1, 1) == '#' then
        local path = string.sub(name, 2)
        for _, pair in ipairs(resolvers) do
            local value = pair[2](path)
            if value ~= nil then return value end
        end
        local alias = __everest_types:TypeName(path)
        if alias ~= nil and alias ~= path then
            luanet.load_assembly(__everest_types:AssemblyName(path))
            return luanet.import_type(alias)
        end
        local ok, value = pcall(originalRequire, name)
        if ok then return value end
        return unresolved(path)
    end
    return originalRequire(name)
end
";
    }
}
