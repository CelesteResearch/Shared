using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Platforms.Collision;

namespace Celeste.Simulation.Gameplay.Walls.Solids
{
    public sealed class NegaBlockState
    {
        public readonly CollisionPlatform Platform;
        public bool Active = true, Visible = true, Collidable = true;
        public Vector2 Position => Platform.Position;
        public Bounds Bounds => Platform.BoundingBox;

        public NegaBlockState(Vector2 position, int width, int height)
        {
            Platform = new(position,
                safe: false);
            Platform.Regions.Add(new(0, 0, width, height));
        }
    }
}
