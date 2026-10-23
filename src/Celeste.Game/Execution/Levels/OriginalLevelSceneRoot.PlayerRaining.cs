using Celeste.Simulation.Gameplay.Player.Scene.Audio;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerRainingScene
    {
        bool ISourcePlayerRainingScene.Raining => Raining;
    }
}
