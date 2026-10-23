using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Interop
{
    public sealed class SourceModInteropTypeBinding
    {
        public Type ActualType { get; }
        public string OriginalAssemblySimpleName { get; }
        public IReadOnlyList<SourceDeclaredAttribute> DeclaredAttributes { get; }
        public IReadOnlyList<SourcePhysicalMemberBinding> Fields { get; }

        public IReadOnlyList<SourceModInteropMethodBinding> Methods { get; }

        // Arrays are the complete original public-static reflection selections in source order,
        // supplied by the actual PE facts and same-process physical bindings, never port reflection.
        public SourceModInteropTypeBinding(SourceTypeDefinition originalType, Type actualType,
            IReadOnlyList<SourceDeclaredAttribute> declaredAttributes, SourcePhysicalMemberBinding[] fields,
            SourceModInteropMethodBinding[] methods)
        {
            if (originalType == null) throw new ArgumentNullException(nameof(originalType));
            ActualType = actualType ?? throw new ArgumentNullException(nameof(actualType));
            OriginalAssemblySimpleName = new AssemblyName(originalType.AssemblyIdentity).Name;
            var attributes = new SourceDeclaredAttribute[declaredAttributes.Count];
            for (int index = 0; index < attributes.Length; index++) attributes[index] = declaredAttributes[index];
            DeclaredAttributes = Array.AsReadOnly(attributes);
            foreach (var field in fields)
                if (field.OriginalKind != SourceMemberKind.Field || !field.IsPublic || !field.IsStatic)
                    throw new ArgumentException(
                        "Original ModInterop reflection selection must contain only public static fields.",
                        nameof(fields));
            Fields = Array.AsReadOnly((SourcePhysicalMemberBinding[])fields.Clone());
            Methods = Array.AsReadOnly((SourceModInteropMethodBinding[])methods.Clone());
        }

        internal string GetExportName()
        {
            string name = OriginalAssemblySimpleName;
            foreach (var attribute in DeclaredAttributes)
                if (attribute.TypeIdentity == SourceModInteropAttributeData.ExportAttributeIdentity)
                    name = SourceModInteropAttributeData.ReadName(attribute);
            return name;
        }

        internal string GetModImportName(SourcePhysicalMemberBinding field)
        {
            foreach (var attribute in field.Definition.DeclaredAttributes)
                if (attribute.TypeIdentity == SourceModInteropAttributeData.ImportAttributeIdentity)
                    return SourceModInteropAttributeData.ReadName(attribute);
            foreach (var attribute in DeclaredAttributes)
                if (attribute.TypeIdentity == SourceModInteropAttributeData.ImportAttributeIdentity)
                    return SourceModInteropAttributeData.ReadName(attribute) + "." + field.Name;
            return field.Name;
        }
    }
}
