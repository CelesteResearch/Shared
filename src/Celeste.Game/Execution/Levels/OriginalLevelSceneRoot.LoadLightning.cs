using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void ResetSourceFirstLightningRenderer()
        {
            Scheduler.Entities.FindFirst<LightningRendererState>()?.Reset();
        }

        private void SetSourceRoomLightningAmbience(bool hasRoomLightning)
        {
            var tracked = Scheduler.Entities.GetTrackedEntities("Celeste.LightningRenderer");
            var renderer = tracked.Count == 0 ? null : (LightningRendererState)tracked[0];
            if (renderer != null)
            {
                if (hasRoomLightning)
                    renderer.StartAmbience();
                else
                    renderer.StopAmbience();
            }
        }
    }
}
