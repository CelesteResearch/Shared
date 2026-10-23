using System;
using System.Globalization;

namespace Celeste.Everest.Menus.OptionEntry
{
    public sealed class EverestStringEntryGrid : global::Celeste.Everest.Menus.OptionEntry.EverestOptionEntryGrid
    {
        public static bool Cancelled;
        private bool exited;
        public int MaxValueLength { get; private set; }
        public int MinValueLength { get; private set; }
        public event Action<string> ValueChanged;
        protected override void OnValueChanged(string next) => ValueChanged?.Invoke(next);

        public void Initialize(string initial, string letterGrid, int maxLength, int minLength,
            float widestGlyph, float cancelWidth, float spaceWidth, float backspaceWidth, float acceptWidth)
        {
            MaxValueLength = maxLength;
            MinValueLength = minLength;
            Begin(initial ?? "", letterGrid.Split('\n'), widestGlyph, widestGlyph,
                cancelWidth, spaceWidth, backspaceWidth, acceptWidth);
            Cancelled = false;
            exited = false;
        }

        public override void TextInput(char c, string clipboard, Func<char, bool> fontHasGlyph)
        {
            LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.None;
            if (c == 13) Finish();
            else if (c == 8) Backspace();
            else if (c == 22)
            {
                string next = value + clipboard;
                if (next.Length > MaxValueLength) next = next.Substring(0, MaxValueLength);
                Changed(next); // Original fires even if unchanged.
            }
            else if (c == 127)
            {
            }
            else if (c == ' ')
            {
                if (value.Length < MaxValueLength)
                {
                    LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Space;
                    Changed(value + c);
                }
                else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
            }
            else if (!char.IsControl(c))
            {
                if (value.Length < MaxValueLength && fontHasGlyph(c))
                {
                    LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Character;
                    Changed(value + c);
                }
                else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
            }
        }

        public override void Step(global::Celeste.Everest.Menus.OptionEntry.EverestEntryInput input,
            bool useKeyboardInput)
        {
            LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.None;
            if (!Focused) return;
            if (useKeyboardInput)
            {
                if (input.Escape) Cancel();
                return;
            }

            if (input.Right && (optionsIndex < 3 || !selectingOptions) && (value.Length > 0 || !selectingOptions))
            {
                if (selectingOptions) optionsIndex = Math.Min(optionsIndex + 1, 3);
                else
                    do
                    {
                        index = (index + 1) % letters[line].Length;
                    } while (letters[line][index] == ' ');

                Roll();
            }
            else if (input.Left && (optionsIndex > 0 || !selectingOptions))
            {
                if (selectingOptions) optionsIndex = Math.Max(optionsIndex - 1, 0);
                else
                    do
                    {
                        index = (index + letters[line].Length - 1) % letters[line].Length;
                    } while (letters[line][index] == ' ');

                Roll();
            }
            else if (input.Down && !selectingOptions)
            {
                int next = line + 1;
                for (; next < letters.Length; next++)
                    if (index < letters[next].Length && letters[next][index] != ' ')
                        break;
                if (next == letters.Length)
                {
                    selectingOptions = true;
                    float pos = index * widestLetter;
                    float offs = boxWidth - boxPadding * 2f;
                    if (value.Length == 0 || pos < cancelWidth +
                        (offs - cancelWidth - acceptWidth - backspaceWidth - spaceWidth - widestLetter * 3f) / 2f)
                        optionsIndex = 0;
                    else if (pos < offs - acceptWidth - backspaceWidth - widestLetter * 2f) optionsIndex = 1;
                    else if (pos < offs - acceptWidth - widestLetter) optionsIndex = 2;
                    else optionsIndex = 3;
                }
                else line = next;

                Roll();
            }
            else if ((input.Up || (selectingOptions && value.Length <= 0 && optionsIndex > 0)) &&
                     (line > 0 || selectingOptions))
            {
                if (selectingOptions)
                {
                    line = letters.Length;
                    selectingOptions = false;
                    float offs = boxWidth - boxPadding * 2f;
                    if (optionsIndex == 0) index = (int)(cancelWidth / 2f / widestLetter);
                    else if (optionsIndex == 1)
                        index = (int)((offs - acceptWidth - backspaceWidth - spaceWidth / 2f - widestLetter * 2f) /
                                      widestLetter);
                    else if (optionsIndex == 2)
                        index = (int)((offs - acceptWidth - backspaceWidth / 2f - widestLetter) / widestLetter);
                    else index = (int)((offs - acceptWidth / 2f) / widestLetter);
                }

                do
                {
                    line--;
                } while (line > 0 && (index >= letters[line].Length || letters[line][index] == ' '));

                while (index >= letters[line].Length || letters[line][index] == ' ') index--;
                Roll();
            }
            else if (input.Confirm)
            {
                if (selectingOptions)
                {
                    if (optionsIndex == 0) Cancel();
                    else if (optionsIndex == 1 && value.Length > 0) Space();
                    else if (optionsIndex == 2) Backspace();
                    else if (optionsIndex == 3) Finish();
                }
                else if (value.Length < MaxValueLength)
                {
                    Changed(value + letters[line][index]);
                    LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Character;
                }
                else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
            }
            else if (input.Cancel)
            {
                if (value.Length > 0) Backspace();
                else Cancel();
            }
            else if (input.Pause) Finish();
        }

        private void Space()
        {
            if (value.Length < MaxValueLength)
            {
                Changed(value + " ");
                LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Character;
            }
            else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
        }

        private void Backspace()
        {
            if (value.Length > 0)
            {
                Changed(value.Substring(0, value.Length - 1));
                LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Backspace;
            }
            else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
        }

        private void Finish()
        {
            if (value.Length >= MinValueLength)
            {
                if (!exited)
                {
                    exited = true;
                    Exit(true);
                }

                LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Accept;
            }
            else LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Invalid;
        }

        private void Cancel()
        {
            Cancelled = true;
            Changed(startingValue);
            if (!exited)
            {
                exited = true;
                Exit(false);
            }

            LastSound = global::Celeste.Everest.Menus.OptionEntry.EverestEntrySound.Back;
        }
    }
}
