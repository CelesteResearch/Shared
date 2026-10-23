using Celeste.Simulation.UI.Menus.Text.Policies;

namespace Celeste.Simulation.UI.Menus.Text
{
    public interface ITextMenuProcessEnvironment
    {
        ITextMenuRuntimePolicy TextMenuPolicy { get; }
        int TextMenuTags { get; }
        TextMenuResources TextMenuResources { get; }
        bool AllowTextHighlight { get; }
        bool MenuPageUpPressed { get; }
        bool MenuPageDownPressed { get; }
        void PlayMenuSound(string eventPath);
    }
}
