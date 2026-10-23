using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using NLua;

namespace Celeste.Everest.Scripting.Lua
{
    // NLua 1.4.1 has no public API for registering an already-loaded Assembly.
    // Resolve its pinned storage shape once; never resolve a second copy by name.
    internal static class EverestLuaActualAssemblyRegistry
    {
        private static readonly FieldInfo TranslatorField = RequireField(
            typeof(NLua.Lua), "_translator", typeof(ObjectTranslator));

        private static readonly FieldInfo AssembliesField = RequireField(
            typeof(ObjectTranslator), "assemblies", typeof(List<Assembly>));

        private static readonly Action<ObjectTranslator, KeraLua.Lua, Type> PushActualType =
            (Action<ObjectTranslator, KeraLua.Lua, Type>)RequirePushType().CreateDelegate(
                typeof(Action<ObjectTranslator, KeraLua.Lua, Type>));

        internal static void PushType(NLua.Lua context, KeraLua.Lua stack, Type actualType)
        {
            var translator = TranslatorField.GetValue(context) as ObjectTranslator ??
                             throw new InvalidOperationException("The actual NLua translator is unavailable.");
            if (!ReferenceEquals(translator.Interpreter, context) ||
                stack.MainThread.Handle != context.State.MainThread.Handle)
                throw new InvalidOperationException("The actual NLua type import belongs to another Lua context.");
            PushActualType(translator, stack, actualType);
        }

        private static MethodInfo RequirePushType()
        {
            var method = typeof(ObjectTranslator).GetMethod("PushType",
                BindingFlags.Instance | BindingFlags.NonPublic, null,
                new[] { typeof(KeraLua.Lua), typeof(Type) }, null);
            if (method == null || method.ReturnType != typeof(void))
                throw new MissingMethodException(typeof(ObjectTranslator).FullName, "PushType");
            return method;
        }

        internal static IEqualityComparer<Assembly> ReferenceComparer { get; } = new AssemblyIdentityComparer();

        internal static void Register(NLua.Lua context, Assembly actualAssembly)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (actualAssembly == null) throw new ArgumentNullException(nameof(actualAssembly));
            if (actualAssembly.IsDynamic) return;
            var translator = TranslatorField.GetValue(context) as ObjectTranslator ??
                             throw new InvalidOperationException("The actual NLua translator is unavailable.");
            if (!ReferenceEquals(translator.Interpreter, context))
                throw new InvalidOperationException("The actual NLua translator belongs to another Lua context.");
            var assemblies = AssembliesField.GetValue(translator) as List<Assembly> ??
                             throw new InvalidOperationException("The actual NLua assembly list is unavailable.");
            foreach (Assembly existing in assemblies)
                if (ReferenceEquals(existing, actualAssembly))
                    return;
            assemblies.Add(actualAssembly);
        }

        private static FieldInfo RequireField(Type owner, string name, Type fieldType)
        {
            if (typeof(NLua.Lua).Assembly.GetName().Version != new Version(1, 4, 1, 0))
                throw new NotSupportedException(
                    "The NLua actual-assembly adapter requires the reviewed NLua 1.4.1 ABI.");
            var field = owner.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
            if (field == null || field.FieldType != fieldType)
                throw new MissingFieldException(owner.FullName, name);
            return field;
        }

        private sealed class AssemblyIdentityComparer : IEqualityComparer<Assembly>
        {
            public bool Equals(Assembly left, Assembly right) => ReferenceEquals(left, right);
            public int GetHashCode(Assembly value) => RuntimeHelpers.GetHashCode(value);
        }
    }
}
