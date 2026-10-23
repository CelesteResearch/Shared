using System;
using System.Collections.Generic;

namespace Celeste.Localization.Languages
{
    // The source language owns its actual icon; text and named-font metadata remain reusable.
    public sealed class DialogLanguage : IDisposable
    {
        public string SourceName, Id, Label, IconPath, FontFace;
        public string FilePath;
        public int Order;
        public float FontFaceSize;
        public string SplitRegex;
        public string CommaCharacters, PeriodCharacters;
        public int Lines, Words;
        public Dictionary<string, string> LineSources;
        public Dictionary<string, int> ReadCount;
        public string CurrentlyReadingFrom;

        public readonly Dictionary<string, string> Dialog =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public readonly Dictionary<string, string> Cleaned =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string IconAssetPath;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Icon;

        public void Dispose()
        {
            if (Icon.Texture != null && !Icon.Texture.IsDisposed)
                Icon.Texture.Dispose();
        }

        public string this[string name] => Dialog[name];

        // Native Language iterates UTF-16 code units and exempts only the space.
        public bool CanDisplay(string text, Func<int, bool> hasGlyph)
        {
            for (int i = 0; i < text.Length; i++)
                if (text[i] != ' ' && !hasGlyph(text[i]))
                    return false;
            return true;
        }
    }
}
