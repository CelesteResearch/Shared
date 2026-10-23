using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModAudioCameraSceneModEntitiesAmbienceTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.AmbienceTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.Mod.Entities.AmbienceVolumeTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterModAudioCameraSceneModEntitiesMusicLayerTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.MusicLayerTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterModAudioCameraSceneModEntitiesSmoothCameraOffsetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Mod.Entities.SmoothCameraOffsetTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }
    }
}
