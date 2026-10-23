using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Everest.UI.ModOptions;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Everest.UI.Settings
{
    /// <summary>
    ///     Modification of <see cref="T:Celeste.Mod.UI.OuiModOptionString" /> to handle numeric input.
    /// </summary>
    public class EverestNumberEntryState : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private EverestTextInputProcess TextInput => ((IEverestTextInputEnvironment)engine).TextInput;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        public string StartingValue;

        private string _Value;

        public int MaxValueLength;

        private Action exit;

        private bool allowDecimals;

        private bool allowNegatives;

        private string[] letters;

        private float widestLetter;

        private float widestLine;

        private int widestLineCount;

        private float lineHeight;

        private float lineSpacing;

        private float boxPadding;

        private float optionsScale;

        private float optionsWidth;

        private float keyboardWidth;

        private float boxWidth;

        private float boxHeight;

        private string cancel;

        private float cancelWidth;

        private string backspace;

        private float backspaceWidth;

        private string accept;

        private float acceptWidth;

        private int index;

        private int line;

        private int optionsIndex;

        private bool selectingOptions = true;

        private float pressedTimer;

        private float timer;

        private float ease;

        private readonly WigglerComponent wiggler;

        private readonly PackedColor unselectColor = PackedColor.LightGray;

        private readonly PackedColor selectColorA = SourceHexColor.HexToColor("84FF54");

        private readonly PackedColor selectColorB = SourceHexColor.HexToColor("FCFF59");

        private readonly PackedColor disableColor = PackedColor.DarkSlateBlue;

        public string Value
        {
            get => _Value;
            set
            {
                _Value = value;
                OnValueChange?.Invoke(float.Parse(value));
            }
        }

        private Vector2 boxTopLeft =>
            SourceVector2Math.Add(Position, new((1920f - boxWidth) / 2f, 360f + (680f - boxHeight) / 2f));

        private Vector2 keyboardTopLeft => SourceVector2Math.Add(Position,
            new((1920f - keyboardWidth) / 2f, 360f + (680f - boxHeight) / 2f));

        public bool UseKeyboardInput =>
            ((IEverestModOptionStringEnvironment)engine).CurrentCoreSettings?.UseKeyboardForTextInput ?? false;

        public event Action<float> OnValueChange;

        public EverestNumberEntryState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            Position = new(0f, 1080f);
            Visible = false;
        }

        /// <summary>
        ///     Sets up the EverestNumberEntryState screen.
        /// </summary>
        /// <typeparam name="T">Oui to return to on exit</typeparam>
        /// <param name="value">Initial value</param>
        /// <param name="onValueChange">Action to be called when a new value is set.</param>
        /// <param name="maxValueLength">The number of digits allowed, excluding "-" and "."</param>
        /// <param name="allowDecimals">If decimal numbers should be allowed</param>
        /// <param name="allowNegatives">If negative numbers should be allowed</param>
        /// <returns />
        public EverestNumberEntryState Init<T>(float value, Action<float> onValueChange, int maxValueLength = 6,
            bool allowDecimals = true, bool allowNegatives = true) where T : OuiState
        {
            _Value = StartingValue = value.ToString($"F{maxValueLength}").TrimEnd('0').TrimEnd('.');
            OnValueChange = onValueChange;
            MaxValueLength = maxValueLength;
            exit = delegate { Overworld.Goto<T>(); };
            this.allowDecimals = allowDecimals;
            this.allowNegatives = allowNegatives;
            return this;
        }

        public override IEnumerator Enter(OuiState from)
        {
            if (UseKeyboardInput) TextInput.OnInput += OnTextInput;

            Overworld.ShowInputUI = false;
            selectingOptions = false;
            optionsIndex = 0;
            index = 0;
            line = 0;
            var text = "7 8 9\n4 5 6\n1 2 3\n- 0 .";
            letters = text.Split('\n');
            var text2 = text;
            for (var i = 0; i < text2.Length; i++)
            {
                var x = ActiveFont.Measure(text2[i]).X;
                if (x > widestLetter) widestLetter = x;
            }

            widestLineCount = 0;
            var array = letters;
            foreach (var text3 in array)
                if (text3.Length > widestLineCount)
                    widestLineCount = text3.Length;

            widestLine = widestLineCount * widestLetter;
            boxPadding = widestLetter;
            keyboardWidth = widestLine + boxPadding * 2f;
            lineHeight = ActiveFont.LineHeight;
            lineSpacing = ActiveFont.LineHeight * 0.1f;
            optionsScale = 0.75f;
            cancel = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_back");
            backspace = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_backspace");
            accept = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_accept");
            cancelWidth = ActiveFont.Measure(cancel).X * optionsScale;
            backspaceWidth = ActiveFont.Measure(backspace).X * optionsScale;
            acceptWidth = ActiveFont.Measure(accept).X * optionsScale;
            optionsWidth = cancelWidth + backspaceWidth + acceptWidth + widestLetter * 3f;
            boxWidth = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(widestLine, optionsWidth) +
                       boxPadding * 2f;
            boxHeight = (letters.Length + 1f) * lineHeight + letters.Length * lineSpacing +
                        boxPadding * 3f;
            Visible = true;
            var posFrom = Position;
            var posTo = Vector2.Zero;
            for (var t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = SourceVector2Math.Add(posFrom,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(posTo, posFrom),
                        ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t)));
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
            var posFrom = Position;
            var posTo = new Vector2(0f, 1080f);
            for (var t = 0f; t < 1f; t += engine.Frame.DeltaTime * 2f)
            {
                ease = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(t);
                Position = SourceVector2Math.Add(posFrom,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(posTo, posFrom),
                        ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t)));
                yield return null;
            }

            Visible = false;
        }

        public void OnTextInput(char c)
        {
            switch (c)
            {
                case '\r':
                    Finish();
                    return;
                case '\b':
                    Backspace();
                    return;
                case '.':
                    if (allowDecimals && Value.Length < TrueMaxLength() && !Value.Contains("."))
                    {
                        Process.AudioSession.Play("event:/ui/main/rename_entry_space");
                        Value += c;
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }

                    return;
                case '-':
                    if (allowNegatives)
                    {
                        if (!Value.StartsWith("-"))
                            Value = "-" + Value;
                        else
                            Value = Value.Substring(1);

                        Process.AudioSession.Play("event:/ui/main/rename_entry_space");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }

                    return;
                case '\u007f':
                    return;
            }

            if (char.IsDigit(c))
            {
                if (Value.Length < TrueMaxLength() &&
                    ActiveFont.Font.Get(ActiveFont.BaseSize).Characters.ContainsKey(c))
                {
                    Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    if (Value.Equals("0"))
                        Value = c.ToString();
                    else if (Value.Equals("-0"))
                        Value = "-" + c;
                    else
                        Value += c;
                }
                else
                {
                    Process.AudioSession.Play("event:/ui/main/button_invalid");
                }
            }
            else if (!char.IsControl(c))
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private int TrueMaxLength()
        {
            var num = MaxValueLength;
            if (Value.Contains("-")) num++;

            if (Value.Contains(".")) num++;

            return num;
        }

        public override void Update()
        {
            var flag = Focused;
            Focused = flag && !UseKeyboardInput;
            base.Update();
            if (Selected && Focused)
            {
                if (Input.MenuRight.Pressed && (optionsIndex < 2 || !selectingOptions))
                {
                    if (selectingOptions)
                        optionsIndex = Math.Min(optionsIndex + 1, 2);
                    else
                        do
                        {
                            index = (index + 1) % letters[line].Length;
                        } while (!isOptionValid(line, index));

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuLeft.Pressed && (optionsIndex > 0 || !selectingOptions))
                {
                    if (selectingOptions)
                        optionsIndex = Math.Max(optionsIndex - 1, 0);
                    else
                        do
                        {
                            index = (index + letters[line].Length - 1) % letters[line].Length;
                        } while (!isOptionValid(line, index));

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuDown.Pressed && !selectingOptions)
                {
                    var i = line + 1;
                    var flag2 = true;
                    for (; i < letters.Length; i++)
                        if (index < letters[i].Length && isOptionValid(i, index))
                        {
                            flag2 = false;
                            break;
                        }

                    if (flag2)
                    {
                        selectingOptions = true;
                        optionsIndex = 1;
                    }
                    else
                    {
                        line = i;
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if ((Input.MenuUp.Pressed || (selectingOptions && Value.Length <= 0 && optionsIndex > 0)) &&
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
                    } while (line > 0 && (index >= letters[line].Length || !isOptionValid(line, index)));

                    while (index >= letters[line].Length || !isOptionValid(line, index)) index--;

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    if (selectingOptions)
                    {
                        if (optionsIndex == 0)
                            Cancel();
                        else if (optionsIndex == 1)
                            Backspace();
                        else if (optionsIndex == 2) Finish();
                    }
                    else
                    {
                        OnTextInput(letters[line][index]);
                    }
                }
                else if (Input.MenuCancel.Pressed)
                {
                    if (Value.Length > 0)
                        Backspace();
                    else
                        Cancel();
                }
                else if (Input.Pause.Pressed)
                {
                    Finish();
                }
            }

            if (flag && !Focused && (bool)Input.ESC)
            {
                Cancel();
                flag = false;
            }

            Focused = flag;
            pressedTimer -= engine.Frame.DeltaTime;
            timer += engine.Frame.DeltaTime;
            wiggler.Update();
        }

        private bool isOptionValid(int line, int index)
        {
            if (letters[line][index] != ' ' && (letters[line][index] != '-' || allowNegatives))
                return letters[line][index] == '.' ? allowDecimals : true;

            return false;
        }

        private void Backspace()
        {
            if (Value.Length > 1)
            {
                var text = Value.Substring(0, Value.Length - 1);
                if (text.Equals("-"))
                    Value = "0";
                else
                    Value = text;

                Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
            }
            else if (Value.Length == 1 && !Value.Equals("0"))
            {
                Value = "0";
                Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private void Finish()
        {
            Focused = false;
            exit?.Invoke();
            Process.AudioSession.Play("event:/ui/main/rename_entry_accept");
        }

        private void Cancel()
        {
            Value = StartingValue;
            Focused = false;
            exit?.Invoke();
            Process.AudioSession.Play("event:/ui/main/button_back");
        }

        public override void Render(ISourceRenderContext context)
        {
            var num = index;
            if (UseKeyboardInput) index = -1;

            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * 0.8f * ease);
            var vector = SourceVector2Math.Add(keyboardTopLeft, new(boxPadding, boxPadding));
            var num2 = 0;
            var array = letters;
            foreach (var text in array)
            {
                for (var j = 0; j < text.Length; j++)
                {
                    var flag = num2 == line && j == index && !selectingOptions;
                    var scale = SourceVector2Math.Multiply(Vector2.One, flag ? 1.7f : 1.4f);
                    var at = SourceVector2Math.Add(vector,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                            new Vector2(widestLetter, lineHeight),
                            2f));
                    if (flag) at = SourceVector2Math.Add(at, SourceVector2Math.Multiply(new(0f, wiggler.Value), 8f));

                    DrawOptionText(context, text[j].ToString(), at, new(0.5f, 0.5f), scale, flag);
                    vector.X += widestLetter;
                }

                vector.X = keyboardTopLeft.X + boxPadding;
                vector.Y += lineHeight + lineSpacing * 1.4f;
                num2++;
            }

            var num3 = wiggler.Value * 8f;
            vector.X = boxTopLeft.X + boxPadding;
            vector.Y = boxTopLeft.Y + boxHeight - lineHeight - boxPadding;
            SourcePrimitiveDrawing.Rect(context, this, vector.X, vector.Y - boxPadding * 0.5f,
                boxWidth - boxPadding * 2f,
                4f, PackedColor.White);
            DrawOptionText(context, cancel,
                SourceVector2Math.Add(vector,
                    new(15f, lineHeight + (selectingOptions && optionsIndex == 0 ? num3 : 0f))),
                new(0f, 1f), SourceVector2Math.Multiply(Vector2.One, optionsScale),
                selectingOptions && optionsIndex == 0, !Focused);
            vector.X = boxTopLeft.X + boxWidth - backspaceWidth - widestLetter - widestLetter - acceptWidth -
                       boxPadding;
            DrawOptionText(context, backspace,
                SourceVector2Math.Add(vector,
                    new(15f, lineHeight + (selectingOptions && optionsIndex == 1 ? num3 : 0f))),
                new(0f, 1f), SourceVector2Math.Multiply(Vector2.One, optionsScale),
                selectingOptions && optionsIndex == 1, Value.Length <= 0 || !Focused);
            vector.X += backspaceWidth + widestLetter;
            DrawOptionText(context, accept,
                SourceVector2Math.Add(vector,
                    new(10f, lineHeight + (selectingOptions && optionsIndex == 2 ? num3 : 0f))),
                new(0f, 1f), SourceVector2Math.Multiply(Vector2.One, optionsScale),
                selectingOptions && optionsIndex == 2, Value.Length < 1 || !Focused);
            ActiveFont.DrawEdgeOutline(context, this, Value, SourceVector2Math.Add(Position, new(960f, 286f)),
                new(0.5f, 0.5f), SourceVector2Math.Multiply(Vector2.One, 2f), PackedColor.Gray, 4f,
                PackedColor.DarkSlateBlue, 2f, PackedColor.Black);
            index = num;
        }

        private void DrawOptionText(ISourceRenderContext context, string text, Vector2 at, Vector2 justify,
            Vector2 scale,
            bool selected, bool disabled = false)
        {
            if (UseKeyboardInput || (text.Equals("-") && !allowNegatives) || (text.Equals(".") && !allowDecimals))
            {
                selected = false;
                disabled = true;
            }

            var color = disabled ? disableColor : GetTextColor(selected);
            var edgePackedColor = disabled
                ? SourceColorInterpolation.Lerp(disableColor, PackedColor.Black, 0.7f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic)
                : PackedColor.Gray;
            if (selected && pressedTimer > 0f)
                ActiveFont.Draw(context, this, text, SourceVector2Math.Add(at, Vector2.UnitY), justify, scale, color);
            else
                ActiveFont.DrawEdgeOutline(context, this, text, at, justify, scale, color, 4f, edgePackedColor, 0f,
                    default);
        }

        private PackedColor GetTextColor(bool selected)
        {
            if (selected) return !IntervalQueries.BetweenInterval(timer, 0.1f) ? selectColorB : selectColorA;

            return unselectColor;
        }
    }
}
