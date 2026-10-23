using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Walls.Solids
{
    public sealed class NegaBlockState
    {
        public readonly global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform Platform;
        public bool Active = true, Visible = true, Collidable = true;
        public Vector2 Position => Platform.Position;
        public global::Celeste.Core.Geometry.Bounds Bounds => Platform.BoundingBox;

        public NegaBlockState(Vector2 position, int width, int height)
        {
            Platform = new global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform(position,
                safe: false);
            Platform.Regions.Add(new global::Celeste.Core.Geometry.Bounds(0, 0, width, height));
        }
    }
}
