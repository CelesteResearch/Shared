namespace Celeste.Simulation.UI.Menus.Text
{
    public struct TextMenuInput
    {
        public bool MenuDown,
            MenuUp,
            MenuLeft,
            MenuRight,
            MenuConfirm,
            MenuCancel,
            MenuJournal,
            ESC,
            Pause;

        public bool DownRepeating, UpRepeating, LeftRepeating, RightRepeating;
    }
}
