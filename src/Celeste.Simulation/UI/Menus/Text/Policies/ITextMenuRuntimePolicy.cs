using Celeste.Core.Rendering;

namespace Celeste.Simulation.UI.Menus.Text.Policies
{
    public interface ITextMenuRuntimePolicy
    {
        void Render(TextMenuPresentation menu,
            ISourceRenderContext context);

        bool AllowTextHighlight(ITextMenuPolicyEnvironment environment);
        bool MenuPageUpPressed { get; }
        bool MenuPageDownPressed { get; }
    }
}
