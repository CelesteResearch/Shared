using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Animation;

namespace Celeste.Simulation.Presentation.Hud.Saving
{
    public interface ISaveLoadIconResources
    {
        int Tags { get; }
        ISpriteFactory GuiSpriteBank { get; }
        WigglerComponentPool WigglerPool { get; }
    }
}
