namespace Celeste.Everest.UI.Controls
{
    public static class InstalledSettingsMouseControls
    {
        public static void Clear(global::Celeste.Game.Settings.SettingsState settings)
        {
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Left).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Right).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Down).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Up).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.MenuLeft).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.MenuRight).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.MenuDown).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.MenuUp).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Grab).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Jump).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Dash).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Talk).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Pause).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Confirm).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Cancel).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.Journal).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.QuickRestart).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.DemoDash).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.LeftMoveOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.RightMoveOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.DownMoveOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.UpMoveOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.LeftDashOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.RightDashOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.DownDashOnly).Mouse.Clear();
            ((global::Celeste.Everest.Input.InstalledSourceInputBinding)settings.UpDashOnly).Mouse.Clear();
        }
    }
}
