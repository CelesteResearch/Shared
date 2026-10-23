using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterInteractionSceneBadelineBoost(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BadelineBoost",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterInteractionSceneBooster(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Booster",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterInteractionSceneBumper(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Bumper",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterInteractionSceneDashSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DashSwitch",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterInteractionSceneInteractTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.InteractTrigger",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterInteractionSceneLookout(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Lookout",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Lookout" }), true);
            result.Register(
                new SceneEntityType("Celeste.Lookout.Hud",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.LookoutBlocker",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.LookoutBlocker" }), true);
        }

        private static void RegisterInteractionSceneSpring(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Spring",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterInteractionSceneSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Switch", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Switch" }), true);
        }

        private static void RegisterInteractionSceneTalkComponent(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TalkComponent", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.TalkComponent.TalkComponentUI",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterInteractionSceneTouchSwitch(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TouchSwitch",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.TouchSwitch" }), true);
        }

        private static void RegisterInteractionSceneWallBooster(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.WallBooster",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.WallBooster" }), true);
        }
    }
}
