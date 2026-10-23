using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Menus.Overworld
{
    public partial class EverestOverworldSequence
    {
        public override void ReloadMenus(OverworldStartMode startMode = OverworldStartMode.Titlescreen)
        {
            foreach (OuiState ui in UIs)
                SourceScene.RemoveEntity(ui);
            UIs.Clear();
            Type[] types = ((IOriginalMenuAssemblyEnvironment)EngineContext).GetMenuTypes();
            foreach (Type type in types)
            {
                if (typeof(OuiState).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    OuiState oui = RegisterOui(type);
                    if (oui.IsStart(this, startMode))
                    {
                        oui.Visible = true;
                        Last = Current = oui;
                    }
                }
            }
        }

        public OuiState RegisterOui(Type type)
        {
            OuiState oui = ConstructOui(type);
            oui.Visible = false;
            SourceScene.QueueSourceEntity(oui);
            UIs.Add(oui);
            if (UIProperties == null)
            {
                UIProperties = new Dictionary<Type, OuiPropertiesAttribute>
                {
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).ChapterSelectUIType,
                        new OuiPropertiesAttribute(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).ChapterPanelUIType,
                        new OuiPropertiesAttribute(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).MapListUIType,
                        new OuiPropertiesAttribute(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).MapSearchUIType,
                        new OuiPropertiesAttribute(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).JournalUIType,
                        new OuiPropertiesAttribute(true)
                    }
                };
            }

            foreach (OuiPropertiesAttribute customAttribute in ((IEverestOuiPropertiesEnvironment)EngineContext)
                     .GetDeclaredOuiProperties(type))
                UIProperties[type] = customAttribute;
            return oui;
        }
    }
}
