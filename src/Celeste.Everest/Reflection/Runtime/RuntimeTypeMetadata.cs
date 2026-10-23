using System;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking.Attributes;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Everest.Tracking.Attributes;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeTypeMetadata : ISourceTypeMetadata, ISourceCommandTypeMetadata
    {
        private readonly ManagedSceneTypeDefinition definition;
        private readonly ISourceCommandMethodMetadata[] methods;
        internal readonly EverestTrackedAsAttribute[] TrackedAs;

        public RuntimeTypeMetadata(Type type, ISourceAssemblyMetadata assembly)
        {
            var tracked = type.GetCustomAttribute<SceneTrackedAttribute>(false);
            definition = new ManagedSceneTypeDefinition(type, tracked != null, tracked?.Inherited ?? false);
            Assembly = assembly;
            TrackedAs = type.GetCustomAttributes<EverestTrackedAsAttribute>(false).ToArray();
            methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
                                      BindingFlags.DeclaredOnly)
                .Select(method => (ISourceCommandMethodMetadata)new RuntimeCommandMethodMetadata(method)).ToArray();
        }

        public string Identity => definition.RequireActualType().AssemblyQualifiedName;
        public string RegistryKey => Identity;
        public ISourceAssemblyMetadata Assembly { get; }
        public string TypeName => definition.TypeName;
        public bool IsAbstract => definition.IsAbstract;
        public int DeclaredPooledAttributeCount => definition.DeclaredPooledAttributeCount;
        public bool HasPublicParameterlessConstructor => definition.HasPublicParameterlessConstructor;
        public Type RequireActualType() => definition.RequireActualType();
        public bool IsAssignableFrom(ISourceTypeMetadata other) => definition.IsAssignableFrom(other);
        public bool HasBaseType(string identity) => definition.HasBaseType(identity);
        public bool[] ReadDeclaredTrackedAttributes() => definition.ReadDeclaredTrackedAttributes();

        public SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes() => TrackedAs.Select(attribute =>
            new SourceTrackedAliasMetadata(attribute.TrackedAs.AssemblyQualifiedName, attribute.Inherited)).ToArray();

        public ISourceCommandMethodMetadata[] GetDeclaredStaticMethods() =>
            (ISourceCommandMethodMetadata[])methods.Clone();
    }
}
