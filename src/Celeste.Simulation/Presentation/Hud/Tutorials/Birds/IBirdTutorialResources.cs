using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;
using Celeste.Input.Bindings;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public interface IBirdTutorialResources
    {
        BirdTutorialButton RegisterButton(SourceVirtualButton button);
        ActiveBitmapFont ActiveFont { get; }
        bool MirrorMode { get; }
        AtlasEntry GuiButton(BirdTutorialButton prompt);
        AtlasEntry GuiDirection(Vector2 direction);
    }
}
