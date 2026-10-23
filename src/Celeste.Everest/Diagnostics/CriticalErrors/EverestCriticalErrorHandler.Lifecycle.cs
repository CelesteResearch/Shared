using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Hud.Overlays;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private void ConfigureOptionsMenu()
        {
            optMenu.ItemSpacing = 4f;
            optMenu.RecalculateSize();
            if (UsePlayerSprite)
            {
                optMenu.Position = new(288f, 594f);
                optMenu.Justify = new(.5f, 0f);
                if (optMenu.Position.Y + optMenu.Height > 918f)
                {
                    optMenu.ItemSpacing = 0f;
                    optMenu.RecalculateSize();
                }
            }
            else
            {
                optMenu.Position = new(288f, 648f);
                optMenu.Justify = new(.5f, .5f);
            }
        }

        public override void Added(object scene)
        {
            var overlay = (scene as IOverlayHandler)?.Overlay;
            base.Added(scene);
            ((ISourceRendererScene)scene).Renderers.Add(beforeRenderInterceptor);
            if (overlay != null) ((IOverlayHandler)scene).Overlay = overlay;
        }

        public override void Removed(object scene)
        {
            ((ISourceRendererScene)scene).Renderers.Remove(beforeRenderInterceptor);
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            var next = EngineContext.Frame.Scenes.NextScene;
            if (next != null && scene != null && process.CurrentHandler == this)
            {
                ((ISourceScene)scene).SourceScene.RemoveEntity(this);
                ((ISourceScene)next).SourceScene.QueueSourceEntity(this);
            }

            base.SceneEnd(scene);
        }
    }
}
