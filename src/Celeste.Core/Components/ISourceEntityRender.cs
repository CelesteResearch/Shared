namespace Celeste.Core.Components
{
    // The actual Entity.Render virtual call, independent of any native backend.
    public interface ISourceEntityRender
    {
        void Render(global::Celeste.Core.Rendering.ISourceRenderContext context);
    }
}
