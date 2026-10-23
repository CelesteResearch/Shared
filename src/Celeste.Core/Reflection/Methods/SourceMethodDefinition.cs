using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Methods
{
    public sealed class SourceMethodDefinition
    {
        public string AssemblyIdentity { get; }
        public string DeclaringType { get; }
        public int TypeDefinitionToken { get; }
        public int MethodDefinitionToken { get; }
        public string Name { get; }
        public int Attributes { get; }
        public string SignatureBlob { get; }
        public string ReturnTypeIdentity { get; }
        public string ReturnTypeAssemblyIdentity { get; }
        public SourceTypeReference ReturnTypeReference { get; }
        public IReadOnlyList<string> ParameterTypeIdentities { get; }
        public int GenericParameterCount { get; }
        public bool? HasBody { get; }
        public int? BodyInstructionCount { get; }
        public int? BodyCodeSize { get; }
        public IReadOnlyList<SourceMethodParameterDefinition> Parameters { get; }

        private readonly Dictionary<string, List<string>> _customAttributes;

        public SourceMethodDefinition(string assemblyIdentity, string declaringType, int typeToken, int methodToken,
            string name, int attributes, string signatureBlob,
            IEnumerable<KeyValuePair<string, string>> customAttributeBlobs, string returnTypeIdentity = null,
            string[] parameterTypeIdentities = null, int genericParameterCount = 0,
            SourceMethodParameterDefinition[] parameterDefinitions = null, string returnTypeAssemblyIdentity = null,
            SourceTypeReference returnTypeReference = null, bool? hasBody = null, int? bodyInstructionCount = null,
            int? bodyCodeSize = null)
        {
            AssemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
            DeclaringType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            if ((typeToken & unchecked((int)0xff000000)) != 0x02000000)
                throw new ArgumentOutOfRangeException(nameof(typeToken));
            if ((methodToken & unchecked((int)0xff000000)) != 0x06000000)
                throw new ArgumentOutOfRangeException(nameof(methodToken));
            TypeDefinitionToken = typeToken;
            MethodDefinitionToken = methodToken;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attributes = attributes;
            SignatureBlob = signatureBlob ?? throw new ArgumentNullException(nameof(signatureBlob));
            ReturnTypeIdentity = returnTypeIdentity;
            ReturnTypeAssemblyIdentity = returnTypeAssemblyIdentity;
            ReturnTypeReference = returnTypeReference;
            ParameterTypeIdentities = parameterTypeIdentities == null
                ? null
                : Array.AsReadOnly((string[])parameterTypeIdentities.Clone());
            GenericParameterCount = genericParameterCount;
            if (hasBody.HasValue != bodyInstructionCount.HasValue || hasBody.HasValue != bodyCodeSize.HasValue)
                throw new ArgumentException("Original method body facts must be published together.");
            if (bodyInstructionCount < 0 || bodyCodeSize < 0 ||
                (hasBody == false && (bodyInstructionCount != 0 || bodyCodeSize != 0)))
                throw new ArgumentException("Original method body facts are inconsistent.");
            HasBody = hasBody;
            BodyInstructionCount = bodyInstructionCount;
            BodyCodeSize = bodyCodeSize;
            Parameters = parameterDefinitions == null
                ? null
                : Array.AsReadOnly((SourceMethodParameterDefinition[])parameterDefinitions.Clone());
            _customAttributes = new(StringComparer.Ordinal);
            foreach (var entry in customAttributeBlobs)
            {
                if (!_customAttributes.TryGetValue(entry.Key, out var blobs))
                    _customAttributes.Add(entry.Key, blobs = []);
                blobs.Add(entry.Value);
            }
        }

        public bool HasDeclaredAttribute(string originalAttributeIdentity)
        {
            return _customAttributes.ContainsKey(originalAttributeIdentity);
        }

        public string RequireDeclaredAttributeBlob(string originalAttributeIdentity)
        {
            if (!_customAttributes.TryGetValue(originalAttributeIdentity, out var blobs))
                throw new InvalidOperationException("The original method does not declare this attribute.");
            if (blobs.Count != 1)
                throw new AmbiguousMatchException();
            return blobs[0];
        }
    }
}
