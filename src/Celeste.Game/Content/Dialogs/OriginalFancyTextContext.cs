using Celeste.Core.Randomness;
using Celeste.Formats.Graphics.Sprites;
using Celeste.Game.Save.Data;
using Celeste.Localization.Languages;

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
            DialogLanguage language = null)
        {
            return new(process, language);
        }

        public static OriginalFancyTextContext Create(IOriginalFancyTextProcess process,
            DialogLanguage language, string fontFaceOverride)
        {
            return new(process, language) { FontFaceOverride = fontFaceOverride };
        }

        public OriginalGameTextProcess Text => process.Text;
        public SpriteBank Portraits => process.Graphics.PortraitsSpriteBank;
        public ISourceRandom Random => process.Random;
        public OriginalSaveDataState SaveData => process.SaveContext.CurrentSave;

        public bool CanDisplay(DialogLanguage language, string text)
        {
            return Text.CanDisplay(language, text);
        }
    }
}
