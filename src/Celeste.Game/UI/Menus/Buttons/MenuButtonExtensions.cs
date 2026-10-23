namespace Celeste.Game.UI.Menus.Buttons
{
    public static class MenuButtonExtensions
    {
        public static void SetSelected(this MenuButtonPresentation self, bool value)
        {
            self.SetSourceSelected(value);
        }
    }
}
