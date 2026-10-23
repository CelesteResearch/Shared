using System;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Policies
{
    // Everest can override only menu text blinking while the vanilla flash
    // preference still controls screen flashes and other visual effects.
    public static class MenuHighlightPolicy
    {
        public static Func<bool, bool> AllowTextHighlight;

        public static bool Allows(bool disableFlashes) =>
            AllowTextHighlight?.Invoke(disableFlashes) ?? !disableFlashes;
    }
}
