namespace Celeste.Scene.Rendering
{
    public interface ISourceRendererScene
    {
        SceneRendererList Renderers { get; }
        float DeltaTime { get; }
        float RawDeltaTime { get; }
    }
}
