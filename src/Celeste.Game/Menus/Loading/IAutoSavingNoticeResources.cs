using Celeste.Graphics.Animation;
using Celeste.Graphics.Text;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Menus.Loading
{
    public interface IAutoSavingNoticeResources : ISourceWigglerPoolScope
    {
        Sprite CreateSaveIcon();
        ActiveBitmapFont ActiveFont { get; }
        string CleanDialog(string key);
    }
}
