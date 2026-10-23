using System.Numerics;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void TeleportTo(RoomPlayerSession player, string nextLevel, PlayerIntroType introType,
            Vector2? nearestSpawn = null)
        {
            OriginalStrawberryTransfer.StoreStrawberries(player.Leader);
            var position = player.Body.Position;
            RemoveEntity(player);
            UnloadLevel();
            Session.Level = nextLevel;
            Session.RespawnPoint = GetSpawnPoint(new Vector2(Bounds.Left, Bounds.Top) +
                                                 (nearestSpawn.HasValue ? nearestSpawn.Value : Vector2.Zero));
            if (introType == PlayerIntroType.Transition)
            {
                player.Body.Position = Session.RespawnPoint.Value;
                player.Hair.MoveHairBy(player.Body.Position - position);
                player.Data.MuffleLanding = true;
                Scheduler.QueueSourceEntity(player);
                LoadLevel(PlayerIntroType.Transition);
                Scheduler.CommitEntityListsForLevel();
            }
            else
            {
                LoadLevel(introType);
                Scheduler.CommitEntityListsForLevel();
                var players =
                    Scheduler.Entities.GetTrackedEntities(typeof(RoomPlayerSession)
                        .FullName);
                player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
            }

            Camera.Position = player.CameraTarget;
            Update();
            OriginalStrawberryTransfer.RestoreStrawberries(player.Leader);
        }
    }
}
