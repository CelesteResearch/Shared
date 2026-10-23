using Celeste.Core.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Credits.Backdrops
{
    public sealed class CreditsFillBackdrop : BackdropPresentation
    {
        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
            => SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 340f, 200f, Color);
    }
}
