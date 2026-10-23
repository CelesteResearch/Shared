using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Content.Atlas
{
    public static class AtlasFrameLookup
    {
        public static global::Celeste.Graphics.Content.Atlas.AtlasEntry Frame(
            this global::Celeste.Graphics.Content.Atlas.AtlasData atlas, string key, int index)
        {
            if (index == 0 && atlas.Entries.TryGetValue(key, out var exact)) return exact;
            string suffix = index.ToString(System.Globalization.CultureInfo.InvariantCulture);
            for (int zeroes = 0; zeroes < 6; zeroes++, suffix = "0" + suffix)
                if (atlas.Entries.TryGetValue(key + suffix, out var entry))
                    return entry;
            return null;
        }

        public static List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Frames(
            this global::Celeste.Graphics.Content.Atlas.AtlasData atlas, string key)
        {
            var frames = new List<global::Celeste.Graphics.Content.Atlas.AtlasEntry>();
            for (int index = 0;; index++)
            {
                global::Celeste.Graphics.Content.Atlas.AtlasEntry entry = null;
                if (index == 0) atlas.Entries.TryGetValue(key, out entry);
                if (entry == null)
                {
                    string suffix = index.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    int length = suffix.Length;
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
