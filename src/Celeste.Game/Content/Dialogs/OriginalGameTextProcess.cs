using System;
using System.IO;
using Celeste.Game.Content.Fonts;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Localization.Languages;
using Celeste.Localization.Lookup;
using JetBrains.Annotations;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess : IActiveBitmapFontEnvironment
    {
        private readonly string contentDirectory;
        private readonly IOriginalFontRegistryProcess sourceProcess;
        private readonly DialogLookupPolicy lookupPolicy;
        private readonly IOriginalLanguageTextureFactory languageTextures;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private DialogCatalog dialog;

        public readonly OriginalFontRegistry Fonts;
        public readonly ActiveBitmapFont ActiveFont;
        public DialogCatalog Dialog => dialog;

        public OriginalGameTextProcess(IOriginalFontRegistryProcess engine,
            DialogLookupPolicy lookupPolicy, IOriginalLanguageTextureFactory languageTextures)
        {
            sourceProcess = engine;
            contentDirectory = engine.ContentDirectory;
            this.languageTextures = languageTextures ?? throw new ArgumentNullException(nameof(languageTextures));
            this.lookupPolicy = lookupPolicy ?? throw new ArgumentNullException(nameof(lookupPolicy));
            Fonts = new(engine);
            ActiveFont = new(this);
        }

        SourcePixelFont IActiveBitmapFontEnvironment.Font => Fonts.Get(dialog.Language.FontFace);
        float IActiveBitmapFontEnvironment.BaseSize => dialog.Language.FontFaceSize;

        public void PrepareFonts()
        {
            Fonts.Prepare();
        }

        public string LoadDialog(string requestedLanguage)
        {
            dialog = new(lookupPolicy);
            var loadingPolicy = sourceProcess is IOriginalDialogLoadingEnvironment environment
                ? environment.DialogLoadingPolicy
                : OriginalDialogLoadingPolicy.Shared;
            OriginalDialogLoader.LoadInto(dialog, Path.Combine(contentDirectory, "Dialog"), requestedLanguage,
                languageTextures, loadingPolicy);
            return dialog.Language.Id;
        }

        public void LoadLanguageFont(string language)
        {
            Fonts.Load(dialog.Languages[language].FontFace);
        }

        public bool CanDisplay(DialogLanguage language, string text)
        {
            var fontSize = Fonts.Get(language.FontFace).Get(language.FontFaceSize);
            for (var i = 0; i < text.Length; i++)
                if (text[i] != ' ' && fontSize.Get(text[i]) == null)
                    return false;

            return true;
        }

        public string CleanDialog(string name)
        {
            return dialog.Clean(name);
        }
    }
}
