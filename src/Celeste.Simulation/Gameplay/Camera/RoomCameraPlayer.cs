using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraPlayer
    {
        public Vector2 Position, Speed, Anchor, AnchorLerp;
        public Bounds Collider;
        public readonly CameraPlayerStateRoles StateRoles;
        public int State;
        public bool EnforceLevelBounds = true, ForceCameraUpdate, AnchorIgnoreX, AnchorIgnoreY;
        public Bounds Bounds => Collider.At(Position);

        public RoomCameraPlayer(Bounds collider, CameraPlayerStateRoles stateRoles)
        {
            Collider = collider;
            StateRoles = stateRoles;
        }

        public bool InControl => StateRoles.InControl(State);
    }
}
