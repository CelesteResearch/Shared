using Celeste.Core.Scheduling;
using Celeste.Game.Editor;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Editor
{
    public sealed class EverestMapEditorConstruction : IOriginalMapEditorConstruction
    {
        public MapEditorState Create(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true)
        {
            return new EverestMapEditorState(engine, area, reloadMapData);
        }
    }
}
