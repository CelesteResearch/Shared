using System.Collections.Generic;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public sealed class ExtendedFontRegistryLifecyclePolicy : IOriginalFontRegistryPolicy
    {
        public SourcePixelFont Load(OriginalFontRegistry registry, string face)
        {
            var font = registry.LoadOriginal(face);
            ((IOriginalFontRegistryAugmentationEnvironment)registry.engine).FontAugmentation.Fill(font);
            return font;
        }

        public void Reload(OriginalFontRegistry registry)
        {
            var list = new List<string>();
            foreach (var key in registry.loadedFonts.Keys)
                list.Add(key);
            foreach (var item in list)
            {
                registry.loadedFonts[item].Dispose();
                registry.loadedFonts.Remove(item);
                registry.Load(item);
            }
        }
    }
}
