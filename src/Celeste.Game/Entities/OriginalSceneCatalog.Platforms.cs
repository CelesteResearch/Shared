using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterPlatformsSceneBounceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BounceBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.BounceBlock.BreakDebris",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.BounceBlock.RespawnDebris",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterPlatformsSceneBridge(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Bridge",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.BridgeFixed",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.BridgeTile",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneCloud(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Cloud",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneCrumblePlatform(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CrumblePlatform",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneCrushBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CrushBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneDreamBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DreamBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.DreamBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsSceneFallingBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FallingBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.FallingBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsSceneFinalBossMovingBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FinalBossMovingBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.FinalBossMovingBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsSceneFloatySpaceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FloatySpaceBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.FloatySpaceBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsSceneGlassBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GlassBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.GlassBlock", "Celeste.Solid", "Celeste.Platform" }), true);
            result.Register(
                new SceneEntityType("Celeste.GlassBlockBg",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterPlatformsSceneGoldenBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GoldenBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.GoldenBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsSceneIntroCrusher(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IntroCrusher",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneJumpthruPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.JumpthruPlatform",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneMoveBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MoveBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.MoveBlock.Border",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.MoveBlock.Debris",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
            result.Register(
                new SceneEntityType("Celeste.MovingPlatform",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.MovingPlatformLine",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterPlatformsSceneNegaBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.NegaBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.NegaBlock", "Celeste.Solid", "Celeste.Platform" }), true);
        }

        private static void RegisterPlatformsScenePlateau(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Plateau",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneRotatingPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RotatingPlatform",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }

        private static void RegisterPlatformsSceneSinkingPlatform(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SinkingPlatform",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.SinkingPlatformLine",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterPlatformsSceneSolidOnInvinciblePlayer(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SolidOnInvinciblePlayer", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.SolidOnInvinciblePlayer" }), true);
            result.Register(
                new SceneEntityType("Celeste.SolidOnInvinciblePlayer.Outline",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterPlatformsSceneStarJumpBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StarJumpBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.StarJumpBlock", "Celeste.Solid", "Celeste.Platform" }), true);
            result.Register(
                new SceneEntityType("Celeste.StarJumpController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.StarJumpController" }), true);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.StarClimbGraphicsController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Mod.Entities.StarClimbGraphicsController" }), true);
        }

        private static void RegisterPlatformsSceneSwapBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SwapBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.SwapBlock", "Celeste.Solid", "Celeste.Platform" }), true);
            result.Register(
                new SceneEntityType("Celeste.SwapBlock.PathRenderer",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterPlatformsSceneZipMover(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ZipMover",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.ZipMover.ZipMoverPathRenderer",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
