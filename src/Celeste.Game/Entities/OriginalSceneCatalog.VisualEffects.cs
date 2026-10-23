using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterVisualEffectsSceneAbsorbOrb(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AbsorbOrb",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterVisualEffectsSceneBackgroundFadeIn(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BackgroundFadeIn",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterVisualEffectsSceneCrystalDebris(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CrystalDebris",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
        }

        private static void RegisterVisualEffectsSceneCustomBloom(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CustomBloom", (string[])["Monocle.Component"],
                    (string[])["Celeste.CustomBloom"]), true);
        }

        private static void RegisterVisualEffectsSceneDeathEffect(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DeathEffect", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterVisualEffectsSceneDebris(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Debris",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
        }

        private static void RegisterVisualEffectsSceneDisperseImage(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DisperseImage",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterVisualEffectsSceneFallEffects(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FallEffects",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FallEffects"]), true);
        }

        private static void RegisterVisualEffectsSceneFloatingDebris(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FloatingDebris",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FloatingDebris"]), true);
        }

        private static void RegisterVisualEffectsSceneForegroundDebris(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ForegroundDebris",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterVisualEffectsSceneLevelUpEffect(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LevelUpEffect",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterVisualEffectsSceneSlashFx(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SlashFx",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.SlashFx"]), true);
        }

        private static void RegisterVisualEffectsSceneSpeedRing(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SpeedRing",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.SpeedRing"]), true);
        }

        private static void RegisterVisualEffectsSceneTrailManager(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TrailManager",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.TrailManager"]), true);
            result.Register(
                new("Celeste.TrailManager.Snapshot",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.TrailManager.Snapshot"]), true);
        }
    }
}
