using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Menus.Overworld;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMenuAssemblyEnvironment,
        IInstalledOverworldUITypeEnvironment, IEverestOuiPropertiesEnvironment
    {
        public Type[] GetMenuTypes()
        {
            var gameAssembly = OriginalGameAssemblyIdentity;
            var runtimeTypes = SourceProfile == GameProfile.InstalledEverest
                ? Reflection.GetFakeEntryAssembly().GetTypes()
                : SourceMembers.GetRuntimeAssemblyTypes(gameAssembly);
            var selected = new List<Type>();
            foreach (var actualType in runtimeTypes)
            {
                if (!typeof(OuiState).IsAssignableFrom(actualType) || actualType.IsAbstract) continue;
                if (!SourceMembers.ContainsSourceType(actualType))
                {
                    selected.Add(actualType);
                    continue;
                }

                var definition = SourceMembers.GetOriginalTypeDefinition(actualType);
                if (!IsOriginalOuiType(definition, gameAssembly) ||
                    (definition.Attributes & (int)TypeAttributes.Abstract) != 0) continue;
                if (!typeof(OuiState).IsAssignableFrom(actualType) || actualType.IsAbstract)
                    throw new InvalidOperationException(
                        "The actual menu type does not implement its original qualification: " + definition.Identity);
                selected.Add(actualType);
            }

            return [.. selected];
        }

        private bool IsOriginalOuiType(SourceTypeDefinition definition, string gameAssembly)
        {
            for (var current = definition;
                 current != null;
                 current = SourceMembers.GetOriginalBaseTypeDefinition(current))
            {
                if (current.AssemblyIdentity == gameAssembly && current.Identity == "Celeste.Oui") return true;
                if (current.BaseTypeIdentity == null) return false;
                if (ExternalBaseClosureFacts.ProvesNoReferenceToSelectedGame(current.BaseAssemblyIdentity))
                    return false;
            }

            return false;
        }

        private Type OriginalMenuType(string identity)
        {
            return SourceMembers.GetActualSourceType(OriginalGameAssemblyIdentity, identity);
        }

        Type IInstalledOverworldUITypeEnvironment.ChapterSelectUIType => OriginalMenuType("Celeste.OuiChapterSelect");
        Type IInstalledOverworldUITypeEnvironment.ChapterPanelUIType => OriginalMenuType("Celeste.OuiChapterPanel");
        Type IInstalledOverworldUITypeEnvironment.MapListUIType => OriginalMenuType("Celeste.Mod.UI.OuiMapList");
        Type IInstalledOverworldUITypeEnvironment.MapSearchUIType => OriginalMenuType("Celeste.Mod.UI.OuiMapSearch");
        Type IInstalledOverworldUITypeEnvironment.JournalUIType => OriginalMenuType("Celeste.OuiJournal");

        IEnumerable<OuiPropertiesAttribute> IEverestOuiPropertiesEnvironment.GetDeclaredOuiProperties(Type actualType)
        {
            if (!SourceMembers.ContainsSourceType(actualType))
            {
                foreach (var attribute in actualType.GetCustomAttributes<OuiPropertiesAttribute>(false))
                    yield return attribute;
                yield break;
            }

            var definition = SourceMembers.GetOriginalTypeDefinition(actualType);
            foreach (var attribute in definition.DeclaredAttributes)
            {
                if (attribute.TypeIdentity != "Celeste.Mod.UI.OuiPropertiesAttribute") continue;
                var blob = attribute.ValueBlob;
                if (blob.Count != 5 || blob[0] != 1 || blob[1] != 0 || blob[2] > 1 || blob[3] != 0 || blob[4] != 0)
                    throw new InvalidOperationException(
                        "The original OuiProperties boolean attribute blob is invalid: " +
                        definition.Identity);
                yield return new(blob[2] != 0);
            }
        }
    }
}
