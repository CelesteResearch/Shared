using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public IntPoint LevelSolidOffset => new IntPoint(Bounds.Left / 8 - TileBounds.X, Bounds.Top / 8 - TileBounds.Y);

        public bool InsideCamera(Vector2 position, float expand = 0f)
        {
            if (position.X >= Camera.Left - expand && position.X < Camera.Right + expand &&
                position.Y >= Camera.Top - expand)
                return position.Y < Camera.Bottom + expand;
            return false;
        }
    }
}
