using System;

namespace Celeste.Simulation.UI.Menus.Policies
{
    // Engine-neutral input seam for Everest's optional menu page bindings.
    public static class MenuPagePolicy
    {
        public static Func<bool> UpPressed;
        public static Func<bool> DownPressed;
        public static Action ConsumeUp;
        public static Action ConsumeDown;
    }
}
