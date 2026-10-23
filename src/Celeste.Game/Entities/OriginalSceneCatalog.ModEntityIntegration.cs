using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModEntityIntegrationSceneModEntitiesEntityColliderGeneric(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.EntityCollider`1", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.EntityColliderByComponent`1",
                    (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.EntityRemovedListener", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.EntityTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.EntityTrigger", "Celeste.Trigger"]), true);
            result.Register(
                new("Celeste.Mod.Entities.EntityTriggerListener", (string[])["Monocle.Component"],
                    (string[])["Celeste.Mod.Entities.EntityTriggerListener"]), true);
        }

        private static void RegisterModEntityIntegrationSceneModEntitiesSceneWrappingEntity(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.SceneWrappingEntity",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.SceneWrappingEntity`1",
                    (string[])
                    [
                        "Celeste.Mod.Entities.SceneWrappingEntity",
                        typeof(SceneEntityState).FullName,
                    ], (string[])[]));
        }

        private static void RegisterModEntityIntegrationSceneModEntitiesTimeRateModifier(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.TimeRateModifier", (string[])["Monocle.Component"],
                    (string[])["Celeste.Mod.Entities.TimeRateModifier"]), true);
        }
    }
}
