using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterDecorationSceneBigWaterfall(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BigWaterfall",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneBonfire(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Bonfire",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Bonfire"]), true);
        }

        private static void RegisterDecorationSceneCliffFlags(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CliffFlags",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CliffsideWindFlag",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneClothesline(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Clothesline",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneCobweb(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Cobweb",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneDecal(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Decal",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Decal.Banner", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Celeste.Decal.CoreSwapImage", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.Decal.DecalImage", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Celeste.Decal.FinalFlagDecalImage", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.Decal.FlagSwapImage", (string[])["Monocle.Component"],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneFlagline(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Flagline", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterDecorationSceneFlutterBird(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FlutterBird",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FlutterBird"]), true);
        }

        private static void RegisterDecorationSceneHangingLamp(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.HangingLamp",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneLamp(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Lamp",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneResortLantern(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ResortLantern",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneTorch(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Torch",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterDecorationSceneWire(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Wire",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
