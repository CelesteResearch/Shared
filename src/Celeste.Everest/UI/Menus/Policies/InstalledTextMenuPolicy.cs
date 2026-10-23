using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Simulation.UI.Menus.Text.Policies;

namespace Celeste.Everest.UI.Menus.Policies
{
    public sealed class InstalledTextMenuPolicy : ITextMenuRuntimePolicy
    {
        private readonly ISourceEngineContext engine;

        private EverestCoreSettings settings =>
            ((IEverestCurrentCoreSettingsEnvironment)engine)
            .CurrentCoreSettings;

        public InstalledTextMenuPolicy(ISourceEngineContext engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public bool AllowTextHighlight(ITextMenuPolicyEnvironment environment)
        {
            return settings.AllowTextHighlight;
        }

        public bool MenuPageUpPressed => settings.MenuPageUp.Pressed;
        public bool MenuPageDownPressed => settings.MenuPageDown.Pressed;

        public void Render(TextMenuPresentation menu,
            ISourceRenderContext context)
        {
            menu.RecalculateSize();
            if (RenderItems(menu, context, false)) RenderItems(menu, context, true);
        }

        private static bool RenderItems(TextMenuPresentation menu,
            ISourceRenderContext context, bool aboveAll)
        {
            var result = false;
            var vector = menu.Position - menu.Justify * new Vector2(menu.Width, menu.Height);
            foreach (var item in menu.Items)
            {
                if (!item.Visible) continue;
                var num = item.Height();
                if (aboveAll == item.AboveAll)
                {
                    var position = vector + new Vector2(0f, num * 0.5f + item.SelectWiggler.Value * 8f);
                    if ((item is IEverestTextMenuAlwaysRenderItem patchedItem && patchedItem.AlwaysRender) ||
                        (position.Y + num * 0.5f > 0f && position.Y - num * 0.5f <
                            ((ISourceRenderEnvironment)menu.EngineContext).CurrentContext
                            .Graphics.Height))
                        item.Render(context, position, (menu.Focused || menu.RenderAsFocused) && menu.Current == item);
                }
                else
                {
                    result = true;
                }

                vector.Y += num + menu.ItemSpacing;
            }

            return result;
        }
    }
}
