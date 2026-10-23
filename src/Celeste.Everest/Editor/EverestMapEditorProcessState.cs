using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Editor;

namespace Celeste.Everest.Editor
{
    public sealed class EverestMapEditorProcessState : MapEditorProcessState
    {
        public PackedColor SourceGridColor = new(0.1f, 0.1f, 0.1f);
        private LevelTemplateColorsState templateColors;

        public override LevelTemplateColorsState TemplateColors =>
            templateColors ??= new EverestLevelTemplateColorsState();

        public override PackedColor GridColor => SourceGridColor;

        public EverestMapEditorProcessState(ISourceEngineContext engine) : base(engine)
        {
        }
    }
}
