namespace Celeste.Game.Presentation.Mountain.Input
{
    public interface IOriginalMountainCameraBindings
    {
        bool CameraForwardCheck { get; }
        bool CameraBackwardCheck { get; }
        bool CameraRightCheck { get; }
        bool CameraLeftCheck { get; }
        bool CameraUpCheck { get; }
        bool CameraDownCheck { get; }
        bool CameraSlowCheck { get; }
        bool CameraPrintPressed { get; }
        bool ToggleMountainFreeCamPressed { get; }
    }
}
