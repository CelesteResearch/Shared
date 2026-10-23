using System.Numerics;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks
{
    public static class FloatySpringReaction
    {
        public static void Apply(SourceStaticMoverState mover, ref float sinkTimer, ref float dashEase,
            ref Vector2 dashDirection)
        {
            if (mover.Entity is OriginalSpringState)
            {
                switch ((mover.Entity as OriginalSpringState).Orientation)
                {
                    case SpringOrientation.Floor: sinkTimer = .5f; break;
                    case SpringOrientation.WallLeft:
                        dashEase = 1f;
                        dashDirection = -Vector2.UnitX;
                        break;
                    case SpringOrientation.WallRight:
                        dashEase = 1f;
                        dashDirection = Vector2.UnitX;
                        break;
                }
            }
        }
    }
}
