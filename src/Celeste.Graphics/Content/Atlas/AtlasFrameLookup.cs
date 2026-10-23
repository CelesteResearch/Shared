using System.Collections.Generic;
using System.Globalization;

namespace Celeste.Graphics.Content.Atlas
{
    public static class AtlasFrameLookup
    {
        // ReSharper disable once ConvertToExtensionBlock
        public static AtlasEntry Frame(
            this AtlasData atlas, string key, int index)
        {
            if (index == 0 && atlas.Entries.TryGetValue(key, out var exact)) return exact;
            var suffix = index.ToString(CultureInfo.InvariantCulture);
            for (var zeroes = 0; zeroes < 6; zeroes++, suffix = "0" + suffix)
                if (atlas.Entries.TryGetValue(key + suffix, out var entry))
                    return entry;
            return null;
        }

        public static List<AtlasEntry> Frames(
            this AtlasData atlas, string key)
        {
            var frames = new List<AtlasEntry>();
            for (var index = 0;; index++)
            {
                AtlasEntry entry = null;
                if (index == 0) atlas.Entries.TryGetValue(key, out entry);
                if (entry == null)
                {
                    var suffix = index.ToString(CultureInfo.InvariantCulture);
                    var length = suffix.Length;
                    while (suffix.Length < length + 6)
                    {
                        if (atlas.Entries.TryGetValue(key + suffix, out entry)) break;
                        suffix = "0" + suffix;
                    }
                }

                if (entry == null) return frames;
                frames.Add(entry);
            }
        }
    }
}
