using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    // Actual typed Scene identity owns exactly one neutral kernel.
    public interface ISourceScene : ISceneEntityDepthScene, ISceneEntityTagScene, ISceneEntityRemovalScene,
        Celeste.Core.Components.ISourceComponentIndexScene
    {
        SceneUpdateScheduler SourceScene { get; }
    }
}
