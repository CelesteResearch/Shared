using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool IsOverWater()
        {
            var bounds = Collider.Bounds;
            bounds.Height += 2;
            return SourceSceneCollision.CheckRect(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Water", bounds);
        }
    }
}
