using System;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Menus.Overworld
{
    public partial class EverestOverworldSequence
    {
        public override void ReloadMenus(OverworldStartMode startMode = OverworldStartMode.Titlescreen)
        {
            foreach (var ui in UIs)
                SourceScene.RemoveEntity(ui);
            UIs.Clear();
            var types = ((IOriginalMenuAssemblyEnvironment)EngineContext).GetMenuTypes();
            foreach (var type in types)
                if (typeof(OuiState).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    var oui = RegisterOui(type);
                    if (oui.IsStart(this, startMode))
                    {
                        oui.Visible = true;
                        Last = Current = oui;
                    }
                }
        }

        public OuiState RegisterOui(Type type)
        {
            var oui = ConstructOui(type);
            oui.Visible = false;
            SourceScene.QueueSourceEntity(oui);
            UIs.Add(oui);
            if (UIProperties == null)
                UIProperties = new()
                {
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).ChapterSelectUIType,
                        new(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).ChapterPanelUIType,
                        new(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).MapListUIType,
                        new(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).MapSearchUIType,
                        new(true)
                    },
                    {
                        ((IInstalledOverworldUITypeEnvironment)EngineContext).JournalUIType,
                        new(true)
                    },
                };

            foreach (var customAttribute in ((IEverestOuiPropertiesEnvironment)EngineContext)
                     .GetDeclaredOuiProperties(type))
                UIProperties[type] = customAttribute;
            return oui;
        }
    }
}
