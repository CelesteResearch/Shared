using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;

namespace Celeste.Game.Entities.Birds
{
    public interface IOriginalBirdProcess : IOriginalGameplayProcess, IOriginalGameTextEnvironment
    {
        OriginalBirdProcessState BirdState { get; }
        IBirdTutorialResources BirdTutorialResources { get; }
        AtlasData GuiAtlas { get; }
        bool Invincible { get; }
    }
}
