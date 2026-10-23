using Celeste.Game.Content.Fonts;
using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Text.BitmapFonts
{
    public interface IEverestFontRegistryProcess : IOriginalFontRegistryProcess,
        IOriginalFontRegistryAugmentationEnvironment
    {
        EverestContentRegistry SourceContentRegistry { get; }
        SourceEverestFileProxyProcess FileProxy { get; }
    }
}
