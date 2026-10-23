namespace Celeste.Scene.Scheduling
{
    public interface ISourceSceneUpdatePolicyEnvironment
    {
        SceneUpdatePolicy PlainScenePolicy { get; }
        SceneUpdatePolicy LevelScenePolicy { get; }
    }
}
