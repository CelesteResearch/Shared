using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void PublishSourceOuiMembers()
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            SourceMembers.RegisterSourceType(typeof(OuiState), assembly, "Celeste.Oui");
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var focused = SourceMembers.RequireDefinition(assembly, "Celeste.Oui", nameof(OuiState.Focused),
                SourceMemberKind.Field);
            if (focused.IsStatic || !focused.IsPublic || focused.ValueTypeIdentity != "System.Boolean")
                throw new InvalidOperationException(
                    "The original Oui.Focused declaration differs from its actual menu field.");
            var field = typeof(OuiState).GetField(nameof(OuiState.Focused), flags)
                        ?? throw new MissingFieldException(typeof(OuiState).FullName, nameof(OuiState.Focused));
            SourceMembers.RegisterBinding(new(focused, typeof(OuiState),
                [field]));
            foreach (var name in new[] { nameof(OuiState.Overworld), nameof(OuiState.Selected) })
            {
                var definition =
                    SourceMembers.RequireDefinition(assembly, "Celeste.Oui", name, SourceMemberKind.Property);
                var property = typeof(OuiState).GetProperty(name, flags)
                               ?? throw new MissingMemberException(typeof(OuiState).FullName, name);
                var originalValueType = name == nameof(OuiState.Overworld) ? "Celeste.Overworld" : "System.Boolean";
                var actualValueType = name == nameof(OuiState.Overworld) ? typeof(OverworldSequence) : typeof(bool);
                if (definition.IsStatic || !definition.IsPublic || !definition.CanRead || definition.CanWrite
                    || definition.IndexParameterCount != 0 || definition.ValueTypeIdentity != originalValueType
                    || property.PropertyType != actualValueType)
                    throw new InvalidOperationException(
                        "The original Oui property differs from its actual menu property: " + name);
                SourceMembers.RegisterBinding(new(definition, typeof(OuiState),
                    [property]));
            }
        }
    }
}
