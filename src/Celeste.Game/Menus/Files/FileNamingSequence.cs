using Celeste.Input.Runtime;
using Celeste.Core.Display;
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
using Celeste.Game.Controls.Source;
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
    public partial class FileNamingSequence : OuiState
    {
        private readonly ISourceEngineContext engine;
        protected ISourceEngineContext SourceEngine => engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        protected ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;

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

        private WigglerComponent wiggler;

        private static int[] dakuten_able = new int[40]
        {
            12363, 12365, 12367, 12369, 12371, 12373, 12375, 12377, 12379, 12381,
            12383, 12385, 12388, 12390, 12392, 12399, 12402, 12405, 12408, 12411,
            12459, 12461, 12463, 12465, 12467, 12469, 12471, 12473, 12475, 12477,
            12479, 12481, 12484, 12486, 12488, 12495, 12498, 12501, 12504, 12507
        };

        private static int[] handakuten_able = new int[10]
            { 12400, 12403, 12406, 12409, 12412, 12496, 12499, 12502, 12505, 12508 };

        protected PackedColor unselectColor = PackedColor.LightGray;

        protected PackedColor selectColorA = SourceHexColor.HexToColor("84FF54");

        protected PackedColor selectColorB = SourceHexColor.HexToColor("FCFF59");

        private PackedColor disableColor = PackedColor.DarkSlateBlue;

        public string Name
        {
            get { return FileSlot.Name; }
            set { FileSlot.Name = value; }
        }

        public int MaxNameLength
        {
            get
            {
                if (!Japanese)
                {
                    return 12;
                }

                return 8;
            }
        }

        public bool Japanese => Settings.LanguageId == "japanese";

        private Vector2 boxtopleft => Position + new Vector2((1920f - boxWidth) / 2f, 360f + (680f - boxHeight) / 2f);

        public FileNamingSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f);
            Position = new Vector2(0f, 1080f);
            Visible = false;
        }
    }
}
