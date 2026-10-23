using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceGenericParameterDefinition(
        string name,
        int position,
        int metadataToken,
        int attributes,
        SourceDeclaredAttribute[] declaredAttributes,
        SourceGenericParameterConstraint[] constraints)
    {
        public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
        public int Position { get; } = position;
        public int MetadataToken { get; } = metadataToken;
        public int Attributes { get; } = attributes;

        public IReadOnlyList<SourceDeclaredAttribute> DeclaredAttributes { get; } = Array.AsReadOnly(
            (SourceDeclaredAttribute[])(declaredAttributes ??
                                        throw new ArgumentNullException(nameof(declaredAttributes))).Clone());

        public IReadOnlyList<SourceGenericParameterConstraint> Constraints { get; } = Array.AsReadOnly(
            (SourceGenericParameterConstraint[])(constraints ?? throw new ArgumentNullException(nameof(constraints)))
            .Clone());
    }
}
