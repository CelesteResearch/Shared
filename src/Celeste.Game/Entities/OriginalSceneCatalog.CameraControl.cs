using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCameraControlSceneCameraAdvanceTargetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CameraAdvanceTargetTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CameraAdvanceTargetTrigger", "Celeste.Trigger" }), true);
            result.Register(
                new SceneEntityType("Celeste.CameraLocker", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.CameraLocker" }), true);
            result.Register(
                new SceneEntityType("Celeste.CameraOffsetTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.CameraTargetTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CameraTargetTrigger", "Celeste.Trigger" }), true);
        }
    }
}
