using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Sprites
{
    public sealed partial class PlayerSprite
    {
        public override void Render(ISourceRenderContext context)
        {
            var position = RenderPosition;
            RenderPosition = Vector2Geometry.Floor(RenderPosition);
            base.Render(context);
            RenderPosition = position;
        }
    }
}
