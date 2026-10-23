using System.Collections.Generic;
using Celeste.Game.Settings;
using MouseButtons = Celeste.Everest.Input.SourceEverestMouseData.MouseButtons;
using Celeste.Everest.Input;

namespace Celeste.Everest.Settings
{
    public class VanillaMouseBindings
    {
        public List<MouseButtons> Left;
        public List<MouseButtons> Right;
        public List<MouseButtons> Down;
        public List<MouseButtons> Up;
        public List<MouseButtons> MenuLeft;
        public List<MouseButtons> MenuRight;
        public List<MouseButtons> MenuDown;
        public List<MouseButtons> MenuUp;
        public List<MouseButtons> Grab;
        public List<MouseButtons> Jump;
        public List<MouseButtons> Dash;
        public List<MouseButtons> Talk;
        public List<MouseButtons> Pause;
        public List<MouseButtons> Confirm;
        public List<MouseButtons> Cancel;
        public List<MouseButtons> Journal;
        public List<MouseButtons> QuickRestart;
        public List<MouseButtons> DemoDash;
        public List<MouseButtons> RightMoveOnly;
        public List<MouseButtons> LeftMoveOnly;
        public List<MouseButtons> UpMoveOnly;
        public List<MouseButtons> DownMoveOnly;
        public List<MouseButtons> RightDashOnly;
        public List<MouseButtons> LeftDashOnly;
        public List<MouseButtons> UpDashOnly;
        public List<MouseButtons> DownDashOnly;

        public VanillaMouseBindings Init(ISettingsContext settings)
        {
            Left = ((InstalledSourceInputBinding)settings.Settings.Left).Mouse;
            Right = ((InstalledSourceInputBinding)settings.Settings.Right).Mouse;
            Down = ((InstalledSourceInputBinding)settings.Settings.Down).Mouse;
            Up = ((InstalledSourceInputBinding)settings.Settings.Up).Mouse;
            MenuLeft = ((InstalledSourceInputBinding)settings.Settings.MenuLeft).Mouse;
            MenuRight = ((InstalledSourceInputBinding)settings.Settings.MenuRight).Mouse;
            MenuDown = ((InstalledSourceInputBinding)settings.Settings.MenuDown).Mouse;
            MenuUp = ((InstalledSourceInputBinding)settings.Settings.MenuUp).Mouse;
            Grab = ((InstalledSourceInputBinding)settings.Settings.Grab).Mouse;
            Jump = ((InstalledSourceInputBinding)settings.Settings.Jump).Mouse;
            Dash = ((InstalledSourceInputBinding)settings.Settings.Dash).Mouse;
            Talk = ((InstalledSourceInputBinding)settings.Settings.Talk).Mouse;
            Pause = ((InstalledSourceInputBinding)settings.Settings.Pause).Mouse;
            Confirm = ((InstalledSourceInputBinding)settings.Settings.Confirm).Mouse;
            Cancel = ((InstalledSourceInputBinding)settings.Settings.Cancel).Mouse;
            Journal = ((InstalledSourceInputBinding)settings.Settings.Journal).Mouse;
            QuickRestart = ((InstalledSourceInputBinding)settings.Settings.QuickRestart).Mouse;
            DemoDash = ((InstalledSourceInputBinding)settings.Settings.DemoDash).Mouse;
            RightMoveOnly = ((InstalledSourceInputBinding)settings.Settings.RightMoveOnly).Mouse;
            LeftMoveOnly = ((InstalledSourceInputBinding)settings.Settings.LeftMoveOnly).Mouse;
            UpMoveOnly = ((InstalledSourceInputBinding)settings.Settings.UpMoveOnly).Mouse;
            DownMoveOnly = ((InstalledSourceInputBinding)settings.Settings.DownMoveOnly).Mouse;
            RightDashOnly = ((InstalledSourceInputBinding)settings.Settings.RightDashOnly).Mouse;
            LeftDashOnly = ((InstalledSourceInputBinding)settings.Settings.LeftDashOnly).Mouse;
            UpDashOnly = ((InstalledSourceInputBinding)settings.Settings.UpDashOnly).Mouse;
            DownDashOnly = ((InstalledSourceInputBinding)settings.Settings.DownDashOnly).Mouse;
            return this;
        }

        public void Apply(ISettingsContext settings)
        {
            ((InstalledSourceInputBinding)settings.Settings.Left).Add(Left.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Right).Add(Right.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Down).Add(Down.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Up).Add(Up.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.MenuLeft).Add(MenuLeft.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.MenuRight).Add(MenuRight.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.MenuDown).Add(MenuDown.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.MenuUp).Add(MenuUp.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Grab).Add(Grab.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Jump).Add(Jump.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Dash).Add(Dash.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Talk).Add(Talk.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Pause).Add(Pause.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Confirm).Add(Confirm.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Cancel).Add(Cancel.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.Journal).Add(Journal.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.QuickRestart).Add(QuickRestart.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.DemoDash).Add(DemoDash.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.RightMoveOnly).Add(RightMoveOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.LeftMoveOnly).Add(LeftMoveOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.UpMoveOnly).Add(UpMoveOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.DownMoveOnly).Add(DownMoveOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.RightDashOnly).Add(RightDashOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.LeftDashOnly).Add(LeftDashOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.UpDashOnly).Add(UpDashOnly.ToArray());
            ((InstalledSourceInputBinding)settings.Settings.DownDashOnly).Add(DownDashOnly.ToArray());
        }
    }
}
