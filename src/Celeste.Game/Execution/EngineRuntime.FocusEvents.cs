using System;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime
    {
        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
            if (scene != null) scene.GainFocus();
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            base.OnDeactivated(sender, args);
            if (scene != null) scene.LoseFocus();
        }
    }
}
