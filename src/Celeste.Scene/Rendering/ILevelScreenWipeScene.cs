using Celeste.Core.Rendering.Renderers;

namespace Celeste.Scene.Rendering
{
    public interface ILevelScreenWipeScene : ISourceRendererScene
    {
        ISceneRenderer Wipe { get; set; }
    }
}
