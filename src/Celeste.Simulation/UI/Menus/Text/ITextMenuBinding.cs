using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public interface ITextMenuBinding
    {
        IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> Keyboard { get; }
        IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> Controller { get; }
    }
}
