using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEnvironmentSceneBlackholeStrengthTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BlackholeStrengthTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterEnvironmentSceneLavaRect(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LavaRect", new string[] { "Monocle.Component" }, new string[] { }), false);
        }

        private static void RegisterEnvironmentSceneMoonCreature(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MoonCreature",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.MoonGlitchBackgroundTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterEnvironmentSceneRisingLava(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RisingLava",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterEnvironmentSceneSandwichLava(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SandwichLava",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterEnvironmentSceneSpaceController(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SpaceController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterEnvironmentSceneWater(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Water",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Water" }), true);
            result.Register(
                new SceneEntityType("Celeste.WaterFall",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.WaterFall" }), true);
            result.Register(
                new SceneEntityType("Celeste.WaterInteraction", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.WaterInteraction" }), true);
            result.Register(
                new SceneEntityType("Celeste.WaterSurface",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.WaterSurface" }), true);
        }

        private static void RegisterEnvironmentSceneWindAttackTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.WindAttackTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.WindController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.WindMover", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.WindMover" }), true);
            result.Register(
                new SceneEntityType("Celeste.WindTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.WindTrigger", "Celeste.Trigger" }), true);
        }
    }
}
