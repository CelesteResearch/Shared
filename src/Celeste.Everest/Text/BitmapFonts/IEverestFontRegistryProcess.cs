using Celeste.Everest.Content.Registry;
using Celeste.Game.Content.Fonts;

namespace Celeste.Everest.Text.BitmapFonts
{
    public interface IEverestFontRegistryProcess : IOriginalFontRegistryProcess,
        IOriginalFontRegistryAugmentationEnvironment
    {
        EverestContentRegistry SourceContentRegistry { get; }
        SourceEverestFileProxyProcess FileProxy { get; }
    }
}
