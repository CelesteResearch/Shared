using Celeste.Core.Rendering;

namespace Celeste.Core.Components
{
    // The actual Entity.Render virtual call, independent of any native backend.
    public interface ISourceEntityRender
    {
        void Render(ISourceRenderContext context);
    }
}
