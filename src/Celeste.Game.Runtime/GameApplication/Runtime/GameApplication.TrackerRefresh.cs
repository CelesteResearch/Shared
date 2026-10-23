using Celeste.Scene.Tracking;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceTrackerRefreshSceneEnvironment
    {
        public ISourceScene TrackerRefreshCurrentScene => (ISourceScene)Frame.Scenes.CurrentScene;
    }
}
