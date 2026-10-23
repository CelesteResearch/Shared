using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // TrailManager view: original `TrailManager.Add(entity, color)` resolves the entity's
    // PlayerSprite first and then its Sprite, and passes no hair.
    public interface IFarewellPropTrail
    {
        void Add(Vector2 position, global::Celeste.Graphics.Animation.SpriteImage sprite, Vector2 scale,
            Vector4 color, int depth);
    }
}
