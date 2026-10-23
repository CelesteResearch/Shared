using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus
{
    public interface IPausableMenu
    {
        Action OnCancel { get; set; }
        Action OnESC { get; set; }
        Action OnPause { get; set; }
        void AddButton(string label, Action pressed);
        void Update();
        void RemoveSelf();
    }
}
