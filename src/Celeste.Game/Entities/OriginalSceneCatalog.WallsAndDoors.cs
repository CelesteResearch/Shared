using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterWallsAndDoorsSceneCoverupWall(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CoverupWall",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CoverupWall"]), true);
        }

        private static void RegisterWallsAndDoorsSceneCrumbleWallOnRumble(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CrumbleWallOnRumble",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.CrumbleWallOnRumble", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterWallsAndDoorsSceneDashBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DashBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.DashBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterWallsAndDoorsSceneDoor(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Door",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        "Celeste.Door",
                        typeof(SourceActorEntityState).FullName,
                    ]), true);
        }

        private static void RegisterWallsAndDoorsSceneExitBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ExitBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.ExitBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterWallsAndDoorsSceneFakeWall(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FakeWall",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FakeWall"]), true);
        }

        private static void RegisterWallsAndDoorsSceneHeartGemDoor(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.HeartGemDoor",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.HeartGemDoor.WhiteLine",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterWallsAndDoorsSceneIntroCarBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IntroCarBarrier",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterWallsAndDoorsSceneInvisibleBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.InvisibleBarrier",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.InvisibleBarrier", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterWallsAndDoorsSceneLockBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LockBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterWallsAndDoorsSceneMrOshiroDoor(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MrOshiroDoor",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterWallsAndDoorsSceneRidgeGate(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RidgeGate",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterWallsAndDoorsSceneRumbleTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RumbleTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterWallsAndDoorsSceneSwitchGate(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SwitchGate",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterWallsAndDoorsSceneTrapdoor(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Trapdoor",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterWallsAndDoorsSceneWhiteBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.WhiteBlock",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }
    }
}
