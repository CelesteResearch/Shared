using Celeste.Input.Bindings;

namespace Celeste.Game.Controls.Source
{
    public interface IOriginalGameInputSourceSettings
    {
        GrabModes GrabMode { get; }
        CrouchDashModes CrouchDashMode { get; }
        RumbleAmount Rumble { get; }
        SourceInputBinding Cancel { get; }
        SourceInputBinding Confirm { get; }
        SourceInputBinding Dash { get; }
        SourceInputBinding DemoDash { get; }
        SourceInputBinding Down { get; }
        SourceInputBinding DownDashOnly { get; }
        SourceInputBinding DownMoveOnly { get; }
        SourceInputBinding Grab { get; }
        SourceInputBinding Journal { get; }
        SourceInputBinding Jump { get; }
        SourceInputBinding Left { get; }
        SourceInputBinding LeftDashOnly { get; }
        SourceInputBinding LeftMoveOnly { get; }
        SourceInputBinding MenuDown { get; }
        SourceInputBinding MenuLeft { get; }
        SourceInputBinding MenuRight { get; }
        SourceInputBinding MenuUp { get; }
        SourceInputBinding Pause { get; }
        SourceInputBinding QuickRestart { get; }
        SourceInputBinding Right { get; }
        SourceInputBinding RightDashOnly { get; }
        SourceInputBinding RightMoveOnly { get; }
        SourceInputBinding Talk { get; }
        SourceInputBinding Up { get; }
        SourceInputBinding UpDashOnly { get; }
        SourceInputBinding UpMoveOnly { get; }
    }
}
