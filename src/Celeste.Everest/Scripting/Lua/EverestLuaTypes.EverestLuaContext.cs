using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using NLua;
using Celeste.Everest;

namespace Celeste.Everest.Scripting.Lua
{
    public sealed partial class EverestLuaTypes
    {
        // Ordinary .NET needs no host setup. Engine hosts can replace this with
        // their own unload-aware assembly registry without changing this DLL.
        public static Func<IEnumerable<Assembly>> LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies;
        private static readonly object sync = new object();
        private static Assembly[] assemblies = Array.Empty<Assembly>();
        private static readonly Dictionary<string, Type> types = new Dictionary<string, Type>(StringComparer.Ordinal);

        public static Type FindType(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            if (TryAlias(name, out var alias)) return alias;
            lock (sync)
            {
                Assembly[] current = (LoadedAssemblies ?? AppDomain.CurrentDomain.GetAssemblies)().ToArray();
                if (!assemblies.SequenceEqual(current))
                {
                    assemblies = current;
                    types.Clear();
                    foreach (var assembly in current)
                    {
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
                            continue;
                        }

                        foreach (var type in declared)
                        {
                            if (type == null) continue;
                            // Everest 6580 PrecacheType registers nested types only when
                            // every nested link back to the top-level type is public.
                            if (type.IsNested && !HasPublicNestedPath(type)) continue;
                            // A bare #Name is looked up in the global namespace. Types
                            // from other namespaces require their namespace path.
                            if (!type.IsNested && string.IsNullOrEmpty(type.Namespace) &&
                                !types.ContainsKey(type.Name)) types.Add(type.Name, type);
                            string full = type.FullName?.Replace('+', '.');
                            if (full != null && !types.ContainsKey(full)) types.Add(full, type);
                        }
                    }
                }

                return types.TryGetValue(name, out var value) ? value : null;
            }
        }

        private static bool HasPublicNestedPath(Type type)
        {
            for (Type current = type; current != null && current.IsNested; current = current.DeclaringType)
                if (!current.IsNestedPublic)
                    return false;
            return true;
        }

        public string TypeName(string name) => FindType(name)?.FullName;
        public string AssemblyName(string name) => FindType(name)?.Assembly.FullName;
    }
}
