using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Scene.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Crushing
{
    public static class CrushingSolidMotion
    {
        public static bool CheckHorizontal(SourceSolidEntityState solid, ISourceSceneBounds level, float amount)
        {
            return CheckHorizontal(solid, level, amount, null);
        }

        public static bool CheckHorizontal(SourceSolidEntityState solid, ISourceSceneBounds level, float amount,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide)
        {
            if (solid.MoveHCollideSolidsAndBounds(level, amount, true, onCollide))
            {
                if (amount < 0f && solid.Left <= level.Bounds.Left) return true;
                if (amount > 0f && solid.Right >= level.Bounds.Right) return true;
                for (var i = 1; i <= 4; i++)
                for (var direction = 1; direction >= -1; direction -= 2)
                {
                    var offset = new Vector2(Math.Sign(amount), i * direction);
                    if (!SourceTrackedEntityCollision.CheckAt(((ISourceScene)solid.Scene).SourceScene.Entities,
                            "Celeste.Solid", solid, SourceVector2Math.Add(solid.Position, offset)))
                    {
                        solid.MoveVExact(i * direction);
                        solid.MoveHExact(Math.Sign(amount));
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool CheckVertical(SourceSolidEntityState solid, ISourceSceneBounds level, float amount,
            bool checkBottom)
        {
            return CheckVertical(solid, level, amount, checkBottom, null);
        }

        public static bool CheckVertical(SourceSolidEntityState solid, ISourceSceneBounds level, float amount,
            bool checkBottom, Action<Vector2, Vector2, ISourcePlatformEntity> onCollide)
        {
            if (solid.MoveVCollideSolidsAndBounds(level, amount, true, onCollide, checkBottom))
            {
                if (amount < 0f && solid.Top <= level.Bounds.Top) return true;
                if (checkBottom && amount > 0f && solid.Bottom >= level.Bounds.Bottom + 32) return true;
                for (var i = 1; i <= 4; i++)
                for (var direction = 1; direction >= -1; direction -= 2)
                {
                    var offset = new Vector2(i * direction, Math.Sign(amount));
                    if (!SourceTrackedEntityCollision.CheckAt(((ISourceScene)solid.Scene).SourceScene.Entities,
                            "Celeste.Solid", solid, SourceVector2Math.Add(solid.Position, offset)))
                    {
                        solid.MoveHExact(i * direction);
                        solid.MoveVExact(Math.Sign(amount));
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
