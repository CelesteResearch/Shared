using System;

namespace Celeste.Simulation.UI.Menus.Options
{
    public interface IMenuOptionsSubpage
    {
        Action OnClose { get; set; }
    }
}
