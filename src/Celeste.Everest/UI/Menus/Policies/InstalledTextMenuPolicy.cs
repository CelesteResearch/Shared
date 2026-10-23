using System.Numerics;
using System;
using Celeste.Simulation.UI.Menus.Text.Policies;

namespace Celeste.Everest.UI.Menus.Policies
{
    public sealed class InstalledTextMenuPolicy : ITextMenuRuntimePolicy
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        private EverestCoreSettings settings =>
            ((global::Celeste.Everest.Modules.Settings.IEverestCurrentCoreSettingsEnvironment)engine)
            .CurrentCoreSettings;

        public InstalledTextMenuPolicy(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            => this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

        public bool AllowTextHighlight(ITextMenuPolicyEnvironment environment)
            => settings.AllowTextHighlight;

        public bool MenuPageUpPressed => settings.MenuPageUp.Pressed;
        public bool MenuPageDownPressed => settings.MenuPageDown.Pressed;

        public void Render(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu,
            global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            menu.RecalculateSize();
            if (RenderItems(menu, context, false)) RenderItems(menu, context, true);
        }

        private static bool RenderItems(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu,
            global::Celeste.Core.Rendering.ISourceRenderContext context, bool aboveAll)
        {
            bool result = false;
            Vector2 vector = menu.Position - menu.Justify * new Vector2(menu.Width, menu.Height);
            foreach (var item in menu.Items)
            {
                if (!item.Visible) continue;
                float num = item.Height();
                if (aboveAll == item.AboveAll)
                {
                    Vector2 position = vector + new Vector2(0f, num * 0.5f + item.SelectWiggler.Value * 8f);
                    if ((item is IEverestTextMenuAlwaysRenderItem patchedItem && patchedItem.AlwaysRender) ||
                        (position.Y + num * 0.5f > 0f && position.Y - num * 0.5f <
                            ((global::Celeste.Core.Rendering.ISourceRenderEnvironment)menu.EngineContext).CurrentContext
                            .Graphics.Height))
                        item.Render(context, position, (menu.Focused || menu.RenderAsFocused) && menu.Current == item);
                }
                else result = true;

                vector.Y += num + menu.ItemSpacing;
            }

            return result;
        }
    }
}
