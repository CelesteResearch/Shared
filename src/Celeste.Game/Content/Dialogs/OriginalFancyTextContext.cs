using Celeste.Core.Randomness;
using Celeste.Localization.Languages;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Dialogs
{
    public sealed class OriginalFancyTextContext
    {
        private readonly IOriginalFancyTextProcess process;
        public readonly DialogLanguage Language;
        public string FontFaceOverride { get; private set; }

        private OriginalFancyTextContext(IOriginalFancyTextProcess process, DialogLanguage language)
        {
            this.process = process;
            Language = language;
        }

        public static OriginalFancyTextContext Create(IOriginalFancyTextProcess process,
            DialogLanguage language = null) => new(process, language);

        public static OriginalFancyTextContext Create(IOriginalFancyTextProcess process,
            DialogLanguage language, string fontFaceOverride)
            => new(process, language) { FontFaceOverride = fontFaceOverride };

        public OriginalGameTextProcess Text => process.Text;
        public global::Celeste.Formats.Graphics.Sprites.SpriteBank Portraits => process.Graphics.PortraitsSpriteBank;
        public ISourceRandom Random => process.Random;
        public OriginalSaveDataState SaveData => process.SaveContext.CurrentSave;

        public bool CanDisplay(DialogLanguage language, string text) => Text.CanDisplay(language, text);
    }
}
