using Celeste.Simulation.Gameplay.Actors.Debris;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceDebrisScene
    {
        bool ISourceDebrisScene.Dreaming => Session.Dreaming;
    }
}
