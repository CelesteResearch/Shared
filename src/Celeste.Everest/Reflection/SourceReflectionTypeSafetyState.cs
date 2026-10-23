using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Everest.Reflection
{
    public sealed class SourceReflectionTypeSafetyState
    {
        private ConditionalWeakTable<Type, object> safeTypes;
        private Func<Type, bool> normalPredicate;
        private Func<Type, bool> partialPredicate;

        public bool IsSafe(Type type)
        {
            if (safeTypes == null) safeTypes = new ConditionalWeakTable<Type, object>();
            try
            {
                if (safeTypes.TryGetValue(type, out var _)) return true;
                _ = type.Name;
                _ = type.Assembly.FullName;
                _ = type.Module.FullyQualifiedName;
                Type declaringType = type.DeclaringType;
                if ((object)declaringType != null && !IsSafe(declaringType)) return false;
                Type baseType = type.BaseType;
                if ((object)baseType != null && !IsSafe(baseType)) return false;
                safeTypes.Add(type, new object());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Type[] GetTypesSafe(Assembly assembly)
        {
            try
            {
                Type[] types = assembly.GetTypes();
                return types.Where(normalPredicate ?? (normalPredicate = type => IsSafe(type))).ToArray();
            }
            catch (ReflectionTypeLoadException exception)
            {
                Type[] types = exception.Types;
                return types.Where(partialPredicate ??
                                   (partialPredicate = type => type != null && IsSafe(type))).ToArray();
            }
        }
    }
}
