using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Everest.UI.Settings
{
    public interface IEverestMenuItemExt
    {
        PackedColor TextColor { get; set; }
        string Icon { get; set; }
        float? IconWidth { get; set; }
        bool IconOutline { get; set; }
        Vector2 Offset { get; set; }
        float Alpha { get; set; }
    }
}
