using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Types
{
    public sealed class SourceTypeReferenceResolver(SourceMemberCatalog members)
    {
        private readonly SourceMemberCatalog _members = members ?? throw new ArgumentNullException(nameof(members));

        public Type Resolve(SourceTypeReference reference,
            ISourceGenericParameterTypeResolution genericParameters = null)
        {
            if (reference == null)
                throw new ArgumentNullException(nameof(reference));
            switch (reference.Kind)
            {
                case SourceTypeReferenceKind.Named:
                    return _members.GetActualSourceType(reference.AssemblyIdentity, reference.TypeIdentity);
                case SourceTypeReferenceKind.SzArray:
                    return Resolve(reference.ElementType, genericParameters).MakeArrayType();
                case SourceTypeReferenceKind.Array:
                    return Resolve(reference.ElementType, genericParameters).MakeArrayType(reference.ArrayRank);
                case SourceTypeReferenceKind.ByReference:
                    return Resolve(reference.ElementType, genericParameters).MakeByRefType();
                case SourceTypeReferenceKind.Pointer:
                    return Resolve(reference.ElementType, genericParameters).MakePointerType();
                case SourceTypeReferenceKind.GenericInstance:
                    var actualDefinition = Resolve(reference.ElementType, genericParameters);
                    var arguments = new Type[reference.GenericArguments.Count];
                    for (var i = 0; i < arguments.Length; i++)
                        arguments[i] = Resolve(reference.GenericArguments[i], genericParameters);
                    return actualDefinition.MakeGenericType(arguments);
                case SourceTypeReferenceKind.GenericParameter:
                    if (genericParameters == null)
                        throw new InvalidOperationException(
                            "A source generic parameter requires its qualified original owner context.");
                    return genericParameters.GetActualGenericParameterType(reference) ??
                           throw new InvalidOperationException(
                               "The source generic parameter has no qualified actual type.");
                case SourceTypeReferenceKind.RequiredModifier:
                case SourceTypeReferenceKind.OptionalModifier:
                case SourceTypeReferenceKind.Pinned:
                case SourceTypeReferenceKind.Sentinel:
                    // ParameterType/FieldType expose the underlying type; modifiers remain in the source reference facts.
                    return Resolve(reference.ElementType, genericParameters);
                case SourceTypeReferenceKind.FunctionPointer:
                    throw new NotSupportedException(
                        "The current physical runtime cannot construct a qualified function pointer Type from its source signature.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(reference));
            }
        }
    }
}
