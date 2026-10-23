namespace Celeste.Simulation.UI.Menus.Text.Policies
{
    public interface ITextMenuRuntimePolicy
    {
        void Render(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu,
            global::Celeste.Core.Rendering.ISourceRenderContext context);

        bool AllowTextHighlight(ITextMenuPolicyEnvironment environment);
        bool MenuPageUpPressed { get; }
        bool MenuPageDownPressed { get; }
    }
}
