using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCameraControlSceneCameraAdvanceTargetTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CameraAdvanceTargetTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CameraAdvanceTargetTrigger", "Celeste.Trigger"]), true);
            result.Register(
                new("Celeste.CameraLocker", (string[])["Monocle.Component"],
                    (string[])["Celeste.CameraLocker"]), true);
            result.Register(
                new("Celeste.CameraOffsetTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.CameraTargetTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CameraTargetTrigger", "Celeste.Trigger"]), true);
        }
    }
}
