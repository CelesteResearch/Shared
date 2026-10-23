using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterVisualEffectsSceneAbsorbOrb(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AbsorbOrb",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterVisualEffectsSceneBackgroundFadeIn(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BackgroundFadeIn",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterVisualEffectsSceneCrystalDebris(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CrystalDebris",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
        }

        private static void RegisterVisualEffectsSceneCustomBloom(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CustomBloom", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.CustomBloom" }), true);
        }

        private static void RegisterVisualEffectsSceneDeathEffect(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DeathEffect", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterVisualEffectsSceneDebris(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Debris",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
        }

        private static void RegisterVisualEffectsSceneDisperseImage(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DisperseImage",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterVisualEffectsSceneFallEffects(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FallEffects",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FallEffects" }), true);
        }

        private static void RegisterVisualEffectsSceneFloatingDebris(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FloatingDebris",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FloatingDebris" }), true);
        }

        private static void RegisterVisualEffectsSceneForegroundDebris(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ForegroundDebris",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterVisualEffectsSceneLevelUpEffect(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LevelUpEffect",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterVisualEffectsSceneSlashFx(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SlashFx",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.SlashFx" }), true);
        }

        private static void RegisterVisualEffectsSceneSpeedRing(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SpeedRing",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.SpeedRing" }), true);
        }

        private static void RegisterVisualEffectsSceneTrailManager(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TrailManager",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.TrailManager" }), true);
            result.Register(
                new SceneEntityType("Celeste.TrailManager.Snapshot",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.TrailManager.Snapshot" }), true);
        }
    }
}
