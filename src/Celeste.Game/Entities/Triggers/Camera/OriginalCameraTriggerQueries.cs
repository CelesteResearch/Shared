using System.Numerics;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Triggers.Camera
{
    internal static class OriginalCameraTriggerQueries
    {
        internal static void ClearAnchorWhenOutside(object actualScene, RoomPlayerSession player)
        {
            var inside = false;
            foreach (var item in ((ISourceScene)actualScene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CameraTargetTrigger"))
            {
                var trigger = (OriginalCameraTargetTriggerState)item;
                if (trigger.PlayerIsInside)
                {
                    inside = true;
                    break;
                }
            }

            if (!inside)
                foreach (var item in ((ISourceScene)actualScene).SourceScene.Entities.GetTrackedEntities(
                             "Celeste.CameraAdvanceTargetTrigger"))
                {
                    var trigger = (OriginalCameraAdvanceTargetTriggerState)item;
                    if (trigger.PlayerIsInside)
                    {
                        inside = true;
                        break;
                    }
                }

            if (!inside) player.CameraAnchorLerp = Vector2.Zero;
        }
    }
}
