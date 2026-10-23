using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModStoryPresentationSceneModEntitiesBadelineOldsiteEnd(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.BadelineOldsiteEnd",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.BadelineOldsiteEnd"]), true);
        }

        private static void RegisterModStoryPresentationSceneModEntitiesCSGENGenericStrawberrySeeds(
            SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.CustomBirdTutorial",
                    (string[])
                    [
                        "Celeste.BirdNPC",
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        "Celeste.Mod.Entities.CustomBirdTutorial",
                        typeof(SourceActorEntityState).FullName,
                    ]), true);
            result.Register(
                new("Celeste.Mod.Entities.CustomBirdTutorialTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.CustomBirdTutorialTrigger", "Celeste.Trigger"]), true);
            result.Register(
                new("Celeste.Mod.Entities.CustomCoreMessage",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.CustomHeightDisplay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.CustomHeightDisplayTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.Mod.Entities.CustomMemorial",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.CustomMemorialText",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.CustomNPC",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Mod.Entities.DialogCutscene",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.DialogCutscene"]), true);
            result.Register(
                new("Celeste.Mod.Entities.DialogCutsceneTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.DialogCutsceneTrigger", "Celeste.Trigger"]), true);
        }

        private static void RegisterModStoryPresentationSceneModEntitiesGenericStrawberrySeed(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.GenericStrawberrySeed",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.GenericStrawberrySeed"]), true);
        }
    }
}
