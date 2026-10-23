using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterSceneComponentsSceneBeforeRenderHook(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BeforeRenderHook", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.BeforeRenderHook" }), true);
        }

        private static void RegisterSceneComponentsSceneClimbBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ClimbBlocker", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.ClimbBlocker" }), true);
        }

        private static void RegisterSceneComponentsSceneDashListener(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DashListener", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.DashListener" }), true);
        }

        private static void RegisterSceneComponentsSceneDisplacementRenderHook(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DisplacementRenderHook", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.DisplacementRenderHook" }), true);
        }

        private static void RegisterSceneComponentsSceneEffectCutout(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.EffectCutout", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.EffectCutout" }), true);
        }

        private static void RegisterSceneComponentsSceneFollower(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Follower", new string[] { "Monocle.Component" }, new string[] { }), false);
        }

        private static void RegisterSceneComponentsSceneHoldable(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Holdable", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Holdable" }), true);
            result.Register(
                new SceneEntityType("Celeste.HoldableCollider", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.HoldableCollider" }), true);
        }

        private static void RegisterSceneComponentsSceneLeader(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Leader", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.LedgeBlocker", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.LedgeBlocker" }), true);
            result.Register(
                new SceneEntityType("Celeste.LevelEndingHook", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.LevelEndingHook" }), true);
        }

        private static void RegisterSceneComponentsScenePlayerCollider(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlayerCollider", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.PlayerCollider" }), true);
        }

        private static void RegisterSceneComponentsScenePostUpdateHook(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PostUpdateHook", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.PostUpdateHook" }), true);
        }

        private static void RegisterSceneComponentsSceneSafeGroundBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SafeGroundBlocker", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.SafeGroundBlocker" }), true);
        }

        private static void RegisterSceneComponentsSceneStaticMover(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StaticMover", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.StaticMover" }), true);
        }

        private static void RegisterSceneComponentsSceneTileInterceptor(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TileInterceptor", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.TileInterceptor" }), true);
        }

        private static void RegisterSceneComponentsSceneTransitionListener(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TransitionListener", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.TransitionListener" }), true);
        }
    }
}
