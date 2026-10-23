using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Simulation.Presentation.Hud.Saving
{
    public interface ISaveLoadIconResources
    {
        int Tags { get; }
        ISpriteFactory GuiSpriteBank { get; }
        WigglerComponentPool WigglerPool { get; }
    }
}
