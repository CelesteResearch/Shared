using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Player.Scene.Bounds;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerBoundsScene
    {
        public void EnforceBounds(RoomPlayerSession player)
        {
            var bounds = Bounds;
            var rectangle = new IntRect((int)Camera.Left, (int)Camera.Top, 320, 180);
            if (TransitionCoroutine != null) return;
            if (CameraLockMode == RoomCameraLockMode.FinalBoss && player.Left < rectangle.Left)
            {
                player.Left = rectangle.Left;
                player.OnBoundsH();
            }
            else if (player.Left < bounds.Left)
            {
                if (player.Top >= bounds.Top && player.Bottom < bounds.Bottom &&
                    ((OriginalChapterMapData)Session.MapData).CanTransitionTo(this,
                        player.Center + Vector2.UnitX * -8f))
                {
                    player.BeforeSideTransition();
                    NextLevel(player.Center + Vector2.UnitX * -8f, -Vector2.UnitX);
                    return;
                }

                player.Left = bounds.Left;
                player.OnBoundsH();
            }

            var theos = Scheduler.Entities.GetTrackedEntities("Celeste.TheoCrystal");
            var theo = theos.Count == 0 ? null : theos[0] as TheoCrystalState;
            if (CameraLockMode == RoomCameraLockMode.FinalBoss && player.Right > rectangle.Right &&
                rectangle.Right < bounds.Right - 4)
            {
                player.Right = rectangle.Right;
                player.OnBoundsH();
            }
            else if (theo != null && (player.Holding.Holding == null || !player.Holding.Holding.IsHeld) &&
                     player.Right > bounds.Right - 1)
            {
                player.Right = bounds.Right - 1;
            }
            else if (player.Right > bounds.Right)
            {
                if (player.Top >= bounds.Top && player.Bottom < bounds.Bottom &&
                    ((OriginalChapterMapData)Session.MapData).CanTransitionTo(this, player.Center + Vector2.UnitX * 8f))
                {
                    player.BeforeSideTransition();
                    NextLevel(player.Center + Vector2.UnitX * 8f, Vector2.UnitX);
                    return;
                }

                player.Right = bounds.Right;
                player.OnBoundsH();
            }

            if (CameraLockMode != RoomCameraLockMode.None && player.Top < rectangle.Top)
            {
                player.Top = rectangle.Top;
                player.OnBoundsV();
            }
            else if (player.CenterY < bounds.Top)
            {
                if (((OriginalChapterMapData)Session.MapData).CanTransitionTo(this,
                        player.Center - Vector2.UnitY * 12f))
                {
                    player.BeforeUpTransition();
                    NextLevel(player.Center - Vector2.UnitY * 12f, -Vector2.UnitY);
                    return;
                }

                if (player.Top < bounds.Top - 24)
                {
                    player.Top = bounds.Top - 24;
                    player.OnBoundsV();
                }
            }

            if (CameraLockMode != RoomCameraLockMode.None && rectangle.Bottom < bounds.Bottom - 4 &&
                player.Top > rectangle.Bottom)
            {
                if (((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.Invincible)
                {
                    player.Play("event:/game/general/assist_screenbottom");
                    player.Bounce(rectangle.Bottom);
                }
                else
                {
                    player.Die(Vector2.Zero);
                }
            }
            else if (player.Bottom > bounds.Bottom &&
                     ((OriginalChapterMapData)Session.MapData).CanTransitionTo(this,
                         player.Center + Vector2.UnitY * 12f) &&
                     !((OriginalLevelRoomData)Session.LevelData).DisableDownTransition)
            {
                if (!PlayerCollidesWithSolidAt(player, player.Position + Vector2.UnitY * 4f))
                {
                    player.BeforeDownTransition();
                    NextLevel(player.Center + Vector2.UnitY * 12f, Vector2.UnitY);
                }
            }
            else if (player.Top > bounds.Bottom &&
                     ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.Invincible)
            {
                player.Play("event:/game/general/assist_screenbottom");
                player.Bounce(bounds.Bottom);
            }
            else if (player.Top > bounds.Bottom + 4)
            {
                player.Die(Vector2.Zero);
            }
        }

        private static bool PlayerCollidesWithSolidAt(RoomPlayerSession player, Vector2 at)
        {
            return SourceSceneCollisionQueries.CheckAt(player,
                ((ISourceScene)player.Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"), at);
        }
    }
}
