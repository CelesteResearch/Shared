using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;

namespace Celeste.Game.Reflection.Bindings
{
    public static class CrushBlockPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition =
                catalog.RequireDefinition(assembly, "Celeste.CrushBlock", "crushDir", SourceMemberKind.Field);
            if (definition.IsStatic || definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2")
                throw new InvalidOperationException("The original CrushBlock vector declaration differs.");
            var owner = catalog.GetActualSourceType(assembly, "Celeste.CrushBlock");
            if (owner == null || !typeof(OriginalCrushBlockState).IsAssignableFrom(owner))
                throw new InvalidOperationException("The actual CrushBlock owner does not use its source storage.");
            var storage = typeof(OriginalCrushBlockState).GetField("crushDir",
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(typeof(OriginalCrushBlockState).FullName, "crushDir");
            if (storage.FieldType != typeof(Vector2) || !storage.IsPrivate || storage.IsStatic || storage.IsInitOnly)
                throw new InvalidOperationException("The actual CrushBlock vector storage differs.");
            catalog.RegisterBinding(new(definition, owner, storage));
        }
    }
}
