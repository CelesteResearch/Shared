using System;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceGenericParameterConstraint(
        string typeIdentity,
        string assemblyIdentity,
        SourceTypeReference typeReference = null)
    {
        public string TypeIdentity { get; }
            = typeIdentity ?? throw new ArgumentNullException(nameof(typeIdentity));

        public string AssemblyIdentity { get; }
            = assemblyIdentity;

        public SourceTypeReference TypeReference { get; }
            = typeReference;
    }
}
