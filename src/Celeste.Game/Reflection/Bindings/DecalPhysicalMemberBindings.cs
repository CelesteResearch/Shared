using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Game.Reflection.Bindings
{
    public static class DecalPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            foreach (var definition in members.GetOriginalMemberDefinitions(typeof(OriginalDecalEntity), true))
                if (definition.Kind is SourceMemberKind.Field or SourceMemberKind.Property)
                    RegisterMember(members, definition);
        }

        private static void RegisterMember(SourceMemberCatalog members, SourceMemberDefinition definition)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static |
                                       BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            MemberInfo storage = definition.Name switch
            {
                "Root" or "MirrorMaskRoot" or "DepthSetByPlacement" or "ParallaxSetByPlacement" =>
                    typeof(OriginalDecalEntity).GetField(definition.Name, flags),
                "image" or "Image" => typeof(SourceDecalEntityState).GetProperty(nameof(SourceDecalEntityState.Image),
                    flags),
                "textures" =>
                    typeof(SourceDecalEntityState).GetProperty(nameof(SourceDecalEntityState.Textures), flags),
                "staticMover" => typeof(SourceDecalEntityState).GetProperty(nameof(SourceDecalEntityState.StaticMover),
                    flags),
                _ => typeof(SourceDecalEntityState).GetField(definition.Name switch
                {
                    "scale" => nameof(SourceDecalEntityState.Scale),
                    "frame" => nameof(SourceDecalEntityState.Frame),
                    "animated" => nameof(SourceDecalEntityState.Animated),
                    "parallax" => nameof(SourceDecalEntityState.Parallax),
                    "parallaxAmount" => nameof(SourceDecalEntityState.ParallaxAmount),
                    "scaredAnimal" => nameof(SourceDecalEntityState.ScaredAnimal),
                    "wave" => nameof(SourceDecalEntityState.Wave),
                    _ => definition.Name,
                }, flags),
            };
            if (storage == null)
                throw new MissingFieldException(typeof(OriginalDecalEntity).FullName, definition.Name);
            if (storage is FieldInfo field &&
                (definition.IsStatic != field.IsStatic || definition.IsLiteral != field.IsLiteral))
                throw new InvalidOperationException(
                    "Decal source field differs from actual storage: " + definition.Name);
            members.RegisterBinding(new(definition, typeof(OriginalDecalEntity), storage));
        }
    }
}
