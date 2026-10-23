using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;

namespace Celeste.Game.Reflection.Bindings
{
    public static class FallingBlockPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var owner = typeof(OriginalFallingBlockState);
            foreach (var name in new[]
                     {
                         "Triggered", "FallDelay", "TileType", "tiles", "highlight", "finalBoss",
                         "climbFall", "<HasStartedFalling>k__BackingField"
                     })
            {
                var definition =
                    members.RequireDefinition(assembly, "Celeste.FallingBlock", name, SourceMemberKind.Field);
                var field = typeof(FallingBlockState).GetField(name,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.DeclaredOnly)
                            ?? throw new MissingFieldException(typeof(FallingBlockState).FullName, name);
                if (definition.IsStatic || field.IsStatic || !definition.CanRead)
                    throw new InvalidOperationException("Falling block source field storage differs: " + name);
                members.RegisterBinding(new SourcePhysicalMemberBinding(definition, owner, field));
            }

            var started = members.RequireDefinition(assembly, "Celeste.FallingBlock", "HasStartedFalling",
                SourceMemberKind.Property);
            var property = typeof(FallingBlockState).GetProperty("HasStartedFalling",
                               BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                           ?? throw new MissingMemberException(typeof(FallingBlockState).FullName, "HasStartedFalling");
            if (started.IsStatic || started.ValueTypeIdentity != "System.Boolean" ||
                property.PropertyType != typeof(bool)
                || !property.GetMethod.IsPublic || property.GetSetMethod(true) == null ||
                !property.GetSetMethod(true).IsFamily)
                throw new InvalidOperationException(
                    "Falling block source started property differs from its actual storage.");
            members.RegisterBinding(new SourcePhysicalMemberBinding(started, owner, property));
        }
    }
}
