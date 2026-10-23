using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEnemiesSceneAngryOshiro(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AngryOshiro",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.AngryOshiro"]), true);
        }

        private static void RegisterEnemiesSceneBadelineOldsite(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BadelineOldsite",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.BadelineOldsite"]), true);
        }

        private static void RegisterEnemiesSceneFinalBoss(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FinalBoss",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FinalBoss"]), true);
            result.Register(
                new("Celeste.FinalBossBeam",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FinalBossBeam"]), true);
        }

        private static void RegisterEnemiesSceneFinalBossShot(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FinalBossShot",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.FinalBossShot"]), true);
        }

        private static void RegisterEnemiesScenePlayerSeeker(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlayerSeeker",
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

        private static void RegisterEnemiesSceneSeeker(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Seeker",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        "Celeste.Seeker",
                        typeof(SourceActorEntityState).FullName,
                    ]), true);
            result.Register(
                new("Celeste.Seeker.RecoverBlast",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.SeekerBarrier",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.SeekerBarrier", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.SeekerBarrierRenderer",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.SeekerBarrierRenderer"]), true);
            result.Register(
                new("Celeste.SeekerCollider", (string[])["Monocle.Component"],
                    (string[])["Celeste.SeekerCollider"]), true);
            result.Register(
                new("Celeste.SeekerEffectsController",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.SeekerStatue",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
