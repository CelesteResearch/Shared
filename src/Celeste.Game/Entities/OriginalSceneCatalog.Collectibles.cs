using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCollectiblesSceneCassette(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Cassette",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Cassette.UnlockedBSide",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterCollectiblesSceneDetachStrawberryTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DetachStrawberryTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterCollectiblesSceneDreamHeartGem(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DreamHeartGem",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterCollectiblesSceneFakeHeart(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FakeHeart",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterCollectiblesSceneFlyFeather(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FlyFeather",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FlyFeather"]), true);
        }

        private static void RegisterCollectiblesSceneGoldBerryCollectTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GoldBerryCollectTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.GoldBerryCollectTrigger", "Celeste.Trigger"]), true);
        }

        private static void RegisterCollectiblesSceneHeartGem(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.HeartGem",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.HeartGem"]), true);
        }

        private static void RegisterCollectiblesSceneKey(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Key",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterCollectiblesSceneRefill(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Refill",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterCollectiblesSceneStrawberry(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Strawberry",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.StrawberryPoints",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.StrawberryPoints"]), true);
            result.Register(
                new("Celeste.StrawberrySeed",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.StrawberrySeed"]), true);
        }
    }
}
