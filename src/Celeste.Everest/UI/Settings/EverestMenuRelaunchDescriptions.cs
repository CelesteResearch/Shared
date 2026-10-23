using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.UI.Settings
{
    public static class EverestMenuRelaunchDescriptions
    {
        public static TextMenuPresentation.Item NeedsRelaunch(this TextMenuPresentation.Item option,
            TextMenuPresentation containingMenu, bool needsRelaunch = true)
        {
            if (!needsRelaunch)
                return option;
            EverestMenuEaseInSubHeaderExt needsRelaunchText =
                new EverestMenuEaseInSubHeaderExt(
                    ((IOriginalGameTextEnvironment)containingMenu.EngineContext).Text.Dialog.Clean(
                        "MODOPTIONS_NEEDSRELAUNCH"), false, containingMenu)
                {
                    TextColor = PackedColor.OrangeRed,
                    HeightExtra = 0f
                };
            List<TextMenuPresentation.Item> items = containingMenu.Items;
            if (items.Contains(option))
                containingMenu.Insert(items.IndexOf(option) + 1, needsRelaunchText);
            option.OnEnter =
                (Action)Delegate.Combine(option.OnEnter, (Action)delegate { needsRelaunchText.FadeVisible = true; });
            option.OnLeave =
                (Action)Delegate.Combine(option.OnLeave, (Action)delegate { needsRelaunchText.FadeVisible = false; });
            return option;
        }
    }
}
