using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        public override IEnumerator Enter(OuiState from)
        {
            if (Name == ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("FILE_DEFAULT") ||
                (Settings != null && Name == Settings.DefaultFileName))
            {
                Name = "";
            }

            base.Overworld.ShowInputUI = false;
            selectingOptions = false;
            optionsIndex = 0;
            index = 0;
            line = 0;
            ReloadLetters(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_letters"));
            optionsScale = 0.75f;
            cancel = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_back");
            space = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_space");
            backspace = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_backspace");
            accept = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_accept");
            cancelWidth = ActiveFont.Measure(cancel).X * optionsScale;
            spaceWidth = ActiveFont.Measure(space).X * optionsScale;
            backspaceWidth = ActiveFont.Measure(backspace).X * optionsScale;
            beginWidth = ActiveFont.Measure(accept).X * optionsScale * 1.25f;
            optionsWidth = cancelWidth + spaceWidth + backspaceWidth + beginWidth + widestLetter * 3f;
            Visible = true;
            Vector2 posFrom = Position;
            Vector2 posTo = Vector2.Zero;
            for (float t = 0f; t < 1f; t += engine.Frame.DeltaTime * 3f)
            {
                ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
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
            for (int i = 0; i < chars.Length; i++)
            {
                float x = ActiveFont.Measure(chars[i]).X;
                if (x > widestLetter)
                {
                    widestLetter = x;
                }
            }

            if (Japanese)
            {
                widestLetter *= 1.5f;
            }

            widestLineCount = 0;
            string[] array = letters;
            foreach (string text in array)
            {
                if (text.Length > widestLineCount)
                {
                    widestLineCount = text.Length;
                }
            }

            widestLine = (float)widestLineCount * widestLetter;
            lineHeight = ActiveFont.LineHeight;
            lineSpacing = ActiveFont.LineHeight * 0.1f;
            boxPadding = widestLetter;
            boxWidth = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(widestLine, optionsWidth) +
                       boxPadding * 2f;
            boxHeight = (float)(letters.Length + 1) * lineHeight + (float)letters.Length * lineSpacing +
                        boxPadding * 3f;
        }

        public override IEnumerator Leave(OuiState next)
        {
            base.Overworld.ShowInputUI = true;
            Focused = false;
            Vector2 posFrom = Position;
            Vector2 posTo = new Vector2(0f, 1080f);
            for (float t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            Visible = false;
        }
    }
}
