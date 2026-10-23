using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Modules;
using Celeste.Everest.Diagnostics.Logging;
using NLua;

namespace Celeste.Everest.Scripting.Lua
{
    public class EverestLuaTypeBuilderProcess
    {
        private readonly EverestLuaLoaderProcess Loader;
        private readonly string PathEverest;
        private readonly EverestContentRegistry Content;
        private readonly EverestLoggerProcess Logger;

        public EverestLuaTypeBuilderProcess(EverestLuaLoaderProcess loader, string pathEverest,
            EverestContentRegistry content, EverestLoggerProcess logger)
        {
            Loader = loader;
            PathEverest = pathEverest;
            Content = content;
            Logger = logger;
        }

        private readonly ConstructorInfo c_UnverifiableCodeAttribute =
            typeof(UnverifiableCodeAttribute).GetConstructor( /* ReSharper disable once UseCollectionExpression */
                new Type[0]);

        private int Count = -1;

        private LuaTable _SymNode;

        private Func<LuaFunction, LuaTable> InvokeCB;

        internal void Initialize()
        {
            Stream stream = null;
            string code;
            try
            {
                var path = Path.Combine(PathEverest, "typebuilder.lua");
                EverestContentAsset metadata;
                if (File.Exists(path))
                {
                    Logger.Info("Everest.LuaTypeBuilder", "Found external Lua typebuilder script.");
                    stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                }
                else if (Content.TryGet<AssetTypeLua>("Lua/typebuilder", out metadata))
                {
                    Logger.Verbose("Everest.LuaTypeBuilder", "Found built-in Lua typebuilder script.");
                    stream = metadata.Stream;
                }

                if (stream == null)
                {
                    Logger.Warn("Everest.LuaTypeBuilder",
                        "Lua typebuilder script not found, disabling LuaTypeBuilder.");
                    Count = -2;
                    return;
                }

                using var streamReader = new StreamReader(stream);
                code = streamReader.ReadToEnd();
            }
            finally
            {
                stream?.Dispose();
            }

            var array = Loader.Run(code, "typebuilder.lua");
            var invokecb = (LuaFunction)array[0];
            InvokeCB = cb => invokecb.Call(cb)?.FirstOrDefault() as LuaTable;
            _SymNode = Loader.Symbol("node");
        }

        public Type Build(object rulesOrCB)
        {
            if (Count == -2) return null;

            Count++;
            var luaTable = rulesOrCB as LuaTable;
            if (rulesOrCB is LuaFunction arg) luaTable = InvokeCB(arg);

            if (luaTable == null) return null;

            var text = luaTable["namespace"] as string;
            var text2 = luaTable["name"] as string ?? $"LuaType{Count}";
            var value = string.IsNullOrEmpty(text) ? text2 : text + "." + text2;
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new()
            {
                Name = $"LuaDynAsm{Count}",
            }, AssemblyBuilderAccess.Run);
            assemblyBuilder.SetCustomAttribute(new(
                c_UnverifiableCodeAttribute, /* ReSharper disable once UseCollectionExpression */ new object[0]));
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyBuilder.GetName().Name + ".dll");
            Type type = null;
            if (type == null && luaTable["__base"] is EverestLuaLoaderProcess.CachedType cachedType)
                type = cachedType.Type;

            if (type == null && luaTable["__base"] is string typeName) type = Type.GetType(typeName);

            if (type == null) type = typeof(object);

            var typeBuilder = moduleBuilder.DefineType(text2, TypeAttributes.Public, type);
            foreach (KeyValuePair<object, object> item in luaTable)
            {
                var text3 = item.Key as string;
                if (!string.IsNullOrEmpty(text3) && !text3.StartsWith("__") && item.Value is LuaFunction)
                {
                    var obj = luaTable["__" + text3] as LuaTable ??
                              throw new InvalidDataException(
                                  $"Type ruleset for {value} contains function {text3} but no info!");
                    _ = obj["name"] is string;
                    Console.WriteLine((GetType(obj["ret"]) ?? typeof(void))?.ToString() ?? "NULL");
                }
            }

            var type2 = typeBuilder.CreateType();
            var asmBuilt = type2.Assembly;
            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
                !(e.Name == asmBuilt.FullName) ? null : asmBuilt;
            Loader.Precache(asmBuilt);
            return type2;
        }

        private Type GetType(object raw)
        {
            if (raw == null) return null;

            if (raw is Type result) return result;

            if (raw is EverestLuaLoaderProcess.CachedType cachedType) return cachedType.Type;

            if (raw is LuaTable luaTable) return luaTable[_SymNode] as Type;

            throw new InvalidDataException($"Expected Type, CachedType or a compatible LuaTable, got {raw.GetType()}");
        }
    }
}
