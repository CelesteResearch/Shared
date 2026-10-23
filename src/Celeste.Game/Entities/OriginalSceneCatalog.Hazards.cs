using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHazardsSceneBladeRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BladeRotateSpinner",
                    (string[])["Celeste.RotateSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.BladeTrackSpinner",
                    (string[])["Celeste.TrackSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneChaserBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ChaserBarrier",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.ChaserBarrier"]), true);
        }

        private static void RegisterHazardsSceneCrystalStaticSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CrystalStaticSpinner",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CrystalStaticSpinner"]), true);
            result.Register(
                new("Celeste.CrystalStaticSpinner.Border",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CrystalStaticSpinner.CoreModeListener",
                    (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterHazardsSceneDustEdge(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DustEdge", (string[])["Monocle.Component"],
                    (string[])["Celeste.DustEdge"]), true);
            result.Register(
                new("Celeste.DustEdges",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.DustEdges"]), true);
            result.Register(
                new("Celeste.DustGraphic", (string[])["Monocle.Component"],
                    (string[])["Celeste.DustGraphic"]), true);
            result.Register(
                new("Celeste.DustGraphic.Eyeballs",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.DustRotateSpinner",
                    (string[])["Celeste.RotateSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.DustStaticSpinner",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.DustStaticSpinner"]), true);
            result.Register(
                new("Celeste.DustTrackSpinner",
                    (string[])["Celeste.TrackSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneFireBall(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FireBall",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.FireBarrier",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneIceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IceBlock",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneKillbox(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Killbox",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Killbox"]), true);
        }

        private static void RegisterHazardsSceneLightning(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Lightning",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.LightningBreakerBox",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.LightningRenderer",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.LightningRenderer"]), true);
            result.Register(
                new("Celeste.LightningStrike",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsScenePuffer(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Puffer",
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
                new("Celeste.PufferCollider", (string[])["Monocle.Component"],
                    (string[])["Celeste.PufferCollider"]), true);
        }

        private static void RegisterHazardsSceneRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.RotateSpinner",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneSnowball(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Snowball",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneSpikes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Spikes",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Spikes"]), true);
        }

        private static void RegisterHazardsSceneStarRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StarRotateSpinner",
                    (string[])["Celeste.RotateSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.StarTrackSpinner",
                    (string[])["Celeste.TrackSpinner", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneTrackSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TrackSpinner",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterHazardsSceneTriggerSpikes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TriggerSpikes",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
