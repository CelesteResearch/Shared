using System.Collections.Generic;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public sealed class ExtendedFontRegistryLifecyclePolicy : IOriginalFontRegistryPolicy
    {
        public SourcePixelFont Load(OriginalFontRegistry registry, string face)
        {
            SourcePixelFont font = registry.LoadOriginal(face);
            ((IOriginalFontRegistryAugmentationEnvironment)registry.engine).FontAugmentation.Fill(font);
            return font;
        }

        public void Reload(OriginalFontRegistry registry)
        {
            List<string> list = new List<string>();
            foreach (string key in registry.loadedFonts.Keys)
                list.Add(key);
            foreach (string item in list)
            {
                registry.loadedFonts[item].Dispose();
                registry.loadedFonts.Remove(item);
                registry.Load(item);
            }
        }
    }
}
