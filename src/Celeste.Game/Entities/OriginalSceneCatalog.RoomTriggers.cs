using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterRoomTriggersSceneChangeRespawnTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ChangeRespawnTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterRoomTriggersSceneCheckpoint(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Checkpoint",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CheckpointBlockerTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CheckpointBlockerTrigger", "Celeste.Trigger" }), true);
        }

        private static void RegisterRoomTriggersSceneCreditsTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CreditsTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CreditsTrigger", "Celeste.Trigger" }), true);
        }

        private static void RegisterRoomTriggersSceneNoRefillTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.NoRefillTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterRoomTriggersSceneRespawnTargetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RespawnTargetTrigger",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.RespawnTargetTrigger" }), true);
        }

        private static void RegisterRoomTriggersSceneSpawnFacingTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SpawnFacingTrigger",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.SpawnFacingTrigger" }), true);
        }

        private static void RegisterRoomTriggersSceneStopBoostTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StopBoostTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }
    }
}
