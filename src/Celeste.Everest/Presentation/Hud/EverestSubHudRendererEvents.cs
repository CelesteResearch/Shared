namespace Celeste.Everest.Presentation.Hud
{
    public sealed class EverestSubHudRendererEvents
    {
        public delegate void BeforeRenderHandler(SubHudRendererState renderer,
            Celeste.Scene.Scenes.SourceSceneState scene);

        public event BeforeRenderHandler OnBeforeRender;

        internal void BeforeRender(SubHudRendererState renderer, Celeste.Scene.Scenes.SourceSceneState scene)
            => OnBeforeRender?.Invoke(renderer, scene);
    }
}
