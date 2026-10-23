#nullable enable annotations
using System;
using System.Reflection;
using System.Reflection.Emit;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Members
{
    public static class SourceCompiledFieldGetter
    {
        public static Func<object, TResult>? CreateReflected<TResult>(ReflectedMember binding)
        {
            if (binding == null) return null;
            if (binding.OriginalBinding != null) return Create<TResult>(binding.OriginalBinding);
            if (binding.ActualMember is not FieldInfo field)
                throw new InvalidOperationException("A compiled field getter requires an actual CLR field.");
            if (!typeof(TResult).IsAssignableFrom(field.FieldType))
                throw new InvalidCastException(
                    $"{field.Name} is of type {field.FieldType}, it cannot be assigned to the type {typeof(TResult)}.");
            if (field.IsLiteral)
            {
                TResult value = (TResult)field.GetValue(null);
                return _ => value;
            }

            var method = new DynamicMethod(field.DeclaringType?.FullName + "." + field.Name + " Getter",
                typeof(TResult), new[] { typeof(object) }, field.Module, true);
            var il = method.GetILGenerator();
            if (!field.IsStatic)
            {
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(field.DeclaringType.IsValueType ? OpCodes.Unbox : OpCodes.Castclass, field.DeclaringType);
            }

            il.Emit(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, field);
            if (Nullable.GetUnderlyingType(typeof(TResult)) == field.FieldType)
                il.Emit(OpCodes.Newobj, typeof(TResult).GetConstructor(new[] { field.FieldType }));
            else if (field.FieldType.IsValueType && !typeof(TResult).IsValueType) il.Emit(OpCodes.Box, field.FieldType);
            il.Emit(OpCodes.Ret);
            return (Func<object, TResult>)method.CreateDelegate(typeof(Func<object, TResult>));
        }

        public static Func<object, TResult>? Create<TResult>(SourcePhysicalMemberBinding binding)
        {
            if (binding == null) return null;
            if (binding.OriginalKind != SourceMemberKind.Field)
                throw new InvalidOperationException("The original getter requires a source field.");
            if (!typeof(TResult).IsAssignableFrom(binding.ValueType))
                throw new InvalidCastException(
                    $"{binding.Name} is of type {binding.ValueType}, it cannot be assigned to the type {typeof(TResult)}.");
            if (binding.Definition.IsLiteral)
            {
                TResult value = (TResult)binding.Definition.ConstantValue;
                return _ => value;
            }

            if (binding.Definition.IsStatic && !((FieldInfo)binding.ActualPath[0]).IsStatic)
                throw new InvalidOperationException(
                    "A migrated static source field needs its genuine process-owner getter.");
            var method = new DynamicMethod(binding.Definition.QualifiedName + " Getter", typeof(TResult),
                new[] { typeof(object) }, binding.DeclaringType, true);
            var il = method.GetILGenerator();
            if (!binding.Definition.IsStatic)
            {
                il.Emit(OpCodes.Ldarg_0);
                if (binding.ActualInstanceScope.IsValueType) il.Emit(OpCodes.Unbox, binding.ActualInstanceScope);
                else il.Emit(OpCodes.Castclass, binding.ActualInstanceScope);
            }

            for (int index = 0; index < binding.ActualPath.Count; index++)
            {
                var field = binding.ActualPath[index] as FieldInfo
                            ?? throw new InvalidOperationException(
                                "The exact original field getter cannot silently replace a field path with a property.");
                if (index != 0 && field.IsStatic)
                    throw new InvalidOperationException(
                        "A nested actual field path cannot change the original instance protocol.");
                if (index + 1 < binding.ActualPath.Count && field.FieldType.IsValueType)
                    il.Emit(field.IsStatic ? OpCodes.Ldsflda : OpCodes.Ldflda, field);
                else il.Emit(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, field);
            }

            if (binding.ValueType.IsValueType && !typeof(TResult).IsValueType) il.Emit(OpCodes.Box, binding.ValueType);
            il.Emit(OpCodes.Ret);
            return (Func<object, TResult>)method.CreateDelegate(typeof(Func<object, TResult>));
        }
    }
}
