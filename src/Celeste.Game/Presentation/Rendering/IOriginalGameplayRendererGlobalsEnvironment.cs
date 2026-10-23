using Celeste.Scene.Tagging;

namespace Celeste.Game.Presentation.Rendering
{
    public interface IOriginalGameplayRendererGlobalsEnvironment
    {
        GameplayRendererSourceGlobals GameplayRendererGlobals { get; }
        SourceBitTag SourceSubHudTag { get; }
    }
}
