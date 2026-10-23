using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Settings;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Text;
using Celeste.Input.Runtime;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence : OuiState
    {
        protected ISourceEngineContext SourceEngine { get; }

        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)SourceEngine;
        protected ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)SourceEngine).ActiveFont;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)SourceEngine).InputSource;
        protected SourceMInputProcess MInput => ((ISourceMInputEnvironment)SourceEngine).MInput;
        protected SettingsState Settings => ((ISettingsContext)SourceEngine).Settings;

        public string StartingName;

        public ISourceFileSelectSlot FileSlot;

        public const int MinNameLength = 1;

        public const int MaxNameLengthNormal = 12;

        public const int MaxNameLengthJP = 8;

        private string[] letters;

        protected int index;

        private int line;

        private float widestLetter;

        private float widestLine;

        private int widestLineCount;

        private bool selectingOptions = true;

        private int optionsIndex;

        private bool hiragana = true;

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

        protected float timer;

        private float ease;

        private readonly WigglerComponent wiggler;

        private static readonly int[] dakuten_able =
        [
            12363, 12365, 12367, 12369, 12371, 12373, 12375, 12377, 12379, 12381,
            12383, 12385, 12388, 12390, 12392, 12399, 12402, 12405, 12408, 12411,
            12459, 12461, 12463, 12465, 12467, 12469, 12471, 12473, 12475, 12477,
            12479, 12481, 12484, 12486, 12488, 12495, 12498, 12501, 12504, 12507,
        ];

        private static readonly int[] handakuten_able =
            [12400, 12403, 12406, 12409, 12412, 12496, 12499, 12502, 12505, 12508];

        protected PackedColor unselectColor = PackedColor.LightGray;

        protected PackedColor selectColorA = SourceHexColor.HexToColor("84FF54");

        protected PackedColor selectColorB = SourceHexColor.HexToColor("FCFF59");

        private readonly PackedColor disableColor = PackedColor.DarkSlateBlue;

        public string Name
        {
            get => FileSlot.Name;
            set => FileSlot.Name = value;
        }

        public int MaxNameLength => !Japanese ? 12 : 8;

        public bool Japanese => Settings.LanguageId == "japanese";

        private Vector2 boxtopleft => Position + new Vector2((1920f - boxWidth) / 2f, 360f + (680f - boxHeight) / 2f);

        public FileNamingSequence(ISourceEngineContext engine) : base(engine)
        {
            SourceEngine = engine;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            Position = new(0f, 1080f);
            Visible = false;
        }
    }
}
