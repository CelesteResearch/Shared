using Celeste.Everest.Input;
using Celeste.Game.Settings;

namespace Celeste.Everest.UI.Controls
{
    public static class InstalledSettingsMouseControls
    {
        public static void Clear(SettingsState settings)
        {
            ((InstalledSourceInputBinding)settings.Left).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Right).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Down).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Up).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.MenuLeft).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.MenuRight).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.MenuDown).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.MenuUp).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Grab).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Jump).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Dash).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Talk).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Pause).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Confirm).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Cancel).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.Journal).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.QuickRestart).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.DemoDash).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.LeftMoveOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.RightMoveOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.DownMoveOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.UpMoveOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.LeftDashOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.RightDashOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.DownDashOnly).Mouse.Clear();
            ((InstalledSourceInputBinding)settings.UpDashOnly).Mouse.Clear();
        }
    }
}
