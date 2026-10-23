using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Components;
using Celeste.Core.Reflection;
using Celeste.Scene.Entities;

namespace Celeste.Scene.Tracking.Initialization
{
    public sealed class ManagedSceneTypeUniverse : ISourceTrackerTypeUniverse
    {
        private readonly ManagedSceneTypeDefinition[] definitions;

        public ManagedSceneTypeUniverse(IEnumerable<ManagedSceneTypeDefinition> definitions)
        {
            if (definitions == null) throw new ArgumentNullException(nameof(definitions));
            var types = definitions.ToList();
            AddRoot(types, typeof(SceneEntityState));
            AddRoot(types, typeof(SourceComponentState));
            this.definitions = [.. types];
            var names = new HashSet<string>(StringComparer.Ordinal);
            foreach (var definition in this.definitions)
            {
                if (definition == null || !names.Add(definition.Identity))
                    throw new ArgumentException("Scene type names must be distinct.", nameof(definitions));
                if (!typeof(SceneEntityState).IsAssignableFrom(definition.RequireActualType()) &&
                    !typeof(SourceComponentState).IsAssignableFrom(definition.RequireActualType()))
                    throw new ArgumentException("A scene type must derive from Entity or Component.",
                        nameof(definitions));
            }

            foreach (var group in this.definitions.GroupBy(type => type.RequireActualType().Assembly))
            {
                var assembly =
                    new ManagedSceneAssemblyMetadata(group.Key.FullName, (ManagedSceneTypeDefinition[])[.. group]);
                foreach (var type in group) type.BindAssembly(assembly);
            }
        }

        private static void AddRoot(List<ManagedSceneTypeDefinition> definitions, Type root)
        {
            if (!definitions.Any(type => type != null && type.RequireActualType() == root))
                definitions.Add(new(root));
        }

        public ISourceTypeMetadata EntityType =>
            definitions.First(type => type.RequireActualType() == typeof(SceneEntityState));

        public ISourceTypeMetadata ComponentType =>
            definitions.First(type => type.RequireActualType() == typeof(SourceComponentState));

        public ISourceTypeMetadata[] GetTypes()
        {
            return (ISourceTypeMetadata[])definitions.Clone();
        }
    }
}
