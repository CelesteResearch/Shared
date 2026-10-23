using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Entities.Npcs;

namespace Celeste.Everest.Reflection.Bindings
{
    public static class CustomNpcPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            Bind(catalog, "scale");
            Bind(catalog, "indicatorOffset");
        }

        private static void Bind(SourceMemberCatalog catalog, string name)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.Mod.Entities.CustomNPC", name,
                SourceMemberKind.Field);
            if (definition.IsStatic || definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2")
                throw new InvalidOperationException("The original CustomNPC vector declaration differs: " + name);
            var storage = typeof(EverestCustomNpcState).GetField(name,
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(typeof(EverestCustomNpcState).FullName, name);
            if (storage.FieldType != typeof(Vector2))
                throw new InvalidOperationException("The actual CustomNPC vector storage differs: " + name);
            catalog.RegisterBinding(new(definition, typeof(EverestCustomNpcState),
                storage));
        }
    }
}
