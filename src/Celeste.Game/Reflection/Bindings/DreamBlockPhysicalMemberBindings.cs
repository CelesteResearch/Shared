using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Entities.Platforms.Dream;

namespace Celeste.Game.Reflection.Bindings
{
    public static class DreamBlockPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition =
                catalog.RequireDefinition(assembly, "Celeste.DreamBlock", "shake", SourceMemberKind.Field);
            if (definition.IsStatic || definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2")
                throw new InvalidOperationException("The original DreamBlock vector declaration differs.");
            var owner = catalog.GetActualSourceType(assembly, "Celeste.DreamBlock");
            if (owner == null || !typeof(OriginalDreamBlockState).IsAssignableFrom(owner))
                throw new InvalidOperationException("The actual DreamBlock owner does not use its source storage.");
            var storage = typeof(OriginalDreamBlockState).GetField("shake",
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(typeof(OriginalDreamBlockState).FullName, "shake");
            if (storage.FieldType != typeof(Vector2) || !storage.IsPrivate || storage.IsStatic || storage.IsInitOnly)
                throw new InvalidOperationException("The actual DreamBlock vector storage differs.");
            catalog.RegisterBinding(new(definition, owner, storage));
        }
    }
}
