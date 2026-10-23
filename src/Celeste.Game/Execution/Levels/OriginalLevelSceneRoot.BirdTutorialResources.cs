using System.Numerics;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IBirdTutorialLevelScene
    {
        bool IBirdTutorialLevelScene.FrozenOrPaused => FrozenOrPaused;
        object IBirdTutorialLevelScene.RetryPlayerCorpse => RetryPlayerCorpse;
        Vector2 IBirdTutorialLevelScene.CameraPosition => Camera.Position;
    }
}
