using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHudSceneAreaCompleteTitle(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AreaCompleteTitle",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneBestTimeDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BestTimeDisplay", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterHudSceneDeathsCounter(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DeathsCounter", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterHudSceneGameplayStats(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GameplayStats",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneHeartGemDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.HeartGemDisplay", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterHudSceneHeightDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.HeightDisplay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneMiniTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MiniTextbox",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.MiniTextbox" }), true);
            result.Register(
                new SceneEntityType("Celeste.MiniTextboxTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterHudSceneQuickResetHint(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.QuickResetHint",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneReturnMapHint(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ReturnMapHint",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneSaveLoadIcon(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SaveLoadIcon",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHudSceneSpeedrunTimerDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SpeedrunTimerDisplay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHudSceneStrawberriesCounter(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StrawberriesCounter", new string[] { "Monocle.Component" },
                    new string[] { }), false);
        }

        private static void RegisterHudSceneTotalStrawberriesDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TotalStrawberriesDisplay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHudSceneUnlockedRemixDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.UnlockedRemixDisplay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
