using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        public override IEnumerator Enter(OuiState from)
        {
            if (UseKeyboardInput)
            {
                TextInput.OnInput += OnTextInput;
            }

            Overworld.ShowInputUI = false;
            Commands.Enabled = false;
            selectingOptions = false;
            optionsIndex = 0;
            index = 0;
            line = 0;
            string text = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_letters");
            letters = text.Split('\n');
            string text2 = text;
            for (int i = 0; i < text2.Length; i++)
            {
                float x = ActiveFont.Measure(text2[i]).X;
                if (x > widestLetter)
                {
                    widestLetter = x;
                }
            }

            widestLineCount = 0;
            string[] array = letters;
            foreach (string text3 in array)
            {
                if (text3.Length > widestLineCount)
                {
                    widestLineCount = text3.Length;
                }
            }

            widestLine = (float)widestLineCount * widestLetter;
            lineHeight = ActiveFont.LineHeight;
            lineSpacing = ActiveFont.LineHeight * 0.1f;
            boxPadding = widestLetter;
            optionsScale = 0.75f;
            cancel = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_back");
            space = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_space");
            backspace = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_backspace");
            accept = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_accept");
            cancelWidth = ActiveFont.Measure(cancel).X * optionsScale;
            spaceWidth = ActiveFont.Measure(space).X * optionsScale;
            backspaceWidth = ActiveFont.Measure(backspace).X * optionsScale;
            beginWidth = ActiveFont.Measure(accept).X * optionsScale;
            optionsWidth = cancelWidth + spaceWidth + backspaceWidth + beginWidth + widestLetter * 3f;
            boxWidth = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(widestLine, optionsWidth) +
                       boxPadding * 2f;
            boxHeight = ((float)letters.Length + 1f) * lineHeight + (float)letters.Length * lineSpacing +
                        boxPadding * 3f;
            Visible = true;
            Vector2 posFrom = Position;
            Vector2 posTo = Vector2.Zero;
            for (float t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = posFrom +
                           (posTo - posFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            ease = 1f;
            _ = Vector2.Zero;
            _ = Vector2.Zero;
            yield return 0.2f;
            Focused = true;
            yield return 0.2f;
            wiggler.Start();
        }

        public override IEnumerator Leave(OuiState next)
        {
            TextInput.OnInput -= OnTextInput;
            Overworld.ShowInputUI = true;
            Focused = false;
            Commands.Enabled = ((IOriginalGamePlayModeEnvironment)engine).PlayMode ==
                               GameRuntime.PlayModes.Debug;
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
