using System.Collections.Generic;

namespace Celeste.Simulation.UI.Menus.Text
{
    public interface ITextMenuBinding
    {
        IReadOnlyList<TextMenuBindingValue> Keyboard { get; }
        IReadOnlyList<TextMenuBindingValue> Controller { get; }
    }
}
