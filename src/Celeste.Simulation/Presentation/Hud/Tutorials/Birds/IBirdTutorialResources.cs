using Celeste.Input.Bindings;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;

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
