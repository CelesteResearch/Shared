using System.Collections.Generic;
using System.IO;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public sealed class OriginalFontRegistryPolicy : IOriginalFontRegistryPolicy, IOriginalFontRegistryContentPolicy
    {
        private readonly global::Celeste.Core.IO.Content.IContentSource files;

        public OriginalFontRegistryPolicy(global::Celeste.Core.IO.Content.IContentSource files = null)
            => this.files = files;

        public SourcePixelFont Load(OriginalFontRegistry registry, string face) => registry.LoadOriginal(face);

        public void Reload(OriginalFontRegistry registry)
        {
            List<string> list = new List<string>();
            foreach (string key in registry.loadedFonts.Keys)
                list.Add(key);
            foreach (string item in list)
            {
                registry.loadedFonts[item].Dispose();
                registry.Load(item);
            }
        }

        public string[] GetFiles(IOriginalFontRegistryProcess process, string path, string pattern,
            SearchOption searchOption)
        {
            if (files == null) return Directory.GetFiles(path, pattern, searchOption);
            string expression = "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
                .Replace("\\*", ".*").Replace("\\?", ".") + "$";
            var selected = new List<string>();
            foreach (string file in files.GetFiles(path, searchOption))
                if (System.Text.RegularExpressions.Regex.IsMatch(Path.GetFileName(file), expression))
                    selected.Add(file);
            return selected.ToArray();
        }

        public Stream OpenRead(IOriginalFontRegistryProcess process, string path) =>
            files == null ? File.OpenRead(path) : files.OpenTitleStream(path);
    }
}
