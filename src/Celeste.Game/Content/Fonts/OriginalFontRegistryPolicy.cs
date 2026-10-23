using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public sealed class OriginalFontRegistryPolicy : IOriginalFontRegistryPolicy, IOriginalFontRegistryContentPolicy
    {
        private readonly IContentSource files;

        public OriginalFontRegistryPolicy(IContentSource files = null)
        {
            this.files = files;
        }

        public SourcePixelFont Load(OriginalFontRegistry registry, string face)
        {
            return registry.LoadOriginal(face);
        }

        public void Reload(OriginalFontRegistry registry)
        {
            var list = new List<string>();
            foreach (var key in registry.loadedFonts.Keys)
                list.Add(key);
            foreach (var item in list)
            {
                registry.loadedFonts[item].Dispose();
                registry.Load(item);
            }
        }

        public string[] GetFiles(IOriginalFontRegistryProcess process, string path, string pattern,
            SearchOption searchOption)
        {
            if (files == null) return Directory.GetFiles(path, pattern, searchOption);
            var expression = "^" + Regex.Escape(pattern)
                .Replace("\\*", ".*").Replace("\\?", ".") + "$";
            var selected = new List<string>();
            foreach (var file in files.GetFiles(path, searchOption))
                if (Regex.IsMatch(Path.GetFileName(file), expression))
                    selected.Add(file);
            return [.. selected];
        }

        public Stream OpenRead(IOriginalFontRegistryProcess process, string path)
        {
            return files == null ? File.OpenRead(path) : files.OpenTitleStream(path);
        }
    }
}
