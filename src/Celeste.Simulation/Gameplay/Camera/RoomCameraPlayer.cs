using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraPlayer
    {
        public Vector2 Position, Speed, Anchor, AnchorLerp;
        public global::Celeste.Core.Geometry.Bounds Collider;
        public readonly CameraPlayerStateRoles StateRoles;
        public int State;
        public bool EnforceLevelBounds = true, ForceCameraUpdate, AnchorIgnoreX, AnchorIgnoreY;
        public global::Celeste.Core.Geometry.Bounds Bounds => Collider.At(Position);

        public RoomCameraPlayer(global::Celeste.Core.Geometry.Bounds collider, CameraPlayerStateRoles stateRoles)
        {
            Collider = collider;
            StateRoles = stateRoles;
        }

        public bool InControl => StateRoles.InControl(State);
    }
}
