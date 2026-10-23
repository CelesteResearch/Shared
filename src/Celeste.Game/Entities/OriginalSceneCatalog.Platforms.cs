using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterPlatformsSceneBounceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BounceBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.BounceBlock.BreakDebris",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.BounceBlock.RespawnDebris",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneBridge(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Bridge",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.BridgeFixed",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.BridgeTile",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneCloud(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Cloud",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneCrumblePlatform(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CrumblePlatform",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneCrushBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CrushBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneDreamBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DreamBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.DreamBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsSceneFallingBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FallingBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.FallingBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsSceneFinalBossMovingBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FinalBossMovingBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.FinalBossMovingBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsSceneFloatySpaceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FloatySpaceBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.FloatySpaceBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsSceneGlassBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GlassBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.GlassBlock", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.GlassBlockBg",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneGoldenBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GoldenBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.GoldenBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsSceneIntroCrusher(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IntroCrusher",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneJumpthruPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.JumpthruPlatform",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneMoveBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MoveBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.MoveBlock.Border",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.MoveBlock.Debris",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
            result.Register(
                new("Celeste.MovingPlatform",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
            result.Register(
                new("Celeste.MovingPlatformLine",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneNegaBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.NegaBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.NegaBlock", "Celeste.Solid", "Celeste.Platform"]), true);
        }

        private static void RegisterPlatformsScenePlateau(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Plateau",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneRotatingPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RotatingPlatform",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }

        private static void RegisterPlatformsSceneSinkingPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SinkingPlatform",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
            result.Register(
                new("Celeste.SinkingPlatformLine",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneSolidOnInvinciblePlayer(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SolidOnInvinciblePlayer", (string[])["Monocle.Component"],
                    (string[])["Celeste.SolidOnInvinciblePlayer"]), true);
            result.Register(
                new("Celeste.SolidOnInvinciblePlayer.Outline",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneStarJumpBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StarJumpBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.StarJumpBlock", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.StarJumpController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.StarJumpController"]), true);
            result.Register(
                new("Celeste.Mod.Entities.StarClimbGraphicsController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Mod.Entities.StarClimbGraphicsController"]), true);
        }

        private static void RegisterPlatformsSceneSwapBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SwapBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.SwapBlock", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.SwapBlock.PathRenderer",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlatformsSceneZipMover(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ZipMover",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.ZipMover.ZipMoverPathRenderer",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
