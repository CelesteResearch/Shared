using System;
using Celeste.Game.Presentation.Mountain.Input;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.Mouse;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMountainDebugInputEnvironment,
        IOriginalMountainDebugInput, IOriginalMountainCameraBindingsEnvironment, IOriginalMountainCameraBindings
    {
        IOriginalMountainDebugInput IOriginalMountainDebugInputEnvironment.MountainDebugInput => this;
        IOriginalMountainCameraBindings IOriginalMountainCameraBindingsEnvironment.MountainCameraBindings => this;

        bool IOriginalMountainDebugInput.KeyboardCheck(SourceKeys key)
        {
            return MInput.Keyboard.Check(key);
        }

        bool IOriginalMountainDebugInput.KeyboardPressed(SourceKeys key)
        {
            return MInput.Keyboard.Pressed(key);
        }

        bool IOriginalMountainDebugInput.CheckLeftButton => MInput.Mouse.CheckLeftButton;

        SourceMouseState IOriginalMountainDebugInput.GetMousePosition()
        {
            return MInput.PhysicalMouse.GetState();
        }

        void IOriginalMountainDebugInput.SetMousePosition(int x, int y)
        {
            MInput.PhysicalMouse.SetPosition(x, y);
        }

        void IOriginalMountainDebugInput.WriteConsoleLine(string value)
        {
            Console.WriteLine(value);
        }

        bool IOriginalMountainCameraBindings.CameraForwardCheck => CurrentCoreSettings.CameraForward.Check;
        bool IOriginalMountainCameraBindings.CameraBackwardCheck => CurrentCoreSettings.CameraBackward.Check;
        bool IOriginalMountainCameraBindings.CameraRightCheck => CurrentCoreSettings.CameraRight.Check;
        bool IOriginalMountainCameraBindings.CameraLeftCheck => CurrentCoreSettings.CameraLeft.Check;
        bool IOriginalMountainCameraBindings.CameraUpCheck => CurrentCoreSettings.CameraUp.Check;
        bool IOriginalMountainCameraBindings.CameraDownCheck => CurrentCoreSettings.CameraDown.Check;
        bool IOriginalMountainCameraBindings.CameraSlowCheck => CurrentCoreSettings.CameraSlow.Check;
        bool IOriginalMountainCameraBindings.CameraPrintPressed => CurrentCoreSettings.CameraPrint.Pressed;

        bool IOriginalMountainCameraBindings.ToggleMountainFreeCamPressed =>
            CurrentCoreSettings.ToggleMountainFreeCam.Pressed;
    }
}
