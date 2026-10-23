using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterInteractionSceneBadelineBoost(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BadelineBoost",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneBooster(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Booster",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneBumper(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Bumper",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneDashSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DashSwitch",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterInteractionSceneInteractTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.InteractTrigger",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneLookout(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Lookout",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Lookout"]), true);
            result.Register(
                new("Celeste.Lookout.Hud",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.LookoutBlocker",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.LookoutBlocker"]), true);
        }

        private static void RegisterInteractionSceneSpring(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Spring",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Switch", (string[])["Monocle.Component"],
                    (string[])["Celeste.Switch"]), true);
        }

        private static void RegisterInteractionSceneTalkComponent(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TalkComponent", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Celeste.TalkComponent.TalkComponentUI",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterInteractionSceneTouchSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TouchSwitch",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.TouchSwitch"]), true);
        }

        private static void RegisterInteractionSceneWallBooster(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.WallBooster",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.WallBooster"]), true);
        }
    }
}
