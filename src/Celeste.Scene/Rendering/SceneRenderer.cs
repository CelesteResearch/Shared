using Celeste.Core.Rendering.Renderers;

namespace Celeste.Scene.Rendering
{
    public abstract class SceneRenderer : ISceneRenderer
    {
        public bool Visible = true;

        bool ISceneRenderer.Visible => Visible;

        public virtual void Update(object scene)
        {
        }

        public virtual void BeforeRender(object scene)
        {
        }

        public virtual void Render(object scene)
        {
        }

        public virtual void AfterRender(object scene)
        {
        }
    }
}
