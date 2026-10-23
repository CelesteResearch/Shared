using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterModAudioCameraSceneModEntitiesAmbienceTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.AmbienceTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.AmbienceVolumeTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterModAudioCameraSceneModEntitiesMusicLayerTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.MusicLayerTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterModAudioCameraSceneModEntitiesSmoothCameraOffsetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Mod.Entities.SmoothCameraOffsetTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }
    }
}
