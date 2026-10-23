using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Celeste.Everest.Scripting.Lua;
using Mono.Cecil.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using NLua;

namespace Celeste.Everest.Detours
{
    // The engine-independent core exposes the hook port; this separate assembly
    // owns the runtime-specific MonoMod method replacement used by Everest Lua.
    public static class EverestLuaDetourAdapter
    {
        private static readonly MethodInfo call = typeof(LuaFunction).GetMethod("Call", [typeof(object[])]);

        // The typed delegate qualifies the real SDK ABI inside its owning assembly.
        // Consumers can register this exact method without taking an NLua dependency.
        public static MethodInfo HookMethodMetadata { get; } =
            ((Func<MethodBase, LuaFunction, IDisposable>)HookMethod).Method;

        public static void Install()
        {
            EverestLuaContext.HookAdapter = HookMethod;
        }

        public static void Uninstall()
        {
            if (EverestLuaContext.HookAdapter == HookMethod)
                EverestLuaContext.HookAdapter = null;
        }

        public static IDisposable HookMethod(MethodBase from, LuaFunction to)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));
            if (to == null) throw new ArgumentNullException(nameof(to));
            var previousDmdType = Environment.GetEnvironmentVariable("MONOMOD_DMDType");
            Environment.SetEnvironmentVariable("MONOMOD_DMDType", "Cecil");
            try
            {
                var parameters = from.GetParameters();
                Type[] argumentTypes;
                Type[] originalTypes;
                if (!from.IsStatic)
                {
                    originalTypes = new Type[parameters.Length + 1];
                    argumentTypes = new Type[parameters.Length + 2];
                    originalTypes[0] = from.GetThisParamType();
                    argumentTypes[1] = originalTypes[0];
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        originalTypes[i + 1] = parameters[i].ParameterType;
                        argumentTypes[i + 2] = parameters[i].ParameterType;
                    }
                }
                else
                {
                    originalTypes = new Type[parameters.Length];
                    argumentTypes = new Type[parameters.Length + 1];
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        originalTypes[i] = parameters[i].ParameterType;
                        argumentTypes[i + 1] = parameters[i].ParameterType;
                    }
                }

                var resultType = (from as MethodInfo)?.ReturnType ?? typeof(void);
                var delegateType = GetOriginalDelegateType(originalTypes, resultType);
                argumentTypes[0] = delegateType;
                MethodInfo replacement;
                using (var dmd = new DynamicMethodDefinition("HookProxy_" + to, resultType, argumentTypes))
                {
                    var il = dmd.GetILProcessor();
                    il.EmitNewReference(to, out _);
                    il.Emit(OpCodes.Ldc_I4, argumentTypes.Length);
                    il.Emit(OpCodes.Newarr, typeof(object));
                    for (var i = 0; i < argumentTypes.Length; i++)
                    {
                        var sourceIndex = !from.IsStatic && i <= 1 ? (i + 1) % 2 : i;
                        var type = argumentTypes[sourceIndex];
                        var byRef = type.IsByRef;
                        if (byRef) type = type.GetElementType();
                        il.Emit(OpCodes.Dup);
                        il.Emit(OpCodes.Ldc_I4, i);
                        il.Emit(OpCodes.Ldarg, sourceIndex);
                        if (type.IsValueType) il.Emit(OpCodes.Box, type);
                        il.Emit(OpCodes.Stelem_Ref);
                    }

                    il.Emit(OpCodes.Callvirt, call);
                    if (resultType != typeof(void))
                    {
                        il.Emit(OpCodes.Ldc_I4_0);
                        il.Emit(OpCodes.Ldelem_Ref);
                        if (resultType.IsValueType) il.Emit(OpCodes.Unbox_Any, resultType);
                    }
                    else
                    {
                        il.Emit(OpCodes.Pop);
                    }

                    il.Emit(OpCodes.Ret);
                    replacement = dmd.Generate();
                }

                return new Hook(from, replacement);
            }
            finally
            {
                Environment.SetEnvironmentVariable("MONOMOD_DMDType", previousDmdType);
            }
        }

        private static Type GetOriginalDelegateType(Type[] arguments, Type result)
        {
            // HookHelper counts the return type in funcs before applying its
            // 17-entry bound: 16 void arguments, or 15 non-void arguments.
            if (arguments.Length + (result == typeof(void) ? 0 : 1) >= 17)
                throw new NotSupportedException("Lua hook signature has too many arguments.");
            if (result == typeof(void))
                return arguments.Length == 0 ? typeof(Action) : Expression.GetActionType(arguments);
            return Expression.GetFuncType([.. arguments.Concat((Type[])[result])]);
        }
    }
}
