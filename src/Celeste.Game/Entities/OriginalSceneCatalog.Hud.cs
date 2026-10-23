using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHudSceneAreaCompleteTitle(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AreaCompleteTitle",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneBestTimeDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BestTimeDisplay", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterHudSceneDeathsCounter(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DeathsCounter", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterHudSceneGameplayStats(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GameplayStats",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneHeartGemDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.HeartGemDisplay", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterHudSceneHeightDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.HeightDisplay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneMiniTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MiniTextbox",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.MiniTextbox"]), true);
            result.Register(
                new("Celeste.MiniTextboxTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterHudSceneQuickResetHint(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.QuickResetHint",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneReturnMapHint(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ReturnMapHint",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneSaveLoadIcon(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SaveLoadIcon",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneSpeedrunTimerDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SpeedrunTimerDisplay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneStrawberriesCounter(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StrawberriesCounter", (string[])["Monocle.Component"],
                    (string[])[]));
        }

        private static void RegisterHudSceneTotalStrawberriesDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TotalStrawberriesDisplay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHudSceneUnlockedRemixDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.UnlockedRemixDisplay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
