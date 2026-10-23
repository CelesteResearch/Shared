#nullable enable annotations

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourcePhysicalMemberBinding
    {
        private readonly MemberInfo[] actualPath;

        private readonly MemberInfo[] actualWritePath;
        public SourceMemberDefinition Definition { get; }
        public MemberInfo ActualMember => actualPath[actualPath.Length - 1];
        public IReadOnlyList<MemberInfo> ActualPath { get; }
        public MemberInfo ActualWriteMember => actualWritePath[actualWritePath.Length - 1];
        public IReadOnlyList<MemberInfo> ActualWritePath { get; }
        public SourceMemberKind OriginalKind => Definition.Kind;
        public string Name => Definition.Name;
        public Type DeclaringType { get; }
        public Type OriginalDeclaringType => DeclaringType;
        public Type ActualInstanceScope { get; }
        public object? ActualStaticSourceOwner { get; }

        public Type ValueType { get; }
        public Type PhysicalLeafValueType { get; }
        public bool HasDeclaredActualValueType { get; }

        public FieldAttributes OriginalFieldAttributes => OriginalKind == SourceMemberKind.Field
            ? (FieldAttributes)Definition.Attributes
            : throw new InvalidOperationException("Source member is not a field.");

        public bool IsStatic => Definition.IsStatic;
        public bool IsPublic => Definition.IsPublic;
        public bool IsInitOnly => Definition.IsInitOnly;
        public bool IsLiteral => Definition.IsLiteral;

        public bool CanRead => Definition.CanRead && (ActualMember is FieldInfo
                                                      || ((PropertyInfo)ActualMember).CanRead);

        public bool CanWrite => Definition.CanWrite && (ActualWriteMember is FieldInfo field
            ? !field.IsLiteral
            : ((PropertyInfo)ActualWriteMember).CanWrite);

        public SourcePhysicalMemberBinding(SourceMemberDefinition definition, Type originalActualType,
            MemberInfo actualMember, object? staticSourceOwner = null, Type? actualInstanceScope = null,
            Type? declaredActualValueType = null)
            : this(definition, originalActualType, [actualMember], staticSourceOwner, actualInstanceScope,
                declaredActualValueType)
        {
        }

        public SourcePhysicalMemberBinding(SourceMemberDefinition definition, Type originalActualType,
            MemberInfo[] actualMemberPath, object? staticSourceOwner = null, Type? actualInstanceScope = null,
            Type? declaredActualValueType = null, MemberInfo[]? actualWriteMemberPath = null)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
            DeclaringType = originalActualType ?? throw new ArgumentNullException(nameof(originalActualType));
            ActualInstanceScope = actualInstanceScope ?? originalActualType;
            if (actualMemberPath == null || actualMemberPath.Length == 0)
                throw new ArgumentException("A real physical member path is required.", nameof(actualMemberPath));
            actualPath = (MemberInfo[])actualMemberPath.Clone();
            foreach (var member in actualPath)
                if (!(member is FieldInfo) && !(member is PropertyInfo))
                    throw new ArgumentException("Physical source member must be a real CLR field or property.",
                        nameof(actualMemberPath));
            ActualPath = Array.AsReadOnly(actualPath);
            PhysicalLeafValueType = PhysicalValueType(ActualMember);
            HasDeclaredActualValueType = declaredActualValueType != null;
            if (declaredActualValueType != null && (PhysicalLeafValueType.IsValueType
                                                    || declaredActualValueType.IsValueType
                                                    || !PhysicalLeafValueType.IsAssignableFrom(
                                                        declaredActualValueType)))
                throw new ArgumentException(
                    "A declared source reference value must narrow its actual reference storage type.",
                    nameof(declaredActualValueType));
            ValueType = declaredActualValueType ?? PhysicalLeafValueType;
            var physicalStatic = IsPhysicalStatic(actualPath[0]);
            if (!definition.IsStatic && (physicalStatic || staticSourceOwner != null))
                throw new ArgumentException("An instance source member must use its actual instance.");
            if (definition.IsStatic && !physicalStatic && staticSourceOwner == null)
                throw new ArgumentException("A migrated static source member requires its actual process owner.");
            var ownerType = definition.IsStatic ? staticSourceOwner?.GetType() : ActualInstanceScope;
            for (var index = 0; index < actualPath.Length; index++)
            {
                var member = actualPath[index];
                if (!IsPhysicalStatic(member)
                    && (ownerType == null || !member.DeclaringType.IsAssignableFrom(ownerType)))
                    throw new ArgumentException("Physical member path does not belong to the actual source owner.",
                        nameof(actualMemberPath));
                if (member is PropertyInfo property && property.GetIndexParameters().Length != 0)
                    throw new ArgumentException("An indexed property requires its original indexed-access protocol.",
                        nameof(actualMemberPath));
                ownerType = PhysicalValueType(member);
            }

            actualWritePath = actualPath;
            if (actualWriteMemberPath != null)
            {
                if (actualWriteMemberPath.Length == 0)
                    throw new ArgumentException("A real physical write member path is required.",
                        nameof(actualWriteMemberPath));
                actualWritePath = (MemberInfo[])actualWriteMemberPath.Clone();
                foreach (var member in actualWritePath)
                    if (!(member is FieldInfo) && !(member is PropertyInfo))
                        throw new ArgumentException("Physical source member must be a real CLR field or property.",
                            nameof(actualWriteMemberPath));
                var writeStatic = IsPhysicalStatic(actualWritePath[0]);
                if (!definition.IsStatic && (writeStatic || staticSourceOwner != null))
                    throw new ArgumentException("An instance source member must use its actual instance.");
                if (definition.IsStatic && !writeStatic && staticSourceOwner == null)
                    throw new ArgumentException("A migrated static source member requires its actual process owner.");
                ownerType = definition.IsStatic ? staticSourceOwner?.GetType() : ActualInstanceScope;
                for (var index = 0; index < actualWritePath.Length; index++)
                {
                    var member = actualWritePath[index];
                    if (!IsPhysicalStatic(member)
                        && (ownerType == null || !member.DeclaringType.IsAssignableFrom(ownerType)))
                        throw new ArgumentException("Physical write path does not belong to the actual source owner.",
                            nameof(actualWriteMemberPath));
                    if (member is PropertyInfo property && property.GetIndexParameters().Length != 0)
                        throw new ArgumentException(
                            "An indexed property requires its original indexed-access protocol.",
                            nameof(actualWriteMemberPath));
                    var leaf = index == actualWritePath.Length - 1;
                    if (!leaf && member is PropertyInfo unreadable && !unreadable.CanRead)
                        throw new ArgumentException("A physical write path must have readable intermediate owners.",
                            nameof(actualWriteMemberPath));
                    var needsWrite = leaf || PhysicalValueType(member).IsValueType;
                    if (needsWrite && ((member is FieldInfo field && (field.IsLiteral || field.IsInitOnly))
                                       || (member is PropertyInfo unwritable && !unwritable.CanWrite)))
                        throw new ArgumentException(
                            "A physical write path must have writable storage and struct owners.",
                            nameof(actualWriteMemberPath));
                    ownerType = PhysicalValueType(member);
                }

                var writeValueType = PhysicalValueType(ActualWriteMember);
                if (!writeValueType.IsAssignableFrom(ValueType)
                    || writeValueType.IsValueType != ValueType.IsValueType)
                    throw new ArgumentException("Physical write storage must accept the qualified source value type.",
                        nameof(actualWriteMemberPath));
            }

            ActualWritePath = Array.AsReadOnly(actualWritePath);

            ActualStaticSourceOwner = staticSourceOwner;
        }

        public object? Read(object? instance)
        {
            if (!CanRead) throw new MemberAccessException("Source member is not readable: " + Definition.QualifiedName);
            var target = Definition.IsStatic ? ActualStaticSourceOwner : instance;
            foreach (var member in actualPath) target = ReadPhysical(member, target);
            ValidateDeclaredValue(target);
            return target;
        }

        public void Write(object? instance, object? value)
        {
            if (!CanWrite)
                throw new MemberAccessException("Source member is not writable: " + Definition.QualifiedName);
            ValidateDeclaredValue(value);
            if (actualWritePath.Length == 1)
            {
                WritePhysical(ActualWriteMember, Definition.IsStatic ? ActualStaticSourceOwner : instance, value);
                return;
            }

            var owners = new object?[actualWritePath.Length];
            owners[0] = Definition.IsStatic ? ActualStaticSourceOwner : instance;
            for (var index = 1; index < actualWritePath.Length; index++)
                owners[index] = ReadPhysical(actualWritePath[index - 1], owners[index - 1]);
            WritePhysical(ActualWriteMember, owners[owners.Length - 1], value);
            // Reflective access boxes intermediate structs. Write the same modified box
            // back through its actual member path; reference owners already retain mutation.
            for (var index = actualWritePath.Length - 2; index >= 0; index--)
            {
                if (!PhysicalValueType(actualWritePath[index]).IsValueType) break;
                WritePhysical(actualWritePath[index], owners[index], owners[index + 1]);
            }
        }

        private void ValidateDeclaredValue(object? value)
        {
            if (HasDeclaredActualValueType && value != null && !ValueType.IsInstanceOfType(value))
                throw new InvalidOperationException(
                    "Actual source reference value does not match its qualified declared type: " +
                    Definition.QualifiedName);
        }

        private static Type PhysicalValueType(MemberInfo member)
        {
            return member is FieldInfo field
                ? field.FieldType
                : ((PropertyInfo)member).PropertyType;
        }

        private static bool IsPhysicalStatic(MemberInfo member)
        {
            return member is FieldInfo field
                ? field.IsStatic
                : (((PropertyInfo)member).GetGetMethod(true)
                   ?? ((PropertyInfo)member).GetSetMethod(true)).IsStatic;
        }

        private static object? ReadPhysical(MemberInfo member, object? owner)
        {
            return member is FieldInfo field
                ? field.GetValue(IsPhysicalStatic(member) ? null : owner)
                : ((PropertyInfo)member).GetValue(IsPhysicalStatic(member) ? null : owner);
        }

        private static void WritePhysical(MemberInfo member, object? owner, object? value)
        {
            if (member is FieldInfo field) field.SetValue(IsPhysicalStatic(member) ? null : owner, value);
            else ((PropertyInfo)member).SetValue(IsPhysicalStatic(member) ? null : owner, value);
        }
    }
}
