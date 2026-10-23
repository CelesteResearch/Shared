using System;
using System.Globalization;

namespace Celeste.Everest.Menus.OptionEntry
{
    public sealed class EverestNumberEntryGrid : EverestOptionEntryGrid
    {
        public int MaxValueLength { get; private set; }
        public bool AllowDecimals { get; private set; }
        public bool AllowNegatives { get; private set; }
        public event Action<float> ValueChanged;

        protected override void OnValueChanged(string next)
        {
            ValueChanged?.Invoke(float.Parse(next, CultureInfo.CurrentCulture));
        }

        public void Initialize(float initial, int maxLength, bool allowDecimals, bool allowNegatives,
            float widestGlyph, float cancelWidth, float backspaceWidth, float acceptWidth)
        {
            MaxValueLength = maxLength;
            AllowDecimals = allowDecimals;
            AllowNegatives = allowNegatives;
            var formatted = initial.ToString("F" + maxLength, CultureInfo.CurrentCulture).TrimEnd('0').TrimEnd('.');
            Begin(formatted, "7 8 9\n4 5 6\n1 2 3\n- 0 .".Split('\n'), widestGlyph, widestGlyph,
                cancelWidth, 0f, backspaceWidth, acceptWidth);
            boxWidth = Math.Max(5f * widestGlyph, cancelWidth + backspaceWidth + acceptWidth + widestGlyph * 3f) +
                       boxPadding * 2f;
        }

        private int TrueMaxLength()
        {
            return MaxValueLength + (value.Contains("-") ? 1 : 0) + (value.Contains(".") ? 1 : 0);
        }

        private bool Valid(int row, int column)
        {
            return letters[row][column] != ' ' &&
                   (letters[row][column] != '-' || AllowNegatives) &&
                   (letters[row][column] != '.' || AllowDecimals);
        }

        public override void TextInput(char c, string clipboard, Func<char, bool> fontHasGlyph)
        {
            LastSound = EverestEntrySound.None;
            if (c == 13)
            {
                Finish();
            }
            else if (c == 8)
            {
                Backspace();
            }
            else if (c == 127)
            {
            }
            else if (c == '.')
            {
                if (AllowDecimals && value.Length < TrueMaxLength() && !value.Contains("."))
                {
                    LastSound = EverestEntrySound.Space;
                    Changed(value + c);
                }
                else
                {
                    LastSound = EverestEntrySound.Invalid;
                }
            }
            else if (c == '-')
            {
                if (AllowNegatives)
                {
                    Changed(value.StartsWith("-") ? value.Substring(1) : "-" + value);
                    LastSound = EverestEntrySound.Space;
                }
                else
                {
                    LastSound = EverestEntrySound.Invalid;
                }
            }
            else if (char.IsDigit(c))
            {
                if (value.Length < TrueMaxLength() && fontHasGlyph(c))
                {
                    LastSound = EverestEntrySound.Character;
                    Changed(value == "0" ? c.ToString() : value == "-0" ? "-" + c : value + c);
                }
                else
                {
                    LastSound = EverestEntrySound.Invalid;
                }
            }
            else if (!char.IsControl(c))
            {
                LastSound = EverestEntrySound.Invalid;
            }
        }

        public override void Step(EverestEntryInput input,
            bool useKeyboardInput)
        {
            LastSound = EverestEntrySound.None;
            if (!Focused) return;
            if (useKeyboardInput)
            {
                if (input.Escape) Cancel();
                return;
            }

            if (input.Right && (optionsIndex < 2 || !selectingOptions))
            {
                if (selectingOptions) optionsIndex = Math.Min(optionsIndex + 1, 2);
                else
                    do
                    {
                        index = (index + 1) % letters[line].Length;
                    } while (!Valid(line, index));

                Roll();
            }
            else if (input.Left && (optionsIndex > 0 || !selectingOptions))
            {
                if (selectingOptions) optionsIndex = Math.Max(optionsIndex - 1, 0);
                else
                    do
                    {
                        index = (index + letters[line].Length - 1) % letters[line].Length;
                    } while (!Valid(line, index));

                Roll();
            }
            else if (input.Down && !selectingOptions)
            {
                var next = line + 1;
                for (; next < letters.Length; next++)
                    if (index < letters[next].Length && Valid(next, index))
                        break;
                if (next == letters.Length)
                {
                    selectingOptions = true;
                    optionsIndex = 1;
                }
                else
                {
                    line = next;
                }

                Roll();
            }
            else if ((input.Up || (selectingOptions && value.Length <= 0 && optionsIndex > 0)) &&
                     (line > 0 || selectingOptions))
            {
                if (selectingOptions)
                {
                    line = letters.Length;
                    selectingOptions = false;
                    index = optionsIndex * 2;
                }

                do
                {
                    line--;
                } while (line > 0 && (index >= letters[line].Length || !Valid(line, index)));

                while (index >= letters[line].Length || !Valid(line, index)) index--;
                Roll();
            }
            else if (input.Confirm)
            {
                if (selectingOptions)
                {
                    if (optionsIndex == 0) Cancel();
                    else if (optionsIndex == 1) Backspace();
                    else Finish();
                }
                else
                {
                    TextInput(letters[line][index], null, FontHasGlyph);
                }
            }
            else if (input.Cancel)
            {
                if (value.Length > 0) Backspace();
                else Cancel();
            }
            else if (input.Pause)
            {
                Finish();
            }
        }

        private void Backspace()
        {
            if (value.Length > 1)
            {
                var next = value.Substring(0, value.Length - 1);
                Changed(next == "-" ? "0" : next);
                LastSound = EverestEntrySound.Backspace;
            }
            else if (value.Length == 1 && value != "0")
            {
                Changed("0");
                LastSound = EverestEntrySound.Backspace;
            }
            else
            {
                LastSound = EverestEntrySound.Invalid;
            }
        }

        private void Finish()
        {
            Exit(true);
            LastSound = EverestEntrySound.Accept;
        }

        private void Cancel()
        {
            Changed(startingValue);
            Exit(false);
            LastSound = EverestEntrySound.Back;
        }
    }
}
