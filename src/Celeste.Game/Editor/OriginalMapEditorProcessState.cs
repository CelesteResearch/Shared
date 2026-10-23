using Celeste.Core.Display;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Editor
{
    public sealed class OriginalMapEditorProcessState : MapEditorProcessState
    {
        public readonly PackedColor SourceGridColor = new(0.1f, 0.1f, 0.1f);
        private LevelTemplateColorsState templateColors;

        public override LevelTemplateColorsState TemplateColors =>
            templateColors ??= new OriginalLevelTemplateColorsState();

        public override PackedColor GridColor => SourceGridColor;

        public OriginalMapEditorProcessState(ISourceEngineContext engine) : base(engine)
        {
        }
    }
}
