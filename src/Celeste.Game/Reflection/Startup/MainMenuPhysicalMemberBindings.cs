using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.UI.Menus.Buttons.Title;

namespace Celeste.Game.Reflection.Startup
{
    public static class MainMenuPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var buttonOwner = members.GetActualSourceType(assembly, "Celeste.MenuButton");
            var menuOwner = members.GetActualSourceType(assembly, "Celeste.OuiMainMenu");
            if (buttonOwner != typeof(MenuButtonPresentation) || !typeof(MainMenuSequence).IsAssignableFrom(menuOwner))
                throw new InvalidOperationException(
                    "The selected menu physical owners differ from their genuine shared implementations.");
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                       BindingFlags.DeclaredOnly;
            foreach (var name in new[]
                     {
                         "LeftButton", "RightButton", "UpButton", "DownButton", "OnConfirm", "selected",
                         "canAcceptInput", "oui",
                     })
            {
                var actualValueType = name == "OnConfirm" ? typeof(Action)
                    : name == "selected" || name == "canAcceptInput" ? typeof(bool)
                    : name == "oui" ? typeof(OuiState) : typeof(MenuButtonPresentation);
                var originalValueType = name == "OnConfirm" ? "System.Action"
                    : actualValueType == typeof(bool) ? "System.Boolean"
                    : name == "oui" ? "Celeste.Oui" : "Celeste.MenuButton";
                BindField(members, assembly, "Celeste.MenuButton", buttonOwner, typeof(MenuButtonPresentation), name,
                    actualValueType, originalValueType);
            }

            var selected =
                members.RequireDefinition(assembly, "Celeste.MenuButton", "Selected", SourceMemberKind.Property);
            var property = typeof(MenuButtonPresentation).GetProperty("Selected", flags)
                           ?? throw new MissingMemberException(typeof(MenuButtonPresentation).FullName, "Selected");
            if (selected.IsStatic || !selected.IsPublic || !selected.CanRead || !selected.CanWrite ||
                selected.IndexParameterCount != 0 || selected.ValueTypeIdentity != "System.Boolean" ||
                property.PropertyType != typeof(bool))
                throw new InvalidOperationException(
                    "The original MenuButton.Selected declaration differs from its actual property.");
            members.RegisterBinding(new(selected, buttonOwner, property));
            BindField(members, assembly, "Celeste.OuiMainMenu", menuOwner, typeof(MainMenuSequence), "climbButton",
                typeof(MainMenuClimbPresentation), "Celeste.MainMenuClimb");
            var buttons = members.RequireDefinition(assembly, "Celeste.OuiMainMenu", "buttons", SourceMemberKind.Field);
            var buttonsField = typeof(MainMenuSequence).GetField("buttons", flags)
                               ?? throw new MissingFieldException(typeof(MainMenuSequence).FullName, "buttons");
            if (buttons.IsStatic || buttons.IsPublic || !buttons.CanRead || !buttons.CanWrite ||
                !buttons.ValueTypeIdentity.StartsWith("System.Collections.Generic.List", StringComparison.Ordinal) ||
                !buttons.ValueTypeIdentity.Contains("Celeste.MenuButton") ||
                buttonsField.FieldType != typeof(List<MenuButtonPresentation>))
                throw new InvalidOperationException(
                    "The original OuiMainMenu.buttons declaration differs from its actual list field.");
            members.RegisterBinding(new(buttons, menuOwner, buttonsField));
        }

        private static void BindField(SourceMemberCatalog members, string assembly, string originalOwner,
            Type actualOwner,
            Type declaringType, string name, Type actualValueType, string originalValueType)
        {
            var definition = members.RequireDefinition(assembly, originalOwner, name, SourceMemberKind.Field);
            var field = declaringType.GetField(name,
                            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                            BindingFlags.DeclaredOnly)
                        ?? throw new MissingFieldException(declaringType.FullName, name);
            if (definition.IsStatic || definition.ValueTypeIdentity != originalValueType ||
                field.FieldType != actualValueType || field.IsStatic)
                throw new InvalidOperationException("The original menu field differs from its actual physical field: " +
                                                    originalOwner + "." + name);
            members.RegisterBinding(new(definition, actualOwner, field));
        }
    }
}
