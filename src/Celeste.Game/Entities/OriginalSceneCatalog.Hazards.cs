using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHazardsSceneBladeRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BladeRotateSpinner",
                    new string[]
                        { "Celeste.RotateSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.BladeTrackSpinner",
                    new string[]
                        { "Celeste.TrackSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneChaserBarrier(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ChaserBarrier",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.ChaserBarrier" }), true);
        }

        private static void RegisterHazardsSceneCrystalStaticSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CrystalStaticSpinner",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CrystalStaticSpinner" }), true);
            result.Register(
                new SceneEntityType("Celeste.CrystalStaticSpinner.Border",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CrystalStaticSpinner.CoreModeListener",
                    new string[] { "Monocle.Component" }, new string[] { }), false);
        }

        private static void RegisterHazardsSceneDustEdge(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DustEdge", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.DustEdge" }), true);
            result.Register(
                new SceneEntityType("Celeste.DustEdges",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.DustEdges" }), true);
            result.Register(
                new SceneEntityType("Celeste.DustGraphic", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.DustGraphic" }), true);
            result.Register(
                new SceneEntityType("Celeste.DustGraphic.Eyeballs",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.DustRotateSpinner",
                    new string[]
                        { "Celeste.RotateSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.DustStaticSpinner",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.DustStaticSpinner" }), true);
            result.Register(
                new SceneEntityType("Celeste.DustTrackSpinner",
                    new string[]
                        { "Celeste.TrackSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneFireBall(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FireBall",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.FireBarrier",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneIceBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IceBlock",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneKillbox(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Killbox",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Killbox" }), true);
        }

        private static void RegisterHazardsSceneLightning(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Lightning",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.LightningBreakerBox",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.LightningRenderer",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.LightningRenderer" }), true);
            result.Register(
                new SceneEntityType("Celeste.LightningStrike",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHazardsScenePuffer(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Puffer",
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
                new SceneEntityType("Celeste.PufferCollider", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.PufferCollider" }), true);
        }

        private static void RegisterHazardsSceneRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.RotateSpinner",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHazardsSceneSnowball(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Snowball",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneSpikes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Spikes",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Spikes" }), true);
        }

        private static void RegisterHazardsSceneStarRotateSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StarRotateSpinner",
                    new string[]
                        { "Celeste.RotateSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.StarTrackSpinner",
                    new string[]
                        { "Celeste.TrackSpinner", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterHazardsSceneTrackSpinner(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TrackSpinner",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterHazardsSceneTriggerSpikes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TriggerSpikes",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
