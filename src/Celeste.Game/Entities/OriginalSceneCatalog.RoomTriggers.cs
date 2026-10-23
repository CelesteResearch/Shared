using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterRoomTriggersSceneChangeRespawnTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ChangeRespawnTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterRoomTriggersSceneCheckpoint(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Checkpoint",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CheckpointBlockerTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CheckpointBlockerTrigger", "Celeste.Trigger"]), true);
        }

        private static void RegisterRoomTriggersSceneCreditsTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CreditsTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CreditsTrigger", "Celeste.Trigger"]), true);
        }

        private static void RegisterRoomTriggersSceneNoRefillTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.NoRefillTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterRoomTriggersSceneRespawnTargetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RespawnTargetTrigger",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.RespawnTargetTrigger"]), true);
        }

        private static void RegisterRoomTriggersSceneSpawnFacingTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SpawnFacingTrigger",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.SpawnFacingTrigger"]), true);
        }

        private static void RegisterRoomTriggersSceneStopBoostTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StopBoostTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }
    }
}
