namespace Celeste.Game.Presentation.Rendering
{
    public interface IOriginalGameplayRendererGlobalsEnvironment
    {
        GameplayRendererSourceGlobals GameplayRendererGlobals { get; }
        global::Celeste.Scene.Tagging.SourceBitTag SourceSubHudTag { get; }
    }
}
