using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Celeste.Everest.Runtime.LevelLoading
{
    internal static class EverestExceptionStackTrace
    {
        private static readonly Type runtimeDynamicMethod =
            typeof(DynamicMethod).GetNestedType("RTDynamicMethod", BindingFlags.NonPublic);

        public static bool TypeInStacktrace(Exception exception, Type type)
        {
            if (exception == null || type == null) return false;
            return new StackTrace(exception).GetFrames()?.Select(frame => frame.GetMethod()).Any(method =>
                method != null && (method.DeclaringType == type || IsDynamicMethod(method) &&
                    Regex.Match(method.Name, "DMD<(.*)::").Groups[1].Value == type.ToString())) ?? false;
        }

        private static bool IsDynamicMethod(MethodBase method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            if (runtimeDynamicMethod != null)
                return method is DynamicMethod || method.GetType() == runtimeDynamicMethod;
            if (method is DynamicMethod) return true;
            if (method.MetadataToken != 0 || !method.IsStatic || !method.IsPublic) return false;
            if (method.DeclaringType != null)
                foreach (var candidate in method.DeclaringType.GetMethods(BindingFlags.Public | BindingFlags.Static))
                    if (method == candidate)
                        return false;
            return true;
        }
    }
}
