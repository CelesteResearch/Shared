using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering
{
    public interface ISourceGameplayBatchScope
    {
        void Begin(ISourceRenderContext context);
        void End(ISourceRenderContext context);
    }
}
