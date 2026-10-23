using System.Collections.Generic;

namespace Celeste.Graphics.Content.Atlas
{
    public static class AtlasLookup
    {
        /// <summary>
        ///     Port of <c>Monocle.Atlas.GetAtlasSubtextures</c>: index 0 accepts the bare key, every other
        ///     index walks the zero padding from the shortest form up to six digits, and the enumeration
        ///     stops at the first index that resolves to nothing. The Summit cloud prefix therefore yields
        ///     cloud00 and cloud01 and never reaches the cloud03 art, exactly like the original.
        /// </summary>
        public static List<AtlasEntry> Subtextures(
            AtlasData atlas, string key)
        {
            var result = new List<AtlasEntry>();
            if (atlas == null || string.IsNullOrEmpty(key)) return result;
            for (var index = 0; index < 100; index++)
            {
                if (index == 0 && atlas.Entries.TryGetValue(key, out var bare))
                {
                    result.Add(bare);
                    continue;
                }

                var text = index.ToString();
                var length = text.Length;
                AtlasEntry found = null;
                while (text.Length < length + 6)
                {
                    if (atlas.Entries.TryGetValue(key + text, out var entry))
                    {
                        found = entry;
                        break;
                    }

                    text = "0" + text;
                }

                if (found == null) break;
                result.Add(found);
            }

            return result;
        }
    }
}
