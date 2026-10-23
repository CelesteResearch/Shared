using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Rendering
{
    public sealed class OriginalGameplayBatchScope : ISourceGameplayBatchScope
    {
        public void Begin(ISourceRenderContext context)
        {
            GameplayRendererState.Begin(context);
        }

        public void End(ISourceRenderContext context)
        {
            GameplayRendererState.End(context);
        }
    }
}
