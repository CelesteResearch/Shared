using System.Collections.Generic;
using System.Numerics;
using Celeste.Everest.UI.Menus.Buttons;
using Celeste.Everest.UI.ModOptions;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Title;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.UI.Menus.Buttons.Title;
using Celeste.Graphics.Content.Gui;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public void CreateMainMenuButtons(MainMenuSequence menu, List<MenuButtonPresentation> buttons)
        {
            var index = buttons.FindIndex(button => button is MainMenuSmallButtonPresentation small &&
                                                    small.LabelName == "menu_options" &&
                                                    small.IconName == "menu/options");
            index = index == -1 ? buttons.Count - 1 : index + 1;
            buttons.Insert(index, new MainMenuModOptionsButton("menu_modoptions", "menu/modoptions_new", menu,
                Vector2.Zero, Vector2.Zero, () =>
                {
                    ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play("event:/ui/main/button_select");
                    ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play("event:/ui/main/whoosh_large_in");
                    menu.Overworld.Goto<EverestModOptionsState>();
                }, ((ISourceGuiAtlasResources)SourceEngine).GuiAtlas, SourceEngine));
        }
    }
}
