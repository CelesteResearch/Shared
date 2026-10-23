using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModEntityIntegrationSceneModEntitiesEntityColliderGeneric(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.EntityCollider`1", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.EntityColliderByComponent`1",
                    new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.EntityRemovedListener", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.EntityTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.EntityTrigger", "Celeste.Trigger" }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.EntityTriggerListener", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Mod.Entities.EntityTriggerListener" }), true);
        }

        private static void RegisterModEntityIntegrationSceneModEntitiesSceneWrappingEntity(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.SceneWrappingEntity",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.SceneWrappingEntity`1",
                    new string[]
                    {
                        "Celeste.Mod.Entities.SceneWrappingEntity",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    }, new string[] { }),
                false);
        }

        private static void RegisterModEntityIntegrationSceneModEntitiesTimeRateModifier(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.TimeRateModifier", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Mod.Entities.TimeRateModifier" }), true);
        }
    }
}
