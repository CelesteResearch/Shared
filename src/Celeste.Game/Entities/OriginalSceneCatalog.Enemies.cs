using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEnemiesSceneAngryOshiro(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AngryOshiro",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.AngryOshiro" }), true);
        }

        private static void RegisterEnemiesSceneBadelineOldsite(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BadelineOldsite",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.BadelineOldsite" }), true);
        }

        private static void RegisterEnemiesSceneFinalBoss(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FinalBoss",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FinalBoss" }), true);
            result.Register(
                new SceneEntityType("Celeste.FinalBossBeam",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FinalBossBeam" }), true);
        }

        private static void RegisterEnemiesSceneFinalBossShot(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FinalBossShot",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.FinalBossShot" }), true);
        }

        private static void RegisterEnemiesScenePlayerSeeker(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlayerSeeker",
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

        private static void RegisterEnemiesSceneSeeker(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Seeker",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        "Celeste.Seeker",
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
            result.Register(
                new SceneEntityType("Celeste.Seeker.RecoverBlast",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.SeekerBarrier",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.SeekerBarrier", "Celeste.Solid", "Celeste.Platform" }), true);
            result.Register(
                new SceneEntityType("Celeste.SeekerBarrierRenderer",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.SeekerBarrierRenderer" }), true);
            result.Register(
                new SceneEntityType("Celeste.SeekerCollider", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.SeekerCollider" }), true);
            result.Register(
                new SceneEntityType("Celeste.SeekerEffectsController",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.SeekerStatue",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
