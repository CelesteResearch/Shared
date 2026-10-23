using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Solids.Nega
{
    public class NegaBlockState : SourceSolidEntityState
    {
        public NegaBlockState(Vector2 position, float width, float height, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            SourcePrimitiveDrawing.Rect(context, this, Collider.AbsoluteLeft, Collider.AbsoluteTop,
                Collider.Width, Collider.Height, new(255, 0, 0));
        }
    }
}
