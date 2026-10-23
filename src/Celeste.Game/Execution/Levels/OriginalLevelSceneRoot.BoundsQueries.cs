using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Entities;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool IsInBounds(SceneEntityState entity)
        {
            var bounds = Bounds;
            if (entity.Right > bounds.Left && entity.Bottom > bounds.Top &&
                entity.Left < bounds.Right)
                return entity.Top < bounds.Bottom;
            return false;
        }

        public bool IsInBounds(Vector2 position)
        {
            var bounds = Bounds;
            if (position.X >= bounds.Left && position.Y >= bounds.Top && position.X < bounds.Right)
                return position.Y < bounds.Bottom;
            return false;
        }

        public bool IsInBounds(Vector2 position, float pad)
        {
            var bounds = Bounds;
            if (position.X >= bounds.Left - pad && position.Y >= bounds.Top - pad &&
                position.X < bounds.Right + pad)
                return position.Y < bounds.Bottom + pad;
            return false;
        }

        public bool IsInBounds(Vector2 position, Vector2 directionPad)
        {
            var extrema = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;
            var left = extrema.Max(directionPad.X, 0f);
            var right = extrema.Max(0f - directionPad.X, 0f);
            var top = extrema.Max(directionPad.Y, 0f);
            var bottom = extrema.Max(0f - directionPad.Y, 0f);
            var bounds = Bounds;
            if (position.X >= bounds.Left + left && position.Y >= bounds.Top + top &&
                position.X < bounds.Right - right)
                return position.Y < bounds.Bottom - bottom;
            return false;
        }

        public bool IsInCamera(Vector2 position, float pad)
        {
            var rectangle = new IntRect((int)Camera.X, (int)Camera.Y, 320, 180);
            if (position.X >= rectangle.Left - pad && position.Y >= rectangle.Top - pad &&
                position.X < rectangle.Right + pad)
                return position.Y < rectangle.Bottom + pad;
            return false;
        }
    }
}
