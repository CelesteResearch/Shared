using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Everest.Runtime.Input;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Color = Celeste.Core.Display.PackedColor;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuTextBox : TextMenuPresentation.Item
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;
        private SourceCommands Commands => ((ISourceCommandsProcessEnvironment)engine).Commands;
        private EverestTextInputProcess TextInput => ((IEverestTextInputEnvironment)engine).TextInput;

        public delegate void OnTextChangeHandler(string text);

        private static readonly float DEFAULT_TEXT_SCALE = 1.1f;

        public string PlaceholderText;

        private string _text = "";

        public Dictionary<char, Action<EverestMenuTextBox>> OnTextInputCharActions =
            new Dictionary<char, Action<EverestMenuTextBox>>
            {
                {
                    '\b',
                    delegate(EverestMenuTextBox textBox)
                    {
                        if (textBox.DeleteCharacter())
                        {
                            textBox.Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
                        }
                        else
                        {
                            textBox.Process.AudioSession.Play("event:/ui/main/button_invalid");
                        }
                    }
                }
            };

        public Action AfterInputConsumed;

        private OverworldSequence overworld;

        private bool previousMountainAllowUserRotation;

        private bool previousEngineCommandsEnabled;

        private readonly Queue<char> inputQueue = new Queue<char>();

        public string Text
        {
            get { return _text; }
            protected set
            {
                _text = value;
                this.OnTextChange?.Invoke(Text);
            }
        }

        public float Alpha { get; set; } = 1f;

        public Color TextColor { get; set; } = Color.White;

        public Vector2 TextJustify { get; set; } = new Vector2(0f, 0.5f);

        public float StrokeSize { get; set; } = 2f;

        public Color StrokeColor { get; set; } = Color.Black;

        public Color PlaceHolderTextColor { get; set; } = Color.LightGray * 0.75f;

        public Color TextBoxColor { get; set; } = Color.DarkSlateGray * 0.8f;

        public Vector2 TextScale { get; set; } = SourceVector2Math.Multiply(Vector2.One, DEFAULT_TEXT_SCALE);

        public Vector2 TextPadding { get; set; }

        public float WidthScale { get; set; } = 1f;

        public bool TextBoxConsumedInput { get; private set; }

        public bool Typing { get; private set; }

        public event OnTextChangeHandler OnTextChange;

        public EverestMenuTextBox(ISourceEngineContext engine)
        {
            this.engine = engine;
            TextPadding = new Vector2(((ISourceActiveFontScope)engine).ActiveFont.Measure(' ').X * DEFAULT_TEXT_SCALE,
                ((ISourceActiveFontScope)engine).ActiveFont.LineHeight * DEFAULT_TEXT_SCALE / 6f);
            Selectable = true;
        }

        public EverestMenuTextBox(ISourceEngineContext engine, OverworldSequence overworld)
        {
            this.engine = engine;
            TextPadding = new Vector2(((ISourceActiveFontScope)engine).ActiveFont.Measure(' ').X * DEFAULT_TEXT_SCALE,
                ((ISourceActiveFontScope)engine).ActiveFont.LineHeight * DEFAULT_TEXT_SCALE / 6f);
            Selectable = true;
            this.overworld = overworld;
        }

        public override float LeftWidth()
        {
            if (Container != null)
            {
                return Container.Width * WidthScale;
            }

            return 0f;
        }

        public override float Height()
        {
            return ActiveFont.LineHeight * TextScale.Y + TextPadding.Y * 2f;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            Vector2 position2 = new Vector2(position.X + TextPadding.X, position.Y + Height() / 2f);
            SourcePrimitiveDrawing.Rect(context, Container, position, base.Width, Height(), TextBoxColor);
            if (Text.Length <= 0 && !string.IsNullOrEmpty(PlaceholderText))
            {
                Vector2 vector = SourceVector2Math.Multiply(ActiveFont.Measure(PlaceholderText), TextScale);
                float num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                    (base.Width - TextPadding.X * 4f) / vector.X, 1f);
                ActiveFont.DrawOutline(context, Container, PlaceholderText, position2, TextJustify,
                    SourceVector2Math.Multiply(TextScale, num), PlaceHolderTextColor * Alpha, StrokeSize * num,
                    StrokeColor * (Alpha * Alpha * Alpha));
            }
            else
            {
                ActiveFont.DrawOutline(context, Container, Text + (Typing ? "_" : ""), position2, TextJustify,
                    TextScale,
                    TextColor * Alpha, StrokeSize, StrokeColor * (Alpha * Alpha * Alpha));
            }
        }

        public override void ConfirmPressed()
        {
            StartTyping();
        }

        public void ClearText()
        {
            Text = "";
        }

        public bool DeleteCharacter()
        {
            if (Text.Length > 0)
            {
                Text = Text.Remove(Text.Length - 1);
                return true;
            }

            return false;
        }

        public void StartTyping()
        {
            if (!Typing)
            {
                Process.AudioSession.Play("event:/ui/main/button_toggle_on");
                Typing = true;
                Container.Focused = false;
                Container.RenderAsFocused = true;
                previousEngineCommandsEnabled = Commands.Enabled;
                Commands.Enabled = false;
                if (overworld != null)
                {
                    previousMountainAllowUserRotation = overworld.Mountain.AllowUserRotation;
                    overworld.Mountain.AllowUserRotation = false;
                }

                inputQueue.Clear();
                TextInput.OnInput += OnTextInput;
            }
        }

        public void StopTyping()
        {
            if (Typing)
            {
                TextInput.OnInput -= OnTextInput;
                inputQueue.Clear();
                Process.AudioSession.Play("event:/ui/main/button_toggle_off");
                Typing = false;
                Container.Focused = true;
                Container.RenderAsFocused = false;
                TextBoxConsumedInput = false;
                MInput.Disabled = false;
                Commands.Enabled = previousEngineCommandsEnabled;
                if (overworld != null)
                {
                    overworld.Mountain.AllowUserRotation = previousMountainAllowUserRotation;
                }
            }
        }

        private bool HandleNewInputChar(char c)
        {
            Vector2 vector = SourceVector2Math.Multiply(ActiveFont.Measure(Text + c + "_"), TextScale);
            Vector2 vector2 = SourceVector2Math.Multiply(TextPadding, 4f);
            if (!char.IsControl(c) &&
                ((ISourceActiveFontScope)engine).ActiveFont.Font
                .Get(((ISourceActiveFontScope)engine).ActiveFont.BaseSize)
                .Characters.ContainsKey(c) && SourceVector2Math.Add(vector, vector2).X < base.Width)
            {
                Text += c;
                Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                return true;
            }

            Process.AudioSession.Play("event:/ui/main/button_invalid");
            return false;
        }

        public void OnTextInput(char c)
        {
            if (Typing)
            {
                inputQueue.Enqueue(c);
            }
        }

        public override void Update()
        {
            while (inputQueue.Count > 0 && Typing)
            {
                char c = inputQueue.Dequeue();
                if (OnTextInputCharActions.TryGetValue(c, out var value))
                {
                    value(this);
                    TextBoxConsumedInput = true;
                }
                else
                {
                    TextBoxConsumedInput = HandleNewInputChar(c);
                }
            }

            if (Typing)
            {
                if (MInput.Keyboard.Pressed(Keys.Delete))
                {
                    if (Text.Length > 0)
                    {
                        ClearText();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
                    }

                    TextBoxConsumedInput = true;
                }

                MInput.Disabled = TextBoxConsumedInput;
                if (TextBoxConsumedInput)
                {
                    foreach (SourceVirtualInput virtualInput in MInput.GetVirtualInputsForSynchronization())
                    {
                        if (virtualInput is SourceVirtualButton virtualButton)
                        {
                            virtualButton.ConsumePress();
                        }
                    }
                }

                (overworld?.Mountain)?.SetFreeCam(value: false);
                AfterInputConsumed?.Invoke();
            }

            TextBoxConsumedInput = false;
        }

        private static int NegativeModulo(int number, int modulo)
        {
            return (number % modulo + modulo) % modulo;
        }

        public static bool WrappingLinearSearch<T>(List<T> items, Func<T, bool> predicate, int startIndex,
            bool inReverse,
            out int nextModIndex)
        {
            int num = ((!inReverse) ? 1 : (-1));
            int num2 = NegativeModulo(startIndex - num, items.Count);
            for (int num3 = NegativeModulo(startIndex, items.Count);
                 num3 != num2;
                 num3 = NegativeModulo(num3 + num, items.Count))
            {
                if (predicate(items[num3]))
                {
                    nextModIndex = num3;
                    return true;
                }
            }

            nextModIndex = startIndex;
            return false;
        }
    }
}
