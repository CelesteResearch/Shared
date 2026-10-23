using Celeste.Graphics.Animation;
using Celeste.Graphics.Text;

namespace Celeste.Game.Menus.Loading
{
    public interface IAutoSavingNoticeResources : Celeste.Scene.Components.Oscillation.ISourceWigglerPoolScope
    {
        Sprite CreateSaveIcon();
        ActiveBitmapFont ActiveFont { get; }
        string CleanDialog(string key);
    }
}
