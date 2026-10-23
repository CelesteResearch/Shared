using Celeste.Scene.Triggers;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PlayerTriggerSet<RoomPlayerSession> PlayerTriggers { get; } =
            new PlayerTriggerSet<RoomPlayerSession>();

        public global::Celeste.Simulation.Gameplay.Camera.RoomCameraPlayer TriggerCameraState { get; set; }

        public void CheckSourcePlayerTriggers()
        {
            if (Machine.State == 18) return;
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)Scene;
            foreach (var entry in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Trigger"))
                PlayerTriggers.Update(this, (ISourcePlayerTrigger<RoomPlayerSession>)entry);
        }

        public void CleanUpPlayerTriggers() => PlayerTriggers.CleanUp(this);
    }
}
