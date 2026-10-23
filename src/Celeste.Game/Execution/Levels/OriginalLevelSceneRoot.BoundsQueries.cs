using Celeste.Core.Mathematics.Extrema;
using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool IsInBounds(global::Celeste.Scene.Entities.SceneEntityState entity)
        {
            var bounds = Bounds;
            if (entity.Right > (float)bounds.Left && entity.Bottom > (float)bounds.Top &&
                entity.Left < (float)bounds.Right)
                return entity.Top < (float)bounds.Bottom;
            return false;
        }

        public bool IsInBounds(Vector2 position)
        {
            var bounds = Bounds;
            if (position.X >= (float)bounds.Left && position.Y >= (float)bounds.Top && position.X < (float)bounds.Right)
                return position.Y < (float)bounds.Bottom;
            return false;
        }

        public bool IsInBounds(Vector2 position, float pad)
        {
            var bounds = Bounds;
            if (position.X >= (float)bounds.Left - pad && position.Y >= (float)bounds.Top - pad &&
                position.X < (float)bounds.Right + pad)
                return position.Y < (float)bounds.Bottom + pad;
            return false;
        }

        public bool IsInBounds(Vector2 position, Vector2 directionPad)
        {
            var extrema = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;
            float left = extrema.Max(directionPad.X, 0f);
            float right = extrema.Max(0f - directionPad.X, 0f);
            float top = extrema.Max(directionPad.Y, 0f);
            float bottom = extrema.Max(0f - directionPad.Y, 0f);
            var bounds = Bounds;
            if (position.X >= (float)bounds.Left + left && position.Y >= (float)bounds.Top + top &&
                position.X < (float)bounds.Right - right)
                return position.Y < (float)bounds.Bottom - bottom;
            return false;
        }

        public bool IsInCamera(Vector2 position, float pad)
        {
            var rectangle = new IntRect((int)Camera.X, (int)Camera.Y, 320, 180);
            if (position.X >= (float)rectangle.Left - pad && position.Y >= (float)rectangle.Top - pad &&
                position.X < (float)rectangle.Right + pad)
                return position.Y < (float)rectangle.Bottom + pad;
            return false;
        }
    }
}
