using System;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        public virtual void ReloadMenus(OverworldStartMode startMode = OverworldStartMode.Titlescreen)
        {
            foreach (OuiState ui in UIs)
                SourceScene.RemoveEntity(ui);
            UIs.Clear();
            Type[] types = ((IOriginalMenuAssemblyEnvironment)EngineContext).GetMenuTypes();
            foreach (Type type in types)
            {
                if (typeof(OuiState).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    OuiState oui = ConstructOui(type);
                    oui.Visible = false;
                    SourceScene.QueueSourceEntity(oui);
                    UIs.Add(oui);
                    if (oui.IsStart(this, startMode))
                    {
                        oui.Visible = true;
                        Last = Current = oui;
                    }
                }
            }
        }
    }
}
