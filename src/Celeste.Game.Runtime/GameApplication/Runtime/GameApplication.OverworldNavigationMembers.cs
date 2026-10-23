using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void PublishSourceOverworldNavigationMembers()
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type owner = SourceProfile == GameProfile.InstalledEverest
                ? typeof(global::Celeste.Everest.Menus.Overworld.EverestOverworldSequence)
                : typeof(OverworldSequence);
            foreach (string name in new[]
                     {
                         nameof(OverworldSequence.Current), nameof(OverworldSequence.Last),
                         nameof(OverworldSequence.Next)
                     })
            {
                var definition =
                    SourceMembers.RequireDefinition(assembly, "Celeste.Overworld", name, SourceMemberKind.Field);
                var field = typeof(OverworldSequence).GetField(name,
                                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                            ?? throw new MissingFieldException(typeof(OverworldSequence).FullName, name);
                if (definition.IsStatic || !definition.IsPublic || definition.ValueTypeAssemblyIdentity != assembly
                    || definition.ValueTypeIdentity != "Celeste.Oui" || field.FieldType != typeof(OuiState))
                    throw new InvalidOperationException(
                        "The original Overworld navigation field does not match its actual scene field: " + name);
                SourceMembers.RegisterBinding(new SourcePhysicalMemberBinding(definition, owner,
                    new MemberInfo[] { field }));
            }
        }
    }
}
