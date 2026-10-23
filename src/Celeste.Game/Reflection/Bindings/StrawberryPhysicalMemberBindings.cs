using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Gameplay.Collectibles.Strawberries;

namespace Celeste.Game.Reflection.Bindings
{
    public static class StrawberryPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.Strawberry", "start", SourceMemberKind.Field);
            if (definition.IsStatic || definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2")
                throw new InvalidOperationException("The original Strawberry.start declaration differs.");
            var storage = typeof(OriginalStrawberryState).GetField("start",
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(typeof(OriginalStrawberryState).FullName, "start");
            if (storage.FieldType != typeof(Vector2))
                throw new InvalidOperationException("The actual Strawberry.start storage differs.");
            catalog.RegisterBinding(new(definition, typeof(OriginalStrawberryState),
                storage));
        }
    }
}
