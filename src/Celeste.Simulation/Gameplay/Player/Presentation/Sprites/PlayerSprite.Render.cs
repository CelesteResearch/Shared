using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Sprites
{
    public sealed partial class PlayerSprite
    {
        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = RenderPosition;
            RenderPosition = Vector2Geometry.Floor(RenderPosition);
            base.Render(context);
            RenderPosition = position;
        }
    }
}
