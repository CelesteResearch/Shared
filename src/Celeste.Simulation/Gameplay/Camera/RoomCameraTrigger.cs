using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraTrigger
    {
        public readonly MapElement Source;
        public readonly RoomCameraTriggerKind Kind;
        public Bounds Bounds;
        public Vector2 Target, Strength;
        public RoomCameraPositionMode PositionModeX, PositionModeY;
        public bool XOnly, YOnly, Collidable = true;
        public bool Triggered { get; internal set; }
        public bool PlayerIsInside { get; internal set; }
        public string DeleteFlag;

        public RoomCameraTrigger(MapElement source,
            RoomCameraTriggerKind kind,
            Bounds bounds)
        {
            Source = source;
            Kind = kind;
            Bounds = bounds;
        }
    }
}
