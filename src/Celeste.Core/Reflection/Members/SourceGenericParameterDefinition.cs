using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceGenericParameterDefinition
    {
        public string Name { get; }
        public int Position { get; }
        public int MetadataToken { get; }
        public int Attributes { get; }
        public IReadOnlyList<SourceDeclaredAttribute> DeclaredAttributes { get; }
        public IReadOnlyList<SourceGenericParameterConstraint> Constraints { get; }

        public SourceGenericParameterDefinition(string name, int position, int metadataToken, int attributes,
            SourceDeclaredAttribute[] declaredAttributes, SourceGenericParameterConstraint[] constraints)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Position = position;
            MetadataToken = metadataToken;
            Attributes = attributes;
            DeclaredAttributes = Array.AsReadOnly((SourceDeclaredAttribute[])
                (declaredAttributes ?? throw new ArgumentNullException(nameof(declaredAttributes))).Clone());
            Constraints = Array.AsReadOnly((SourceGenericParameterConstraint[])
                (constraints ?? throw new ArgumentNullException(nameof(constraints))).Clone());
        }
    }
}
