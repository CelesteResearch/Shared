using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        public override IEnumerator Enter(OuiState from)
        {
            if (Name == ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("FILE_DEFAULT") ||
                (Settings != null && Name == Settings.DefaultFileName))
                Name = "";

            Overworld.ShowInputUI = false;
            selectingOptions = false;
            optionsIndex = 0;
            index = 0;
            line = 0;
            ReloadLetters(((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_letters"));
            optionsScale = 0.75f;
            cancel = ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_back");
            space = ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_space");
            backspace = ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_backspace");
            accept = ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_accept");
            cancelWidth = ActiveFont.Measure(cancel).X * optionsScale;
            spaceWidth = ActiveFont.Measure(space).X * optionsScale;
            backspaceWidth = ActiveFont.Measure(backspace).X * optionsScale;
            beginWidth = ActiveFont.Measure(accept).X * optionsScale * 1.25f;
            optionsWidth = cancelWidth + spaceWidth + backspaceWidth + beginWidth + widestLetter * 3f;
            Visible = true;
            var posFrom = Position;
            var posTo = Vector2.Zero;
            for (var t = 0f; t < 1f; t += SourceEngine.Frame.DeltaTime * 3f)
            {
                ease = ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            ease = 1f;
            yield return 0.05f;
            Focused = true;
            yield return 0.05f;
            wiggler.Start();
        }

        private void ReloadLetters(string chars)
        {
            letters = chars.Split('\n');
            widestLetter = 0f;
            for (var i = 0; i < chars.Length; i++)
            {
                var x = ActiveFont.Measure(chars[i]).X;
                if (x > widestLetter) widestLetter = x;
            }

            if (Japanese) widestLetter *= 1.5f;

            widestLineCount = 0;
            var array = letters;
            foreach (var text in array)
                if (text.Length > widestLineCount)
                    widestLineCount = text.Length;

            widestLine = widestLineCount * widestLetter;
            lineHeight = ActiveFont.LineHeight;
            lineSpacing = ActiveFont.LineHeight * 0.1f;
            boxPadding = widestLetter;
            boxWidth = ((ISourceExtremaEnvironment)SourceEngine).ExtremaArithmetic.Max(widestLine, optionsWidth) +
                       boxPadding * 2f;
            boxHeight = (letters.Length + 1) * lineHeight + letters.Length * lineSpacing +
                        boxPadding * 3f;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Overworld.ShowInputUI = true;
            Focused = false;
            var posFrom = Position;
            var posTo = new Vector2(0f, 1080f);
            for (var t = 0f; t < 1f; t += SourceEngine.Frame.DeltaTime * 2f)
            {
                ease = 1f - ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            Visible = false;
        }
    }
}
