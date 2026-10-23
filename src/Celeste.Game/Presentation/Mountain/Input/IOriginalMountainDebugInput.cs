using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Game.Presentation.Mountain.Input
{
    public interface IOriginalMountainDebugInput
    {
        bool KeyboardCheck(SourceKeys key);
        bool KeyboardPressed(SourceKeys key);
        bool CheckLeftButton { get; }
        SourceMouseState GetMousePosition();
        void SetMousePosition(int x, int y);
        void WriteConsoleLine(string value);
    }
}
