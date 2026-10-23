using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceMemberDefinition
    {
        public string AssemblyIdentity { get; }
        public string DeclaringTypeIdentity { get; }
        public string QualifiedName => DeclaringTypeIdentity + "." + Name;
        public int MetadataToken { get; }
        public string Name { get; }
        public SourceMemberKind Kind { get; }
        public int Attributes { get; }
        public string ValueTypeIdentity { get; }
        public string ValueTypeAssemblyIdentity { get; }
        public global::Celeste.Core.Reflection.Types.SourceTypeReference ValueTypeReference { get; }
        public IReadOnlyList<SourceDeclaredAttribute> DeclaredAttributes { get; }
        public int GetterAttributes { get; }
        public int SetterAttributes { get; }
        public int IndexParameterCount { get; }
        public bool HasConstant { get; }
        public object ConstantValue { get; }
        public string ConstantTypeIdentity { get; }
        public string ConstantValueBlob { get; }
        public bool DeclaredOnly => true;

        public bool IsStatic => Kind == SourceMemberKind.Field
            ? ((FieldAttributes)Attributes & FieldAttributes.Static) != 0
            : ((MethodAttributes)(GetterAttributes >= 0 ? GetterAttributes : SetterAttributes)
               & MethodAttributes.Static) != 0;

        public bool IsPublic => Kind == SourceMemberKind.Field
            ? ((FieldAttributes)Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public
            : IsPublicAccessor(GetterAttributes) || IsPublicAccessor(SetterAttributes);

        public bool IsInitOnly => Kind == SourceMemberKind.Field
                                  && ((FieldAttributes)Attributes & FieldAttributes.InitOnly) != 0;

        public bool IsLiteral => Kind == SourceMemberKind.Field
                                 && ((FieldAttributes)Attributes & FieldAttributes.Literal) != 0;

        public bool CanRead => Kind == SourceMemberKind.Field || GetterAttributes >= 0;
        public bool CanWrite => Kind == SourceMemberKind.Field ? !IsLiteral : SetterAttributes >= 0;
        public string Identity => AssemblyIdentity + ":" + MetadataToken.ToString("X8");

        public SourceMemberDefinition(string assemblyIdentity, string declaringTypeIdentity,
            int metadataToken, string name, SourceMemberKind kind, int attributes,
            string valueTypeIdentity, int getterAttributes = -1, int setterAttributes = -1,
            int indexParameterCount = 0, IReadOnlyList<SourceDeclaredAttribute> declaredAttributes = null,
            bool hasConstant = false, object constantValue = null, string constantTypeIdentity = null,
            string constantValueBlob = null, string valueTypeAssemblyIdentity = null,
            global::Celeste.Core.Reflection.Types.SourceTypeReference valueTypeReference = null)
        {
            AssemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
            DeclaringTypeIdentity =
                declaringTypeIdentity ?? throw new ArgumentNullException(nameof(declaringTypeIdentity));
            MetadataToken = metadataToken;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Kind = kind;
            Attributes = attributes;
            ValueTypeIdentity = valueTypeIdentity ?? throw new ArgumentNullException(nameof(valueTypeIdentity));
            ValueTypeAssemblyIdentity = valueTypeAssemblyIdentity;
            ValueTypeReference = valueTypeReference;
            GetterAttributes = getterAttributes;
            SetterAttributes = setterAttributes;
            IndexParameterCount = indexParameterCount;
            HasConstant = hasConstant;
            ConstantValue = constantValue;
            ConstantTypeIdentity = constantTypeIdentity;
            ConstantValueBlob = constantValueBlob;
            if (declaredAttributes == null) DeclaredAttributes = Array.Empty<SourceDeclaredAttribute>();
            else
            {
                var attributesCopy = new SourceDeclaredAttribute[declaredAttributes.Count];
                for (int index = 0; index < attributesCopy.Length; index++)
                    attributesCopy[index] = declaredAttributes[index]
                                            ?? throw new ArgumentException("A declared attribute fact cannot be null.",
                                                nameof(declaredAttributes));
                DeclaredAttributes = Array.AsReadOnly(attributesCopy);
            }
        }

        public bool HasDeclaredAttribute(string attributeTypeIdentity)
        {
            foreach (var attribute in DeclaredAttributes)
                if (string.Equals(attribute.TypeIdentity, attributeTypeIdentity, StringComparison.Ordinal))
                    return true;
            return false;
        }

        private static bool IsPublicAccessor(int attributes) => attributes >= 0
                                                                && ((MethodAttributes)attributes &
                                                                    MethodAttributes.MemberAccessMask) ==
                                                                MethodAttributes.Public;
    }
}
