using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEnvironmentSceneBlackholeStrengthTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BlackholeStrengthTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterEnvironmentSceneLavaRect(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LavaRect", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterEnvironmentSceneMoonCreature(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MoonCreature",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.MoonGlitchBackgroundTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterEnvironmentSceneRisingLava(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RisingLava",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterEnvironmentSceneSandwichLava(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SandwichLava",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterEnvironmentSceneSpaceController(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SpaceController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterEnvironmentSceneWater(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Water",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Water"]), true);
            result.Register(
                new("Celeste.WaterFall",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.WaterFall"]), true);
            result.Register(
                new("Celeste.WaterInteraction", (string[])["Monocle.Component"],
                    (string[])["Celeste.WaterInteraction"]), true);
            result.Register(
                new("Celeste.WaterSurface",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.WaterSurface"]), true);
        }

        private static void RegisterEnvironmentSceneWindAttackTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.WindAttackTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.WindController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.WindMover", (string[])["Monocle.Component"],
                    (string[])["Celeste.WindMover"]), true);
            result.Register(
                new("Celeste.WindTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.WindTrigger", "Celeste.Trigger"]), true);
        }
    }
}
