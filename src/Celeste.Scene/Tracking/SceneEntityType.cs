using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tracking
{
    // Original CLR identities are metadata: this registry never references a renderer or a TAS API.
    public sealed partial class SceneEntityType
    {
        public string Name { get; }
        private string logicalTypeName;

        public string LogicalTypeName => logicalTypeName ??
                                         throw new InvalidOperationException(
                                             "The logical type name metadata is not published.");

        public void ConfigureLogicalTypeName(string value)
        {
            if (logicalTypeName != null)
                throw new InvalidOperationException("The logical type name metadata is already published.");
            logicalTypeName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string LogicalAssemblyIdentity { get; private set; }
        public string LogicalAssemblySimpleName { get; private set; }

        public void ConfigureLogicalAssemblyIdentity(string identity, string simpleName)
        {
            if (LogicalAssemblyIdentity != null)
                throw new InvalidOperationException("The logical assembly metadata is already published.");
            LogicalAssemblyIdentity = identity ?? throw new ArgumentNullException(nameof(identity));
            LogicalAssemblySimpleName = simpleName ?? throw new ArgumentNullException(nameof(simpleName));
        }

        public string[] BaseTypes { get; }
        public string[] TrackedAs { get; }

        public SceneEntityType(string name, IEnumerable<string> baseTypes, IEnumerable<string> trackedAs)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BaseTypes = [.. baseTypes ?? (string[])[]];
            TrackedAs = [.. trackedAs ?? (string[])[]];
        }

        internal SceneEntityType WithTrackingMetadata(IEnumerable<string> trackedAs)
        {
            var replacement = new SceneEntityType(Name, BaseTypes, trackedAs);
            replacement.logicalTypeName = logicalTypeName;
            replacement.LogicalAssemblyIdentity = LogicalAssemblyIdentity;
            replacement.LogicalAssemblySimpleName = LogicalAssemblySimpleName;
            replacement.sourceMetadataOwner = sourceMetadataOwner;
            replacement.SelectedActualType = SelectedActualType;
            replacement.HasManagedTypeFacts = HasManagedTypeFacts;
            replacement.HasRuntimeTypeFacts = HasRuntimeTypeFacts;
            replacement.Assembly = Assembly;
            replacement.LogicalIdentity = LogicalIdentity;
            replacement.declaredTrackedAliases = declaredTrackedAliases;
            replacement.DeclaredPooledAttributeCount = DeclaredPooledAttributeCount;
            replacement.HasPublicParameterlessConstructor = HasPublicParameterlessConstructor;
            replacement.LogicalMetadataToken = LogicalMetadataToken;
            replacement.DeclaredTrackedInherited = DeclaredTrackedInherited;
            replacement.LogicalIsAbstract = LogicalIsAbstract;
            replacement.sourceCommandMethods = sourceCommandMethods;
            return replacement;
        }

        public bool Is(string name)
        {
            if (Name == name) return true;
            if (HasRuntimeTypeFacts)
            {
                var runtimeTarget = sourceMetadataOwner.Find(name);
                return runtimeTarget != null
                    ? runtimeTarget.RequireActualType().IsAssignableFrom(SelectedActualType)
                    : RuntimeHasBaseType(name);
            }

            if (sourceMetadataOwner == null) return Array.IndexOf(BaseTypes, name) >= 0;
            // BaseTypes describe the imported PE; runtime queries use registry keys.
            var target = sourceMetadataOwner.Find(name);
            return target != null && Array.IndexOf(BaseTypes, target.Identity) >= 0;
        }
    }
}
