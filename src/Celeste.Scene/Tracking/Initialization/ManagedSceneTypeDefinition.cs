using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking.Initialization
{
    public sealed class ManagedSceneTypeDefinition : ISourceTypeMetadata
    {
        private readonly Type actualType;
        private readonly bool tracked;
        private readonly bool inheritTracking;
        private ISourceAssemblyMetadata assembly;

        public ManagedSceneTypeDefinition(Type actualType, bool tracked = false, bool inheritTracking = false)
        {
            this.actualType = actualType ?? throw new ArgumentNullException(nameof(actualType));
            if (actualType.FullName == null || actualType.ContainsGenericParameters)
                throw new ArgumentException("A closed CLR type is required.", nameof(actualType));
            if (!tracked && inheritTracking)
                throw new ArgumentException("Inherited tracking requires a tracked type.", nameof(inheritTracking));
            this.tracked = tracked;
            this.inheritTracking = inheritTracking;
        }

        public string Identity => actualType.FullName;
        public string RegistryKey => Identity;
        public ISourceAssemblyMetadata Assembly => assembly;
        public string TypeName => actualType.Name;
        public bool IsAbstract => actualType.IsAbstract;
        public int DeclaredPooledAttributeCount => 0;
        public bool HasPublicParameterlessConstructor => actualType.GetConstructor(Type.EmptyTypes) != null;
        public Type RequireActualType() => actualType;

        public bool IsAssignableFrom(ISourceTypeMetadata other) =>
            actualType.IsAssignableFrom(other.RequireActualType());

        public bool HasBaseType(string identity)
        {
            for (var type = actualType.BaseType; type != null; type = type.BaseType)
                if (type.FullName == identity)
                    return true;
            return false;
        }

        public bool[] ReadDeclaredTrackedAttributes() => tracked ? new[] { inheritTracking } : Array.Empty<bool>();

        public SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes() =>
            Array.Empty<SourceTrackedAliasMetadata>();

        internal void BindAssembly(ISourceAssemblyMetadata value) => assembly = value;

        internal IEnumerable<string> BaseTypeNames()
        {
            for (var type = actualType.BaseType; type != null; type = type.BaseType) yield return type.FullName;
        }
    }
}
