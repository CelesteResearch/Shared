using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterDecorationSceneBigWaterfall(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BigWaterfall",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneBonfire(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Bonfire",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Bonfire" }), true);
        }

        private static void RegisterDecorationSceneCliffFlags(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CliffFlags",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CliffsideWindFlag",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneClothesline(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Clothesline",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterDecorationSceneCobweb(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Cobweb",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneDecal(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Decal",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Decal.Banner", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Decal.CoreSwapImage", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Decal.DecalImage", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Decal.FinalFlagDecalImage", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Decal.FlagSwapImage", new string[] { "Monocle.Component" },
                    new string[] { }), false);
        }

        private static void RegisterDecorationSceneFlagline(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Flagline", new string[] { "Monocle.Component" }, new string[] { }), false);
        }

        private static void RegisterDecorationSceneFlutterBird(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FlutterBird",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FlutterBird" }), true);
        }

        private static void RegisterDecorationSceneHangingLamp(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.HangingLamp",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterDecorationSceneLamp(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Lamp",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneResortLantern(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ResortLantern",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneTorch(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Torch",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterDecorationSceneWire(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Wire",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
