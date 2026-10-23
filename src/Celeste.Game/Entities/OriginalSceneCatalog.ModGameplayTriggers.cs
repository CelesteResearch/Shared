using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModGameplayTriggersSceneModEntitiesActivateDreamBlocksTrigger(
            SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.ActivateDreamBlocksTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesCassetteListener(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.CassetteListener", (string[])["Monocle.Component"],
                    (string[])["Celeste.Mod.Entities.CassetteListener"]), true);
            result.Register(
                new("Celeste.Mod.Entities.ChangeInventoryTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.Mod.Entities.CompleteAreaTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.Mod.Entities.CoreModeTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.Mod.Entities.CrystalShatterTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesFlagTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.FlagTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.FlagTrigger", "Celeste.Trigger"]), true);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesLavaBlockerTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.LavaBlockerTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesSpaceControllerBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.SpaceControllerBlocker",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.StarClimbGraphicsController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.StarClimbGraphicsController"]), true);
        }

        private static void RegisterModGameplayTriggersSceneModEntitiesTriggerSpikesOriginal(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.TriggerSpikesOriginal",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
