using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;

namespace Celeste.Everest.Scripting.Lua
{
    public sealed partial class EverestLuaTypes
    {
        private static readonly Dictionary<string, Type> aliases = new(StringComparer.Ordinal)
        {
            ["Microsoft.Xna.Framework.Vector2"] = typeof(Vector2),
            ["Microsoft.Xna.Framework.Vector3"] = typeof(Vector3),
            ["Microsoft.Xna.Framework.Vector4"] = typeof(Vector4),
            ["Microsoft.Xna.Framework.Color"] = typeof(PackedColor),
            ["Celeste.Mod.LuaCoroutine"] = typeof(EverestLuaCoroutine),
        };

        public static void RegisterAlias(string fullName, Type type)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("A full CLR type name is required.", nameof(fullName));
            if (type == null) throw new ArgumentNullException(nameof(type));
            lock (sync)
            {
                aliases[fullName] = type;
            }
        }

        public static bool RemoveAlias(string fullName)
        {
            lock (sync)
            {
                return aliases.Remove(fullName);
            }
        }

        private static bool TryAlias(string name, out Type type)
        {
            lock (sync)
            {
                return aliases.TryGetValue(name, out type);
            }
        }

        internal static bool HasAliasNamespace(string name)
        {
            var prefix = name + ".";
            lock (sync)
            {
                foreach (var alias in aliases.Keys)
                    if (alias.StartsWith(prefix, StringComparison.Ordinal))
                        return true;
            }

            return false;
        }

        internal static KeyValuePair<string, Type>[] AliasPaths()
        {
            lock (sync)
            {
                return [.. new List<KeyValuePair<string, Type>>(aliases)];
            }
        }
    }
}
