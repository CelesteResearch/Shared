using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterWallsAndDoorsSceneCoverupWall(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CoverupWall",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CoverupWall" }), true);
        }

        private static void RegisterWallsAndDoorsSceneCrumbleWallOnRumble(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CrumbleWallOnRumble",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.CrumbleWallOnRumble", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterWallsAndDoorsSceneDashBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DashBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.DashBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterWallsAndDoorsSceneDoor(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Door",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        "Celeste.Door",
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
        }

        private static void RegisterWallsAndDoorsSceneExitBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ExitBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.ExitBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterWallsAndDoorsSceneFakeWall(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FakeWall",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FakeWall" }), true);
        }

        private static void RegisterWallsAndDoorsSceneHeartGemDoor(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.HeartGemDoor",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.HeartGemDoor.WhiteLine",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterWallsAndDoorsSceneIntroCarBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IntroCarBarrier",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterWallsAndDoorsSceneInvisibleBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.InvisibleBarrier",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.InvisibleBarrier", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterWallsAndDoorsSceneLockBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LockBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterWallsAndDoorsSceneMrOshiroDoor(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MrOshiroDoor",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterWallsAndDoorsSceneRidgeGate(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RidgeGate",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterWallsAndDoorsSceneRumbleTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RumbleTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterWallsAndDoorsSceneSwitchGate(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SwitchGate",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterWallsAndDoorsSceneTrapdoor(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Trapdoor",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterWallsAndDoorsSceneWhiteBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.WhiteBlock",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }
    }
}
