using System.Numerics;
using Celeste.Graphics.Animation;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // TrailManager view: original `TrailManager.Add(entity, color)` resolves the entity's
    // PlayerSprite first and then its Sprite, and passes no hair.
    public interface IFarewellPropTrail
    {
        void Add(Vector2 position, SpriteImage sprite, Vector2 scale,
            Vector4 color, int depth);
    }
}
