#nullable enable annotations

using System;
using System.Reflection;

namespace Celeste.Core.Reflection.Members
{
    public sealed class ReflectedMember
    {
        public SourcePhysicalMemberBinding? OriginalBinding { get; }
        public MemberInfo ActualMember { get; }
        public string Name => OriginalBinding?.Name ?? ActualMember.Name;
        public Type? DeclaringType => OriginalBinding?.DeclaringType ?? ActualMember.DeclaringType;

        public bool CanRead => OriginalBinding?.CanRead ??
                               (ActualMember is FieldInfo || ((PropertyInfo)ActualMember).CanRead);

        public bool CanWrite => OriginalBinding?.CanWrite ?? (ActualMember is FieldInfo field
            ? !field.IsLiteral && !field.IsInitOnly
            : ((PropertyInfo)ActualMember).CanWrite);

        public Type ValueType => OriginalBinding?.ValueType ?? (ActualMember is FieldInfo field
            ? field.FieldType
            : ((PropertyInfo)ActualMember).PropertyType);

        public ReflectedMember(SourcePhysicalMemberBinding binding)
        {
            OriginalBinding = binding ?? throw new ArgumentNullException(nameof(binding));
            ActualMember = binding.ActualMember;
        }

        public ReflectedMember(MemberInfo member)
        {
            if (member is not FieldInfo && member is not PropertyInfo)
                throw new ArgumentException("A reflected value must be a CLR field or property.", nameof(member));
            ActualMember = member;
        }

        public object? Read(object? instance)
        {
            if (OriginalBinding != null) return OriginalBinding.Read(instance);
            return ActualMember is FieldInfo field
                ? field.GetValue(instance)
                : ((PropertyInfo)ActualMember).GetValue(instance);
        }

        public void Write(object? instance, object? value)
        {
            if (OriginalBinding != null) OriginalBinding.Write(instance, value);
            else if (ActualMember is FieldInfo field) field.SetValue(instance, value);
            else ((PropertyInfo)ActualMember).SetValue(instance, value);
        }
    }
}
