using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Editor
{
    public sealed class OriginalMapEditorConstruction : IOriginalMapEditorConstruction
    {
        public MapEditorState Create(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true)
        {
            return new(engine, area, reloadMapData);
        }
    }
}
