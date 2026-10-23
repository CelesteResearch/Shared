using System;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceGenericParameterConstraint
    {
        public string TypeIdentity { get; }
        public string AssemblyIdentity { get; }
        public global::Celeste.Core.Reflection.Types.SourceTypeReference TypeReference { get; }

        public SourceGenericParameterConstraint(string typeIdentity, string assemblyIdentity,
            global::Celeste.Core.Reflection.Types.SourceTypeReference typeReference = null)
        {
            TypeIdentity = typeIdentity ?? throw new ArgumentNullException(nameof(typeIdentity));
            AssemblyIdentity = assemblyIdentity;
            TypeReference = typeReference;
        }
    }
}
