using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Game.Content.Fonts;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Everest.Content.Types.Dialogs;

namespace Celeste.Everest.Text.BitmapFonts
{
    public sealed class EverestFontRegistryPolicy : IOriginalFontRegistryContentPolicy
    {
        public string[] GetFiles(IOriginalFontRegistryProcess process, string path, string pattern,
            SearchOption searchOption)
        {
            string[] files = Directory.GetFiles(path, pattern, searchOption);
            var installed = (IEverestFontRegistryProcess)process;
            lock (installed.SourceContentRegistry.Map)
            {
                return (from asset in installed.SourceContentRegistry.Map.Values
                    where asset.Type == typeof(AssetTypeFont)
                    select Path.Combine(process.ContentDirectory, asset.PathVirtual + "." + asset.Format)
                        .Replace('/', Path.DirectorySeparatorChar)).Union(files).ToArray();
            }
        }

        public Stream OpenRead(IOriginalFontRegistryProcess process, string path)
            => ((IEverestFontRegistryProcess)process).FileProxy.OpenRead(path);
    }
}
