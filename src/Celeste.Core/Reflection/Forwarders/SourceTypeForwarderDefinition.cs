using System;

namespace Celeste.Core.Reflection.Forwarders
{
    public sealed class SourceTypeForwarderDefinition
    {
        public string SourceProfile { get; }
        public string AssemblyIdentity { get; }
        public string SourcePeSha256 { get; }
        public Guid ModuleMvid { get; }
        public int ExportedTypeToken { get; }
        public string TypeIdentity { get; }
        public uint Attributes { get; }
        public bool IsForwarder { get; }
        public string ScopeKind { get; }
        public string TargetAssemblyIdentity { get; }
        public string TargetTypeIdentity { get; }
        public int? DeclaringExportedTypeToken { get; }
        public int Identifier { get; }

        public SourceTypeForwarderDefinition(string sourceProfile, string assemblyIdentity, string sourcePeSha256,
            Guid moduleMvid, int exportedTypeToken, string typeIdentity, uint attributes, bool isForwarder,
            string scopeKind, string targetAssemblyIdentity, string targetTypeIdentity,
            int? declaringExportedTypeToken = null, int identifier = 0)
        {
            if ((exportedTypeToken & unchecked((int)0xff000000)) != 0x27000000)
                throw new ArgumentException("A forwarder requires its actual ExportedType row token.");
            if (isForwarder != ((attributes & 0x00200000u) != 0))
                throw new ArgumentException("The forwarded-type flag must match the true raw ExportedType flags.");
            SourceProfile = sourceProfile ?? throw new ArgumentNullException(nameof(sourceProfile));
            AssemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
            SourcePeSha256 = sourcePeSha256 ?? throw new ArgumentNullException(nameof(sourcePeSha256));
            ModuleMvid = moduleMvid;
            ExportedTypeToken = exportedTypeToken;
            TypeIdentity = typeIdentity ?? throw new ArgumentNullException(nameof(typeIdentity));
            Attributes = attributes;
            IsForwarder = isForwarder;
            ScopeKind = scopeKind ?? throw new ArgumentNullException(nameof(scopeKind));
            TargetAssemblyIdentity =
                targetAssemblyIdentity ?? throw new ArgumentNullException(nameof(targetAssemblyIdentity));
            TargetTypeIdentity = targetTypeIdentity ?? throw new ArgumentNullException(nameof(targetTypeIdentity));
            DeclaringExportedTypeToken = declaringExportedTypeToken;
            Identifier = identifier;
        }
    }
}
