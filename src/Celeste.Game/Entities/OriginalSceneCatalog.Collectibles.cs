using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCollectiblesSceneCassette(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Cassette",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.Cassette.UnlockedBSide",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterCollectiblesSceneDetachStrawberryTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DetachStrawberryTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterCollectiblesSceneDreamHeartGem(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DreamHeartGem",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterCollectiblesSceneFakeHeart(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FakeHeart",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterCollectiblesSceneFlyFeather(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FlyFeather",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FlyFeather" }), true);
        }

        private static void RegisterCollectiblesSceneGoldBerryCollectTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GoldBerryCollectTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.GoldBerryCollectTrigger", "Celeste.Trigger" }), true);
        }

        private static void RegisterCollectiblesSceneHeartGem(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.HeartGem",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.HeartGem" }), true);
        }

        private static void RegisterCollectiblesSceneKey(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Key",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterCollectiblesSceneRefill(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Refill",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterCollectiblesSceneStrawberry(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Strawberry",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.StrawberryPoints",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.StrawberryPoints" }), true);
            result.Register(
                new SceneEntityType("Celeste.StrawberrySeed",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.StrawberrySeed" }), true);
        }
    }
}
