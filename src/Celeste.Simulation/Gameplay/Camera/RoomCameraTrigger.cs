using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraTrigger
    {
        public readonly global::Celeste.Core.Maps.MapElement Source;
        public readonly global::Celeste.Simulation.Gameplay.Camera.RoomCameraTriggerKind Kind;
        public global::Celeste.Core.Geometry.Bounds Bounds;
        public Vector2 Target, Strength;
        public global::Celeste.Simulation.Gameplay.Camera.RoomCameraPositionMode PositionModeX, PositionModeY;
        public bool XOnly, YOnly, Collidable = true;
        public bool Triggered { get; internal set; }
        public bool PlayerIsInside { get; internal set; }
        public string DeleteFlag;

        public RoomCameraTrigger(global::Celeste.Core.Maps.MapElement source,
            global::Celeste.Simulation.Gameplay.Camera.RoomCameraTriggerKind kind,
            global::Celeste.Core.Geometry.Bounds bounds)
        {
            Source = source;
            Kind = kind;
            Bounds = bounds;
        }
    }
}
