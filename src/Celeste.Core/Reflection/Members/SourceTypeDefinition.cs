using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceTypeDefinition
    {
        public string AssemblyIdentity { get; }
        public string Identity { get; }
        internal string CanonicalKey { get; }
        internal string ShortName { get; }
        public int MetadataToken { get; }
        public int Attributes { get; }
        public string BaseAssemblyIdentity { get; }
        public string BaseTypeIdentity { get; }
        public global::Celeste.Core.Reflection.Types.SourceTypeReference BaseTypeReference { get; }
        public string EnumUnderlyingTypeIdentity { get; }
        public IReadOnlyList<string> Interfaces { get; }
        public IReadOnlyList<string> InterfaceAssemblyIdentities { get; }
        public IReadOnlyList<global::Celeste.Core.Reflection.Types.SourceTypeReference> InterfaceTypeReferences { get; }
        public IReadOnlyList<SourceDeclaredAttribute> DeclaredAttributes { get; }
        public IReadOnlyList<SourceGenericParameterDefinition> GenericParameters { get; }

        public SourceTypeDefinition(string assemblyIdentity, string identity, int metadataToken, int attributes,
            string baseAssemblyIdentity, string baseTypeIdentity, string[] interfaces,
            SourceDeclaredAttribute[] declaredAttributes, string enumUnderlyingTypeIdentity = null,
            string[] interfaceAssemblyIdentities = null,
            SourceGenericParameterDefinition[] genericParameters = null,
            global::Celeste.Core.Reflection.Types.SourceTypeReference baseTypeReference = null,
            global::Celeste.Core.Reflection.Types.SourceTypeReference[] interfaceTypeReferences = null)
        {
            AssemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
            CanonicalKey = assemblyIdentity + "\n" + identity;
            int split = Math.Max(identity.LastIndexOf('.'), identity.LastIndexOf('+'));
            ShortName = identity.Substring(split + 1);
            MetadataToken = metadataToken;
            Attributes = attributes;
            BaseAssemblyIdentity = baseAssemblyIdentity;
            BaseTypeIdentity = baseTypeIdentity;
            BaseTypeReference = baseTypeReference;
            EnumUnderlyingTypeIdentity = enumUnderlyingTypeIdentity;
            // Null means this fact was not published, not that the source type is nongeneric.
            GenericParameters = genericParameters == null
                ? null
                : Array.AsReadOnly((SourceGenericParameterDefinition[])genericParameters.Clone());
            if (interfaceTypeReferences != null && interfaceTypeReferences.Length != interfaces.Length)
                throw new ArgumentException("Every original interface requires its original type reference.",
                    nameof(interfaceTypeReferences));
            InterfaceTypeReferences = interfaceTypeReferences == null
                ? null
                : Array.AsReadOnly(
                    (global::Celeste.Core.Reflection.Types.SourceTypeReference[])interfaceTypeReferences.Clone());
            Interfaces =
                Array.AsReadOnly((string[])(interfaces ?? throw new ArgumentNullException(nameof(interfaces))).Clone());
            if (interfaceAssemblyIdentities != null && interfaceAssemblyIdentities.Length != interfaces.Length)
                throw new ArgumentException("Every original interface must retain its own PE assembly scope.",
                    nameof(interfaceAssemblyIdentities));
            InterfaceAssemblyIdentities = interfaceAssemblyIdentities == null
                ? null
                : Array.AsReadOnly((string[])interfaceAssemblyIdentities.Clone());
            DeclaredAttributes = Array.AsReadOnly((SourceDeclaredAttribute[])
                (declaredAttributes ?? throw new ArgumentNullException(nameof(declaredAttributes))).Clone());
        }

        public bool HasDeclaredAttribute(string attributeTypeIdentity)
        {
            foreach (var attribute in DeclaredAttributes)
                if (string.Equals(attribute.TypeIdentity, attributeTypeIdentity, StringComparison.Ordinal))
                    return true;
            return false;
        }
    }
}
