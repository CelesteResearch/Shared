using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModStoryPresentationSceneModEntitiesBadelineOldsiteEnd(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.BadelineOldsiteEnd",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.BadelineOldsiteEnd" }), true);
        }

        private static void RegisterModStoryPresentationSceneModEntitiesCSGENGenericStrawberrySeeds(
            SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomBirdTutorial",
                    new string[]
                    {
                        "Celeste.BirdNPC",
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        "Celeste.Mod.Entities.CustomBirdTutorial",
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomBirdTutorialTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.CustomBirdTutorialTrigger", "Celeste.Trigger" }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomCoreMessage",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomHeightDisplay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomHeightDisplayTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomMemorial",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomMemorialText",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.CustomNPC",
                    new string[] { "Celeste.NPC", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.DialogCutscene",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.DialogCutscene" }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.DialogCutsceneTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.DialogCutsceneTrigger", "Celeste.Trigger" }), true);
        }

        private static void RegisterModStoryPresentationSceneModEntitiesGenericStrawberrySeed(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.GenericStrawberrySeed",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.GenericStrawberrySeed" }), true);
        }
    }
}
