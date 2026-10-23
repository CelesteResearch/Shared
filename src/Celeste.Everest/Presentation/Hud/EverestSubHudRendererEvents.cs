using Celeste.Scene.Scenes;

namespace Celeste.Everest.Presentation.Hud
{
    public sealed class EverestSubHudRendererEvents
    {
        public delegate void BeforeRenderHandler(SubHudRendererState renderer,
            SourceSceneState scene);

        public event BeforeRenderHandler OnBeforeRender;

        internal void BeforeRender(SubHudRendererState renderer, SourceSceneState scene)
        {
            OnBeforeRender?.Invoke(renderer, scene);
        }
    }
}
