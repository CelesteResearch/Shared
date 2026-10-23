using System.Numerics;
using Celeste.Simulation.UI.Menus.Text.Policies;

namespace Celeste.Game.Menus.Policies
{
    public sealed class OriginalTextMenuPolicy : ITextMenuRuntimePolicy
    {
        public bool AllowTextHighlight(ITextMenuPolicyEnvironment environment) => true;
        public bool MenuPageUpPressed => false;
        public bool MenuPageDownPressed => false;

        public void Render(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu,
            global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            menu.RecalculateSize();
            Vector2 vector = menu.Position - menu.Justify * new Vector2(menu.Width, menu.Height);
            Vector2 vector2 = vector;
            bool flag = false;
            foreach (global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Item item in menu.Items)
            {
                if (item.Visible)
                {
                    float num = item.Height();
                    if (!item.AboveAll)
                    {
                        item.Render(context, vector2 + new Vector2(0f, num * 0.5f + item.SelectWiggler.Value * 8f),
                            (menu.Focused || menu.RenderAsFocused) && menu.Current == item);
                    }
                    else
                    {
                        flag = true;
                    }

                    vector2.Y += num + menu.ItemSpacing;
                }
            }

            if (!flag)
            {
                return;
            }

            vector2 = vector;
            foreach (global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Item item2 in menu.Items)
            {
                if (item2.Visible)
                {
                    float num2 = item2.Height();
                    if (item2.AboveAll)
                    {
                        item2.Render(context, vector2 + new Vector2(0f, num2 * 0.5f + item2.SelectWiggler.Value * 8f),
                            (menu.Focused || menu.RenderAsFocused) && menu.Current == item2);
                    }

                    vector2.Y += num2 + menu.ItemSpacing;
                }
            }

            return;
        }
    }
}
