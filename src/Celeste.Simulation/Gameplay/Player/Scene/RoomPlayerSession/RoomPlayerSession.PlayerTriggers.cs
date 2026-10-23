using Celeste.Scene.Tracking;
using Celeste.Scene.Triggers;
using Celeste.Simulation.Gameplay.Camera;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PlayerTriggerSet<RoomPlayerSession> PlayerTriggers { get; } = new();

        public RoomCameraPlayer TriggerCameraState { get; set; }

        public void CheckSourcePlayerTriggers()
        {
            if (Machine.State == 18) return;
            var scene = (ISourceScene)Scene;
            foreach (var entry in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Trigger"))
                PlayerTriggers.Update(this, (ISourcePlayerTrigger<RoomPlayerSession>)entry);
        }

        public void CleanUpPlayerTriggers()
        {
            PlayerTriggers.CleanUp(this);
        }
    }
}
