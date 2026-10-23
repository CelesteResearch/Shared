using System.Numerics;
using Celeste.Core.Input;

namespace Celeste.Input.Gameplay
{
    public interface ISourceGameInput
    {
        ISourceVirtualButton this[GameAction action] { get; }
        ISourceVirtualButton Jump { get; }
        ISourceVirtualButton Dash { get; }
        ISourceVirtualButton CrouchDash { get; }
        ISourceVirtualButton Grab { get; }
        ISourceVirtualButton Talk { get; }
        ISourceVirtualButton ESC { get; }
        ISourceVirtualButton Pause { get; }
        ISourceVirtualButton QuickRestart { get; }
        ISourceVirtualButton MenuLeft { get; }
        ISourceVirtualButton MenuRight { get; }
        ISourceVirtualButton MenuUp { get; }
        ISourceVirtualButton MenuDown { get; }
        ISourceVirtualButton MenuConfirm { get; }
        ISourceVirtualButton MenuCancel { get; }
        ISourceVirtualButton MenuJournal { get; }
        ISourceVirtualIntegerAxis MoveX { get; }
        ISourceVirtualIntegerAxis MoveY { get; }
        ISourceVirtualIntegerAxis GliderMoveY { get; }
        ISourceVirtualJoystick Aim { get; }
        ISourceVirtualJoystick Feather { get; }
        ISourceVirtualJoystick MountainAim { get; }
        float DeltaTime { get; }
        int Gamepad { get; set; }
        Vector2 LastAim { get; set; }
        bool GrabCheck { get; }
        bool DashPressed { get; }
        bool CrouchDashPressed { get; }
        Vector2 GetAimVector(int defaultFacing = 1);
        void UpdateGrab();
        void ResetGrab();
    }
}
