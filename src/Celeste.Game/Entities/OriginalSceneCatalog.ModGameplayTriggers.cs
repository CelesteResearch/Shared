using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModGameplayTriggersSceneModEntitiesActivateDreamBlocksTrigger(
            SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.ActivateDreamBlocksTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesCassetteListener(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CassetteListener", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Mod.Entities.CassetteListener" }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.ChangeInventoryTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CompleteAreaTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CoreModeTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CrystalShatterTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesFlagTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.FlagTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.FlagTrigger", "Celeste.Trigger" }), true);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesLavaBlockerTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.LavaBlockerTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesSpaceControllerBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.SpaceControllerBlocker",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.StarClimbGraphicsController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.StarClimbGraphicsController" }), true);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesTriggerSpikesOriginal(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.TriggerSpikesOriginal",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
