using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceLevelPublicMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            Bind(catalog, "Bloom", SourceMemberKind.Field, "Celeste.BloomRenderer");
            Bind(catalog, "Lighting", SourceMemberKind.Field, "Celeste.LightingRenderer");
            Bind(catalog, "Displacement", SourceMemberKind.Field, "Celeste.DisplacementRenderer");
            Bind(catalog, "CameraOffset", SourceMemberKind.Field, "Microsoft.Xna.Framework.Vector2");
            Bind(catalog, "BaseLightingAlpha", SourceMemberKind.Field, "System.Single");
            Bind(catalog, "InCutscene", SourceMemberKind.Field, "System.Boolean");
            Bind(catalog, "CanRetry", SourceMemberKind.Field, "System.Boolean");
            Bind(catalog, "SaveQuitDisabled", SourceMemberKind.Field, "System.Boolean");
            Bind(catalog, "PauseLock", SourceMemberKind.Field, "System.Boolean");
            Bind(catalog, "LevelOffset", SourceMemberKind.Property, "Microsoft.Xna.Framework.Vector2");
        }

        private static void Bind(SourceMemberCatalog catalog, string name, SourceMemberKind kind, string valueType)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.Level", name, kind);
            if (definition.IsStatic || !definition.IsPublic || !definition.CanRead
                || definition.ValueTypeIdentity != valueType || definition.CanWrite != (kind == SourceMemberKind.Field))
                throw new InvalidOperationException("The original Level declaration differs from its actual storage: " +
                                                    name);
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            MemberInfo storage = typeof(OriginalLevelSceneRoot).GetField(name, flags);
            if (storage == null) storage = typeof(OriginalLevelSceneRoot).GetProperty(name, flags);
            if (storage == null) throw new MissingMemberException(typeof(OriginalLevelSceneRoot).FullName, name);
            catalog.RegisterBinding(
                new(definition, typeof(OriginalLevelSceneRoot), storage));
        }
    }
}
