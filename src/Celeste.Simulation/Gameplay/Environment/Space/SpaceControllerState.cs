using Celeste.Physics.Collision;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Environment.Space
{
    // Level.LoadLevel adds one SpaceController before map entities when LevelData.Space is true.
    // SpaceController.Update wraps the tracked player at the camera's vertical edges.
    public sealed class SpaceControllerState
    {
        public void Update(PixelActor player, global::Celeste.Core.Geometry.Bounds camera)
        {
            if (player == null) return;

            global::Celeste.Core.Geometry.Bounds collider = player.Hitbox;
            float top = player.Position.Y + collider.Y;
            float bottom = player.Position.Y + collider.Bottom;
            if (top > camera.Bottom + 12f)
                player.Position = new Vector2(player.Position.X, camera.Y - 4f - collider.Bottom);
            else if (bottom < camera.Y - 4f)
                player.Position = new Vector2(player.Position.X, camera.Bottom + 12f - collider.Y);
            // Entity.Top/Bottom setters write Position.Y directly; Actor's movement
            // remainder, Speed and StateMachine state are untouched.
        }
    }
}
