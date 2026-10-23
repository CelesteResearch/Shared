using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Celeste.Everest.Diagnostics.Exceptions
{
    public static class SourceExceptionMethodStacktrace
    {
        private static readonly Type runtimeDynamicMethod =
            typeof(DynamicMethod).GetNestedType("RTDynamicMethod", BindingFlags.Public | BindingFlags.NonPublic);

        public static bool MethodInStacktrace(Exception exception, Type type, string methodName)
        {
            MethodBase target = type?.GetMethod(methodName);
            if (exception != null && target != null)
                return (new StackTrace(exception).GetFrames()?.Select(frame => frame.GetMethod()))?.Any(method =>
                    method != null && (method == target ||
                                       (IsDynamicMethod(method) &&
                                        method.Name == "DMD<" + GetSimpleMethodID(target) + ">"))) ?? false;
            return false;
        }

        private static bool IsDynamicMethod(MethodBase method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            if (runtimeDynamicMethod != null)
            {
                if (!(method is DynamicMethod)) return method.GetType() == runtimeDynamicMethod;
                return true;
            }

            if (method is DynamicMethod) return true;
            if (method.MetadataToken != 0 || !method.IsStatic || !method.IsPublic ||
                (method.Attributes & MethodAttributes.PrivateScope) != MethodAttributes.PrivateScope) return false;
            if ((object)method.DeclaringType != null)
                foreach (MethodInfo declaredMethod in method.DeclaringType.GetMethods(BindingFlags.Static |
                             BindingFlags.Public))
                    if (method == declaredMethod)
                        return false;
            return true;
        }

        private static string GetSimpleMethodID(MethodBase method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            while (method is MethodInfo info && method.IsGenericMethod && !method.IsGenericMethodDefinition)
                method = info.GetGenericMethodDefinition();
            var text = new StringBuilder();
            if (method.DeclaringType != null) text.Append(method.DeclaringType.FullName).Append("::");
            text.Append(method.Name);
            return text.ToString();
        }
    }
}
