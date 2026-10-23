using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Methods
{
    public sealed class SourceMethodParameterDefinition
    {
        public string Name { get; }
        public int Position { get; }
        public int? ParameterRowSequence { get; }
        public int? ParameterDefinitionToken { get; }
        public ParameterAttributes Attributes { get; }
        public string TypeIdentity { get; }
        public string TypeAssemblyIdentity { get; }
        public global::Celeste.Core.Reflection.Types.SourceTypeReference TypeReference { get; }
        public bool HasDefaultValue { get; }
        public string ConstantTypeIdentity { get; }
        private readonly byte[] constantValueBlob;
        public byte[] ConstantValueBlob => (byte[])constantValueBlob.Clone();

        public object DefaultValue => HasDefaultValue
            ? SourceMetadataConstant.Decode(ConstantTypeIdentity, constantValueBlob)
            : (Attributes & ParameterAttributes.Optional) != 0
                ? Type.Missing
                : DBNull.Value;

        public SourceMethodParameterDefinition(string name, int position, int attributes, string typeIdentity,
            bool hasDefaultValue, string constantTypeIdentity, byte[] constantValueBlob,
            string typeAssemblyIdentity = null,
            global::Celeste.Core.Reflection.Types.SourceTypeReference typeReference = null,
            int? parameterRowSequence = null, int? parameterDefinitionToken = null)
        {
            Name = name;
            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position));
            if (parameterRowSequence.HasValue != parameterDefinitionToken.HasValue)
                throw new ArgumentException("Original parameter row facts must be published together.");
            if (parameterRowSequence <= 0 || parameterDefinitionToken.HasValue &&
                (parameterDefinitionToken.Value & unchecked((int)0xff000000)) != 0x08000000)
                throw new ArgumentException("Original parameter row facts are invalid.");
            Position = position;
            ParameterRowSequence = parameterRowSequence;
            ParameterDefinitionToken = parameterDefinitionToken;
            Attributes = (ParameterAttributes)attributes;
            TypeIdentity = typeIdentity ?? throw new ArgumentNullException(nameof(typeIdentity));
            TypeAssemblyIdentity = typeAssemblyIdentity;
            TypeReference = typeReference;
            HasDefaultValue = hasDefaultValue;
            ConstantTypeIdentity = constantTypeIdentity;
            this.constantValueBlob = (byte[])(constantValueBlob ?? Array.Empty<byte>()).Clone();
        }
    }
}
