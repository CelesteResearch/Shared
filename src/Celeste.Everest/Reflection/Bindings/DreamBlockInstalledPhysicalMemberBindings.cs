using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Gameplay.Platforms.Dream;

namespace Celeste.Everest.Reflection.Bindings
{
    public static class DreamBlockInstalledPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var owner = typeof(EverestDreamBlockState);
            var fieldDefinition = catalog.RequireDefinition(assembly, "Celeste.DreamBlock",
                "<movementCounter>k__BackingField", SourceMemberKind.Field);
            var propertyDefinition = catalog.RequireDefinition(assembly, "Celeste.DreamBlock",
                "movementCounter", SourceMemberKind.Property);
            var field = owner.GetField("<movementCounter>k__BackingField",
                            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                        ?? throw new MissingFieldException(owner.FullName, "<movementCounter>k__BackingField");
            var property = owner.GetProperty("movementCounter",
                               BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                           ?? throw new MissingMemberException(owner.FullName, "movementCounter");
            if (fieldDefinition.IsStatic || fieldDefinition.IsPublic || !fieldDefinition.IsInitOnly
                || !fieldDefinition.CanRead || !fieldDefinition.CanWrite
                || fieldDefinition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2"
                || !field.IsPrivate || !field.IsInitOnly || field.IsStatic || field.FieldType != typeof(Vector2)
                || propertyDefinition.IsStatic || propertyDefinition.IsPublic || !propertyDefinition.CanRead
                || propertyDefinition.CanWrite ||
                propertyDefinition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2"
                || property.PropertyType != typeof(Vector2) || property.GetMethod == null
                || !property.GetMethod.IsAssembly || property.GetMethod.IsStatic || property.GetSetMethod(true) != null)
                throw new InvalidOperationException("The installed DreamBlock counter declaration differs.");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(fieldDefinition, owner, field));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(propertyDefinition, owner, property));
        }
    }
}
