using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Camera;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceCameraPlayer
    {
        public bool ForceCameraUpdate;
        public bool EnforceLevelBounds = true;
        public Vector2 CameraAnchor;
        public Vector2 CameraAnchorLerp;
        public bool CameraAnchorIgnoreX;
        public bool CameraAnchorIgnoreY;

        public Vector2 CameraTarget
        {
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices
                .MethodImplOptions.NoInlining)]
            get => ((ISourcePlayerCameraScene)Scene).PlayerCamera.Target(this);
        }

        Vector2 ISourceCameraPlayer.Position
        {
            get => Body.Position;
            set => Body.Position = value;
        }

        Vector2 ISourceCameraPlayer.Speed => Data.Motion.Normal.Speed;
        int ISourceCameraPlayer.State => Machine.State;
        IntRect ISourceCameraPlayer.Bounds => Collider.Bounds;

        bool ISourceCameraPlayer.ForceCameraUpdate
        {
            get => ForceCameraUpdate;
            set => ForceCameraUpdate = value;
        }

        bool ISourceCameraPlayer.EnforceLevelBounds
        {
            get => EnforceLevelBounds;
            set => EnforceLevelBounds = value;
        }

        Vector2 ISourceCameraPlayer.CameraAnchor
        {
            get => CameraAnchor;
            set => CameraAnchor = value;
        }

        Vector2 ISourceCameraPlayer.CameraAnchorLerp
        {
            get => CameraAnchorLerp;
            set => CameraAnchorLerp = value;
        }

        bool ISourceCameraPlayer.CameraAnchorIgnoreX
        {
            get => CameraAnchorIgnoreX;
            set => CameraAnchorIgnoreX = value;
        }

        bool ISourceCameraPlayer.CameraAnchorIgnoreY
        {
            get => CameraAnchorIgnoreY;
            set => CameraAnchorIgnoreY = value;
        }
    }
}
