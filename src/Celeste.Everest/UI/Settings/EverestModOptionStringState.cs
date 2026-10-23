using Celeste.Core.Display;
using Celeste.Everest.UI.ModOptions;
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
using Celeste.Game.Controls.Source;
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

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;

        private IEverestModOptionStringEnvironment Environment => (IEverestModOptionStringEnvironment)engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private EverestTextInputProcess TextInput => ((IEverestTextInputEnvironment)engine).TextInput;
        private SourceCommands Commands => ((ISourceCommandsProcessEnvironment)engine).Commands;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;

        public string StartingValue;

        private string _Value;

        public int MaxValueLength;

        public int MinValueLength;

        private string[] letters;

        private int index;

        private int line;

        private float widestLetter;

        private float widestLine;

        private int widestLineCount;

        private bool selectingOptions = true;

        private int optionsIndex;

        private float lineHeight;

        private float lineSpacing;

        private float boxPadding;

        private float optionsScale;

        private string cancel;

        private string space;

        private string backspace;

        private string accept;

        private float cancelWidth;

        private float spaceWidth;

        private float backspaceWidth;

        private float beginWidth;

        private float optionsWidth;

        private float boxWidth;

        private float boxHeight;

        private float pressedTimer;

        private float timer;

        private float ease;

        private WigglerComponent wiggler;

        private PackedColor unselectColor = PackedColor.LightGray;

        private PackedColor selectColorA = SourceHexColor.HexToColor("84FF54");

        private PackedColor selectColorB = SourceHexColor.HexToColor("FCFF59");

        private PackedColor disableColor = PackedColor.DarkSlateBlue;

        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                this.OnValueChange?.Invoke(value);
            }
        }

        private Vector2 boxtopleft => Position + new Vector2((1920f - boxWidth) / 2f, 360f + (680f - boxHeight) / 2f);

        public bool UseKeyboardInput => Environment.CurrentCoreSettings?.UseKeyboardForTextInput ?? false;

        public event Action<string> OnValueChange;

        public event Action<bool> OnExit;

        public EverestModOptionStringState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            Position = new Vector2(0f, 1080f);
            Visible = false;
        }

        public EverestModOptionStringState Init<T>(string value, Action<string> onValueChange) where T : OuiState
        {
            return Init<T>(value, onValueChange, 12, 1);
        }

        public EverestModOptionStringState Init<T>(string value, Action<string> onValueChange, int maxValueLength)
            where T : OuiState
        {
            return Init<T>(value, onValueChange, maxValueLength, 1);
        }

        public EverestModOptionStringState Init<T>(string value, Action<string> onValueChange, int maxValueLength,
            int minValueLength) where T : OuiState
        {
            return Init(value, onValueChange, delegate { base.Overworld.Goto<T>(); }, maxValueLength, minValueLength);
        }

        public EverestModOptionStringState Init<T>(string value, Action<string> onValueChange, Action<bool> onExit,
            int maxValueLength, int minValueLength) where T : OuiState
        {
            return Init(value, onValueChange, delegate(bool confirm)
            {
                Overworld.Goto<T>();
                onExit?.Invoke(confirm);
            }, maxValueLength, minValueLength);
        }

        public EverestModOptionStringState Init(string value, Action<string> onValueChange, Action<bool> exit,
            int maxValueLength, int minValueLength)
        {
            string obj = value ?? "";
            string value2 = obj;
            StartingValue = obj;
            _Value = value2;
            this.OnValueChange = onValueChange;
            MaxValueLength = maxValueLength;
            MinValueLength = minValueLength;
            OnExit += exit;
            Environment.ModOptionStringProcess.Cancelled = false;
            return this;
        }
    }
}
