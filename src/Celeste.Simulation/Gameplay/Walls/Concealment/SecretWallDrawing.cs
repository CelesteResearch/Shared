using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Tiles;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public static class SecretWallDrawing
    {
        public static void RenderShakeMargins(SceneEntityState wall, TileGrid tiles, ISecretWallScene level,
            ISourceRenderContext context)
        {
            if (level.ShakeVector.X < 0f && level.Camera.X <= level.Bounds.Left && wall.X <= level.Bounds.Left)
                tiles.RenderAt(wall.Position + new Vector2(-3f, 0f), context);
            if (level.ShakeVector.X > 0f && level.Camera.X + 320f >= level.Bounds.Right &&
                wall.X + wall.Width >= level.Bounds.Right)
                tiles.RenderAt(wall.Position + new Vector2(3f, 0f), context);
            if (level.ShakeVector.Y < 0f && level.Camera.Y <= level.Bounds.Top && wall.Y <= level.Bounds.Top)
                tiles.RenderAt(wall.Position + new Vector2(0f, -3f), context);
            if (level.ShakeVector.Y > 0f && level.Camera.Y + 180f >= level.Bounds.Bottom &&
                wall.Y + wall.Height >= level.Bounds.Bottom)
                tiles.RenderAt(wall.Position + new Vector2(0f, 3f), context);
        }
    }
}
