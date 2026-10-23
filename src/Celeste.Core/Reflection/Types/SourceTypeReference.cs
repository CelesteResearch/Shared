using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Types
{
    public sealed class SourceTypeReference
    {
        public SourceTypeReferenceKind Kind { get; }
        public string AssemblyIdentity { get; }
        public string TypeIdentity { get; }
        public SourceTypeReference ElementType { get; }
        public IReadOnlyList<SourceTypeReference> GenericArguments { get; }
        public int ArrayRank { get; }
        public IReadOnlyList<SourceArrayDimension> ArrayDimensions { get; }
        public SourceTypeReference ModifierType { get; }
        public int GenericParameterPosition { get; }
        public SourceGenericParameterOwnerKind GenericParameterOwnerKind { get; }
        public string OwnerAssemblyIdentity { get; }
        public string OwnerTypeIdentity { get; }
        public int OwnerMethodDefinitionToken { get; }
        public SourceTypeReference ReturnType { get; }
        public IReadOnlyList<SourceTypeReference> ParameterTypes { get; }
        public int CallingConvention { get; }
        public bool HasThis { get; }
        public bool ExplicitThis { get; }

        public SourceTypeReference(SourceTypeReferenceKind kind,
            string assemblyIdentity = null, string typeIdentity = null,
            SourceTypeReference elementType = null, SourceTypeReference[] genericArguments = null,
            int arrayRank = 0, SourceArrayDimension[] arrayDimensions = null,
            SourceTypeReference modifierType = null, int genericParameterPosition = -1,
            SourceGenericParameterOwnerKind genericParameterOwnerKind = SourceGenericParameterOwnerKind.Type,
            string ownerAssemblyIdentity = null, string ownerTypeIdentity = null,
            int ownerMethodDefinitionToken = 0, SourceTypeReference returnType = null,
            SourceTypeReference[] parameterTypes = null, int callingConvention = 0,
            bool hasThis = false, bool explicitThis = false)
        {
            if (kind == SourceTypeReferenceKind.Named && (assemblyIdentity == null || typeIdentity == null))
                throw new ArgumentException("A named source type requires its real assembly and type identities.");
            if (kind == SourceTypeReferenceKind.GenericParameter &&
                (genericParameterPosition < 0 || ownerAssemblyIdentity == null || ownerTypeIdentity == null ||
                 (genericParameterOwnerKind == SourceGenericParameterOwnerKind.Method &&
                  ownerMethodDefinitionToken == 0)))
                throw new ArgumentException(
                    "A source generic parameter requires its real position and owner identity.");
            if (kind == SourceTypeReferenceKind.Array &&
                (arrayRank <= 0 || arrayDimensions == null || arrayDimensions.Length != arrayRank))
                throw new ArgumentException("An array source type requires its original rank and dimensions.");
            if (kind != SourceTypeReferenceKind.Named && kind != SourceTypeReferenceKind.GenericParameter &&
                kind != SourceTypeReferenceKind.FunctionPointer && elementType == null)
                throw new ArgumentException("A source type specification requires its real element type.");
            if ((kind == SourceTypeReferenceKind.RequiredModifier ||
                 kind == SourceTypeReferenceKind.OptionalModifier) &&
                modifierType == null)
                throw new ArgumentException("A modified source type requires its real modifier type.");
            if (kind == SourceTypeReferenceKind.FunctionPointer && returnType == null)
                throw new ArgumentException("A source function pointer requires its real return type.");
            Kind = kind;
            AssemblyIdentity = assemblyIdentity;
            TypeIdentity = typeIdentity;
            ElementType = elementType;
            GenericArguments =
                Array.AsReadOnly(
                    (SourceTypeReference[])(genericArguments ?? []).Clone());
            ArrayRank = arrayRank;
            ArrayDimensions =
                Array.AsReadOnly(
                    (SourceArrayDimension[])(arrayDimensions ?? []).Clone());
            ModifierType = modifierType;
            GenericParameterPosition = genericParameterPosition;
            GenericParameterOwnerKind = genericParameterOwnerKind;
            OwnerAssemblyIdentity = ownerAssemblyIdentity;
            OwnerTypeIdentity = ownerTypeIdentity;
            OwnerMethodDefinitionToken = ownerMethodDefinitionToken;
            ReturnType = returnType;
            ParameterTypes =
                Array.AsReadOnly((SourceTypeReference[])(parameterTypes ?? []).Clone());
            CallingConvention = callingConvention;
            HasThis = hasThis;
            ExplicitThis = explicitThis;
        }
    }
}
