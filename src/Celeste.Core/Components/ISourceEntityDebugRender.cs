using Celeste.Core.Rendering;

namespace Celeste.Core.Components
{
    public interface ISourceEntityDebugRender
    {
        void DebugRender(ISourceRenderContext context, object actualCamera);
    }
}
