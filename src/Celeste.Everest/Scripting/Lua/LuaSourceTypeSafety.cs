using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Everest.Scripting.Lua
{
    internal static class LuaSourceTypeSafety
    {
        private static ConditionalWeakTable<Type, object> _SafeTypes;

        public static bool IsSafe(this Type type)
        {
            if (_SafeTypes == null) _SafeTypes = new();

            try
            {
                if (_SafeTypes.TryGetValue(type, out _)) return true;

                _ = type.Name;
                _ = type.Assembly.FullName;
                _ = type.Module.FullyQualifiedName;
                var declaringType = type.DeclaringType;
                if ((object)declaringType != null && !declaringType.IsSafe()) return false;

                var baseType = type.BaseType;
                if ((object)baseType != null && !baseType.IsSafe()) return false;

                _SafeTypes.Add(type, new());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Type[] GetTypesSafe(this Assembly asm)
        {
            try
            {
                return
                [
                    .. from t in asm.GetTypes()
                    where t.IsSafe()
                    select t,
                ];
            }
            catch (ReflectionTypeLoadException ex)
            {
                return [.. ex.Types.Where(t => t != null && t.IsSafe())];
            }
        }
    }
}
