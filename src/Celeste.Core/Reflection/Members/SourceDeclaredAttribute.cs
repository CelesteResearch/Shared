using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceDeclaredAttribute
    {
        public string TypeIdentity { get; }
        public string ConstructorIdentity { get; }
        public IReadOnlyList<byte> ValueBlob { get; }

        public SourceDeclaredAttribute(string typeIdentity, string constructorIdentity, byte[] valueBlob)
        {
            TypeIdentity = typeIdentity ?? throw new ArgumentNullException(nameof(typeIdentity));
            ConstructorIdentity = constructorIdentity ?? throw new ArgumentNullException(nameof(constructorIdentity));
            if (valueBlob == null) throw new ArgumentNullException(nameof(valueBlob));
            ValueBlob = Array.AsReadOnly((byte[])valueBlob.Clone());
        }
    }
}
