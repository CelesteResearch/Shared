using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;

namespace Celeste.Everest.UI.Settings
{
    public static class EverestMenuDescriptions
    {
        public static TextMenuPresentation.Item AddDescription(this TextMenuPresentation.Item option,
            TextMenuPresentation containingMenu, string description)
        {
            var descriptionText = new EverestMenuEaseInSubHeaderExt(description, false, containingMenu)
            {
                TextColor = PackedColor.Gray,
                HeightExtra = 0f
            };
            List<TextMenuPresentation.Item> items = containingMenu.Items;
            if (items.Contains(option))
                containingMenu.Insert(items.IndexOf(option) + 1, descriptionText);
            option.OnEnter =
                (Action)Delegate.Combine(option.OnEnter, (Action)delegate { descriptionText.FadeVisible = true; });
            option.OnLeave =
                (Action)Delegate.Combine(option.OnLeave, (Action)delegate { descriptionText.FadeVisible = false; });
            return option;
        }

        public static TextMenuPresentation.Item AddDescription(this TextMenuPresentation.Item option,
            EverestSubMenu containingSubMenu, TextMenuPresentation parentContainer, string description)
        {
            var descriptionText = new EverestMenuEaseInSubHeaderExt(description, false, parentContainer)
            {
                TextColor = PackedColor.Gray,
                HeightExtra = 0f
            };
            if (containingSubMenu.Items.Contains(option))
                containingSubMenu.Insert(containingSubMenu.Items.IndexOf(option) + 1, descriptionText);
            else if (containingSubMenu.ContainsDelayedAddItem(option))
                containingSubMenu.InsertDelayedAddItem(descriptionText, option);
            option.OnEnter =
                (Action)Delegate.Combine(option.OnEnter, (Action)delegate { descriptionText.FadeVisible = true; });
            option.OnLeave =
                (Action)Delegate.Combine(option.OnLeave, (Action)delegate { descriptionText.FadeVisible = false; });
            return option;
        }
    }
}
