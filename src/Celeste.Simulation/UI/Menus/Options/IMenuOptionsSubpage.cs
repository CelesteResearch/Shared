using Celeste.Input;
using System;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Options
{
    public interface IMenuOptionsSubpage
    {
        Action OnClose { get; set; }
    }
}
