using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Reflection.Bindings
{
    public static class TextMenuPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var menuOwner = members.GetActualSourceType(assembly, "Celeste.TextMenu");
            var itemOwner = members.GetActualSourceType(assembly, "Celeste.TextMenu+Item");
            if (menuOwner != typeof(TextMenuPresentation) || itemOwner != typeof(TextMenuPresentation.Item))
                throw new InvalidOperationException(
                    "The text menu physical owners differ from their shared implementations.");
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var current = members.RequireDefinition(assembly, "Celeste.TextMenu", "Current", SourceMemberKind.Property);
            var property = typeof(TextMenuPresentation).GetProperty("Current", flags)
                           ?? throw new MissingMemberException(typeof(TextMenuPresentation).FullName, "Current");
            if (current.IsStatic || !current.IsPublic || !current.CanRead || !current.CanWrite ||
                current.IndexParameterCount != 0 || current.ValueTypeIdentity != "Celeste.TextMenu+Item" ||
                property.PropertyType != typeof(TextMenuPresentation.Item) || !property.CanRead || !property.CanWrite)
                throw new InvalidOperationException(
                    "The original TextMenu.Current differs from its physical property.");
            members.RegisterBinding(new SourcePhysicalMemberBinding(current, menuOwner, property));
            var pressed =
                members.RequireDefinition(assembly, "Celeste.TextMenu+Item", "OnPressed", SourceMemberKind.Field);
            var field = typeof(TextMenuPresentation.Item).GetField("OnPressed", flags)
                        ?? throw new MissingFieldException(typeof(TextMenuPresentation.Item).FullName, "OnPressed");
            if (pressed.IsStatic || !pressed.IsPublic || !pressed.CanRead || !pressed.CanWrite ||
                pressed.ValueTypeIdentity != "System.Action" || field.FieldType != typeof(Action) || field.IsStatic)
                throw new InvalidOperationException(
                    "The original TextMenu.Item.OnPressed differs from its physical field.");
            members.RegisterBinding(new SourcePhysicalMemberBinding(pressed, itemOwner, field));
        }
    }
}
