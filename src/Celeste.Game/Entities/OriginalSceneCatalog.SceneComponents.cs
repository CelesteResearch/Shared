using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterSceneComponentsSceneBeforeRenderHook(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BeforeRenderHook", (string[])["Monocle.Component"],
                    (string[])["Celeste.BeforeRenderHook"]), true);
        }

        private static void RegisterSceneComponentsSceneClimbBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ClimbBlocker", (string[])["Monocle.Component"],
                    (string[])["Celeste.ClimbBlocker"]), true);
        }

        private static void RegisterSceneComponentsSceneDashListener(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DashListener", (string[])["Monocle.Component"],
                    (string[])["Celeste.DashListener"]), true);
        }

        private static void RegisterSceneComponentsSceneDisplacementRenderHook(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DisplacementRenderHook", (string[])["Monocle.Component"],
                    (string[])["Celeste.DisplacementRenderHook"]), true);
        }

        private static void RegisterSceneComponentsSceneEffectCutout(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.EffectCutout", (string[])["Monocle.Component"],
                    (string[])["Celeste.EffectCutout"]), true);
        }

        private static void RegisterSceneComponentsSceneFollower(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Follower", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterSceneComponentsSceneHoldable(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Holdable", (string[])["Monocle.Component"],
                    (string[])["Celeste.Holdable"]), true);
            result.Register(
                new("Celeste.HoldableCollider", (string[])["Monocle.Component"],
                    (string[])["Celeste.HoldableCollider"]), true);
        }

        private static void RegisterSceneComponentsSceneLeader(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Leader", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Celeste.LedgeBlocker", (string[])["Monocle.Component"],
                    (string[])["Celeste.LedgeBlocker"]), true);
            result.Register(
                new("Celeste.LevelEndingHook", (string[])["Monocle.Component"],
                    (string[])["Celeste.LevelEndingHook"]), true);
        }

        private static void RegisterSceneComponentsScenePlayerCollider(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlayerCollider", (string[])["Monocle.Component"],
                    (string[])["Celeste.PlayerCollider"]), true);
        }

        private static void RegisterSceneComponentsScenePostUpdateHook(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PostUpdateHook", (string[])["Monocle.Component"],
                    (string[])["Celeste.PostUpdateHook"]), true);
        }

        private static void RegisterSceneComponentsSceneSafeGroundBlocker(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SafeGroundBlocker", (string[])["Monocle.Component"],
                    (string[])["Celeste.SafeGroundBlocker"]), true);
        }

        private static void RegisterSceneComponentsSceneStaticMover(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StaticMover", (string[])["Monocle.Component"],
                    (string[])["Celeste.StaticMover"]), true);
        }

        private static void RegisterSceneComponentsSceneTileInterceptor(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TileInterceptor", (string[])["Monocle.Component"],
                    (string[])["Celeste.TileInterceptor"]), true);
        }

        private static void RegisterSceneComponentsSceneTransitionListener(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TransitionListener", (string[])["Monocle.Component"],
                    (string[])["Celeste.TransitionListener"]), true);
        }
    }
}
