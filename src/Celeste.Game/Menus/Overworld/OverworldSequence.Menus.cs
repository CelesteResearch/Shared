namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        public virtual void ReloadMenus(OverworldStartMode startMode = OverworldStartMode.Titlescreen)
        {
            foreach (var ui in UIs)
                SourceScene.RemoveEntity(ui);
            UIs.Clear();
            var types = ((IOriginalMenuAssemblyEnvironment)EngineContext).GetMenuTypes();
            foreach (var type in types)
                if (typeof(OuiState).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    var oui = ConstructOui(type);
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
